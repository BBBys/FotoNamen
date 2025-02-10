using FreeImageAPI;
using FreeImageAPI.Metadata;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FotoNamen
{
  /// <summary>
  /// Hauptformular
  /// </summary>
  public partial class fFNMain : Form
  {
    public enum datumTeile
    {
      Jahr = 0,
      Monat = 1,
      Tag = 2,
      Stunde = 3,
      Minute = 4,
      Sekunde = 5
    };

    private readonly FFehler ffehler = new FFehler();

    /// <summary>
    /// Verzeichnis, in dem die Bilder umbenannt werden
    /// </summary>
    private string Suchpfad;

    /// <summary>
    /// Liste der Dateien im ausgewählten Verzeichnis
    /// </summary>
    private FileInfo[] Files;

    /// <summary>
    /// gespeicherte Programmparameter
    /// </summary>
    private readonly Properties.Settings Props;
    // private System.Drawing.Imaging.PropertyItem pi1;
    /// <summary>
    /// Anfang der Dateinamen zur Auswahl
    /// </summary>
    private string Filter;
    /// <summary>
    /// true, wenn Dateinamen ausgewählt werden (statt alle Dateien umzubenennen
    /// </summary>
    private bool fehler, Filtern;
    private const string BILDEREXT = "*.jpg";

    public fFNMain()
    {
      InitializeComponent();
      Text = Properties.Resources.Fenstertitel + " V" + Application.ProductVersion + ". ";
#if DEBUG
      Text += "DEBUGVERSION";
#else
      Text += Application.CompanyName + ": " + Application.ProductName;
#endif
      Props = Properties.Settings.Default;
      Suchpfad = Props.Pfad;
      cbName.Checked = Props.NameVorgegeben;
      cbSec.Checked = Props.Sekunden;
      cbZähl.Checked = Props.Zähl;
      tbName.Text = Props.vorgegebenerName;
      tbName.Enabled = cbName.Checked;
      Files = Verzeichnisanzeige(Suchpfad, Filtern, Filter);
      if (Environment.Is64BitProcess)
      {
        MessageBox.Show(
@"die EXIF-Dll FreeImage läuft nicht auf 64-Bit-Systemen. Schade.
Versuchen wir es trotzdem. Wenn jedoch die Meldung 
""FreeImage.dll seems to be missing. Aborting."" 
kommt, dann ist es aussichtslos.

Kopf hoch: Neu compilieren für x86 als Zielsystem könnte helfen.");
        //throw new NotImplementedException("FreeImage ist nicht kompatibel mit diesem System");
      } //inkompatibel mit FreeImage
    }

    /// <summary>
    /// Informationen für Verzeichnis
    /// </summary>
    private FileInfo[] Verzeichnisanzeige(string suchpfad, bool filtern, string filter)
    {
      FileInfo[] files;
      lVerz.Text = suchpfad;
      DirectoryInfo di = new DirectoryInfo(suchpfad);
      if (di.Exists)
      {
        files = filtern ? di.GetFiles(filter + BILDEREXT) : di.GetFiles(BILDEREXT);
        lCrea.Text = "erstellt:  " + di.CreationTime.ToShortDateString();
        lChan.Text = "geändert: " + di.LastWriteTime.ToShortDateString();
        lAnz.Text = files.Count().ToString() + " Fotos";
        return files;
      }
      else
      {
        lCrea.Text = "";
        lChan.Text = "Verzeichnis nicht vorhanden";
        lAnz.Text = "Verzeichnis nicht vorhanden";
        return null;
      }

    }

    /// <summary>
    /// Klicken für Verzeichnisauswahl
    /// </summary>
    private void tbVerz_Click(object sender, EventArgs e)
    {
      fbd1.SelectedPath = Suchpfad;
      if (fbd1.ShowDialog() == DialogResult.OK)
      {
        Suchpfad = fbd1.SelectedPath;
        Props.Pfad = Suchpfad;
        Files = Verzeichnisanzeige(Suchpfad, Filtern, Filter);
        Props.Save();
      }

    }

    private void bAuswert_Click(object sender, EventArgs e)
    {
      long gr, grmax, grmin;
      DateTime timmin, timmax, ctim;
      timmin = new DateTime(9999, 12, 31);
      timmax = new DateTime(1, 1, 1);
      grmax = 0;
      grmin = 99999999999;
      if (Files != null)
        foreach (FileInfo bild in Files)
        {
          ctim = bild.CreationTime;
          if (ctim < timmin)
            timmin = ctim;
          if (ctim > timmax)
            timmax = ctim;
          gr = bild.Length;
          if (gr < grmin)
            grmin = gr;
          if (gr > grmax)
            grmax = gr;
        }
      lDat.Text = timmin.ToString("von d. MMM yyyy HH:mm", CultureInfo.CurrentCulture) + timmax.ToString(@" bi\s d. MMM yyyy HH:mm", CultureInfo.CurrentCulture);
      lGr.Text = grmax > 2000000
        ? "von " + Math.Round(grmin * .000001, 1).ToString("G", CultureInfo.CurrentCulture) + " bis " + Math.Round(.000001 * grmax, 1).ToString("G", CultureInfo.CurrentCulture) + " MB"
        : grmax > 2000
        ? "von " + Math.Round(grmin * .001, 1).ToString("G", CultureInfo.CurrentCulture) + " bis " + Math.Round(.001 * grmax, 1).ToString("G", CultureInfo.CurrentCulture) + " KB"
        : "von " + grmin.ToString("G", CultureInfo.CurrentCulture) + " bis " + grmax.ToString("G", CultureInfo.CurrentCulture) + " Byte";
    }

    private void bBearb_Click(object sender, EventArgs e)
    {
      MetadataTag tag;
      FIBITMAP bm;
      if (!FreeImage.IsAvailable())
      {
        _ = MessageBox.Show("FreeImage.dll seems to be missing. Aborting.");
        return;
      }
      if (Files != null)
        foreach (FileInfo bild in Files)
        {
          string dtExifDigit = null, dtExifOrig = null, dtMain = null;
          string Hersteller = null, Artist = null, Kamera = null;
          bm = FreeImage.LoadEx(bild.FullName);
          (tag, dtExifDigit, dtExifOrig) = leseExifExif(bm);
          //if (tag != null)
          (dtMain, Hersteller, Kamera, Artist) = leseExifMain(ref tag, ref bm);
          #region andere Tags
          //TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_COMMENTS);
          //TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_CUSTOM);
          //TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_EXIF_GPS);
          //TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_EXIF_INTEROP);
          //hier ist was TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_EXIF_MAKERNOTE);
          //hier ist was   TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_EXIF_EXIF);
          //TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_GEOTIFF);
          //TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_IPTC);
          //TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_NODATA);
          //TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_XMP);
          //hier ist was TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_EXIF_MAIN);
          //TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_ANIMATION);
          //TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_IPTC);
          //TagsLesen(fiBitmap, FREE_IMAGE_MDMODEL.FIMD_XMP);
          #endregion
          FreeImage.UnloadEx(ref bm);

          fehler = (dtExifDigit == null) && (dtExifOrig == null) && (dtMain == null);
          if (!fehler)
            fehler = (dtExifDigit != null) && (dtExifOrig != null) && !Equals(dtExifDigit, dtExifOrig);
          if (!fehler)
            fehler = (dtExifDigit != null) && (dtMain != null) && !Equals(dtExifDigit, dtMain);
          if (!fehler)
            if (dtMain == null)
              dtMain = dtExifOrig;
            else
              fehler = (dtExifOrig != null) && !Equals(dtMain, dtExifOrig);
          if (fehler)
          {
            try
            {
              pb1.Load(bild.FullName);
            }
            catch { }//das muss noch besser gelöst werden
            finally
            {
              ffehler.DTDigit = dtExifDigit;
              ffehler.DTOrig = dtExifOrig;
              ffehler.DTMain = dtMain;
              ffehler.Hersteller = Hersteller;
              ffehler.Kamera = Kamera;
              ffehler.Artist = Artist;
              ffehler.Bild = pb1.Image;
              ffehler.Datei = bild.FullName;
            }
            if (ffehler.ShowDialog() == DialogResult.Cancel)
              break;
          }
          else
          {
            string fullname;
            fullname = bild.FullName;
            _ = Path.GetDirectoryName(fullname);
            _ = Path.GetExtension(fullname);
            _ = Path.GetFileNameWithoutExtension(fullname);
          }
        }/*foreach bild*/
    }

    private static (string, string) TagsLesen(FIBITMAP bm, FREE_IMAGE_MDMODEL fimd)
    {
      string name = "", linse = "";
      //    var mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_COMMENTS, fiBitmap, out mdTag);
      FIMETADATA mdh = FreeImage.FindFirstMetadata(fimd, bm, out MetadataTag tag);
      do
        if (tag != null)
        {
          if (tag.Key.Equals("OwnerName", StringComparison.CurrentCultureIgnoreCase))
            name = tag.Value.ToString();
          if (tag.Key.Equals("LensModel", StringComparison.CurrentCultureIgnoreCase))
            linse = tag.Value.ToString();
          Debug.WriteLineIf(tag.Key != null, $"{tag.Key} : {tag.Value}");
        } while (FreeImage.FindNextMetadata(mdh, out tag));
      FreeImage.FindCloseMetadata(mdh);
      return (name, linse);
    }
    /// <summary>
    /// liest die Exif-Daten FIMD_EXIF_MAIN aus
    /// </summary>
    /// <param name="mdTag">MetadataTag</param>
    /// <param name="fiBitmap">FIBITMAP</param>
    /// <returns>(dtMain, Hersteller, Kamera)</returns>
    private static (string, string, string, string) leseExifMain(
      ref MetadataTag mdTag,
      ref FIBITMAP fiBitmap)
    {
      string dtMain = "", Hersteller = "?", Kamera = "?", Artist = "?";
      if (!fiBitmap.IsNull)
      {
        FIMETADATA mdh;
        mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_EXIF_MAIN, fiBitmap, out mdTag);
        if (!mdh.IsNull)
          do /*while (FreeImage.FindNextMetadata(mdh, out mdTag))*/
          {
            Debug.WriteLine(mdTag.Key);
            if (mdTag.Key.Equals("DateTime", StringComparison.CurrentCultureIgnoreCase))
              dtMain = mdTag.Value.ToString();
            else if (mdTag.Key.Equals("Make", StringComparison.CurrentCultureIgnoreCase))
              Hersteller = mdTag.Value.ToString();
            else if (mdTag.Key.Equals("Model", StringComparison.CurrentCultureIgnoreCase))
              Kamera = mdTag.Value.ToString();
            else if (mdTag.Key.Equals("Artist", StringComparison.CurrentCultureIgnoreCase))
              Artist = mdTag.Value.ToString();
          } while (FreeImage.FindNextMetadata(mdh, out mdTag));
        FreeImage.FindCloseMetadata(mdh);
        if (Kamera.EndsWith("\0"))
          Kamera = Kamera.Substring(0, Kamera.Length - 1);
        if (Artist.EndsWith("\0"))
          Artist = Artist.Substring(0, Artist.Length - 1);
      }
      return (dtMain, Hersteller, Kamera, Artist);
    }
    /// <summary>
    /// liest die Exif-Daten FIMD_EXIF_EXIF aus
    /// </summary>
    /// <param name="bm">FIBITMAP</param>
    /// <returns>(MetadataTag, Datum Digitalisiert, Datum Original)</returns>
    private static (MetadataTag, string, string) leseExifExif(FIBITMAP bm)
    {
      string dtExifDigit = "", dtExifOrig = "";
      FIMETADATA mdh;
      if (bm.IsNull)
        return (null, null, null);
      else
      {
        mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_EXIF_EXIF, bm, out MetadataTag tag);
        if (!mdh.IsNull)
          do
          {/* es gibt Metadaten - welche sind es?*/
            Debug.WriteLine(tag.Key);
            if (tag.Key.Equals("DateTimeDigitized", StringComparison.CurrentCultureIgnoreCase))
              dtExifDigit = tag.Value.ToString();
            else if (tag.Key.Equals("DateTimeOriginal", StringComparison.CurrentCultureIgnoreCase))
              dtExifOrig = tag.Value.ToString();
          } while (FreeImage.FindNextMetadata(mdh, out tag));
        FreeImage.FindCloseMetadata(mdh);
        return (tag, dtExifDigit, dtExifOrig);
      }
    }
    private void starteUmbenennung(object sender, EventArgs e)
    {
      MetadataTag tag;
      FIBITMAP bm;
      if (!FreeImage.IsAvailable())
      {
        _ = MessageBox.Show("die FreeImage.dll fehlt");
        return;
      }
      lWarten.Visible = true;
      lWarten.Update();
      lFertig.Visible = false;
      lFertig.Update();
      if (Files != null)
        foreach (FileInfo bild in Files)
        {
          string datumExifDigitized = null, datumExifOriginal = null, datumExifMain = null,
            Hersteller = null, Kamera = null, Artist = null;
          ;
          bm = FreeImage.LoadEx(bild.FullName);
          (tag, datumExifDigitized, datumExifOriginal) = leseExifExif(bm);
          (datumExifMain, Hersteller, Kamera, Artist) = leseExifMain(ref tag, ref bm);
          FreeImage.UnloadEx(ref bm);

          fehler = datumExifOriginal == null;
          if (fehler)
          {
            try
            {
              pb1.Load(bild.FullName);
              pb1.Update();
            }
            catch { }/* TODO das muss noch besser werden*/
            finally
            {
              ffehler.Artist = Artist;
              ffehler.DTDigit = datumExifDigitized;
              ffehler.DTOrig = datumExifOriginal;
              ffehler.DTMain = datumExifMain;
              ffehler.Hersteller = Hersteller;
              ffehler.Kamera = Kamera;
              ffehler.Bild = pb1.Image;
              ffehler.Datei = bild.FullName;
            }
            if (ffehler.ShowDialog() == DialogResult.Cancel)
              break;
          }
          else /* if (fehler)*/
          {
            Random rnd = new Random();
            char[] del = new char[] { ':', ' ', '\0' };
            string[] teileDatumExifOriginal;
            string name, neuname, neubasis, fullname, fullCR2name, pfad, ext, prfx, textVorweg, neufullname, neufullCR2name;
            fullname = bild.FullName;
            pfad = Path.GetDirectoryName(fullname);
            ext = Path.GetExtension(fullname);
            name = Path.GetFileNameWithoutExtension(fullname);
            //fullCR2name = pfad + "\\" + name + ".CR2";
            fullCR2name = Path.Combine(pfad, name + ".CR2");
            teileDatumExifOriginal = datumExifOriginal.Split(del);
            if (string.CompareOrdinal(teileDatumExifOriginal[(int)datumTeile.Jahr], "1900") > 0)
            {
              prfx = tbPrfix.Text.Trim();
              textVorweg = prfx.Length > 0 ? prfx + " " : "";
              neubasis =
                textVorweg +
                teileDatumExifOriginal[(int)datumTeile.Jahr] +
                teileDatumExifOriginal[(int)datumTeile.Monat] +
                teileDatumExifOriginal[(int)datumTeile.Tag] +
                teileDatumExifOriginal[(int)datumTeile.Stunde] +
                teileDatumExifOriginal[(int)datumTeile.Minute] +
                (
                  cbSec.Checked ?
                  teileDatumExifOriginal[(int)datumTeile.Sekunde] :
                  ""
                );
              neuname = neubasis +
                 (
                   cbZähl.Checked ?
                   "00" :
                   ""
                 );
              neufullname = Path.Combine(pfad, neuname + ext);
              while (File.Exists(neufullname))
              {
                neuname = neubasis + rnd.Next(10, 100).ToString();
                neufullname = pfad + "\\" + neuname + ext;
              }
              File.Move(fullname, neufullname);
              if (File.Exists(fullCR2name))
              {
                neufullCR2name = pfad + "\\RAW\\" + neuname + ".CR2";
                try
                {
                  File.Move(fullCR2name, neufullCR2name);
                }
                catch (DirectoryNotFoundException)
                {
                  _ = Directory.CreateDirectory(pfad + "\\RAW");
                  File.Move(fullCR2name, neufullCR2name);
                }
              }
            }
            else
              _ = MessageBox.Show($"Datum {datumExifOriginal}", "Wandlung unmöglich", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
        }/*foreach bild*/
      lWarten.Visible = false;
      lFertig.Visible = true;
      System.Media.SystemSounds.Beep.Play();
    }

    private void cbName_Click(object sender, EventArgs e)
    {
      Filtern = cbName.Checked;
      tbName.Enabled = Filtern;
      Props.NameVorgegeben = Filtern;
      Props.Save();
      Files = Verzeichnisanzeige(Suchpfad, Filtern, Filter);
    }

    private void bVerz_MouseEnter(object sender, EventArgs e)
    {
      lHilfe.Text = "Verzeichnis ändern";
    }

    private void bAuswert_MouseEnter(object sender, EventArgs e)
    {
      lHilfe.Text = "Dateieigenschaften prüfen";
    }

    private void bBearb_MouseEnter(object sender, EventArgs e)
    {
      lHilfe.Text = "Fotos auf gültige Zeitstempel prüfen\nBilder ohne Zeitstempel oder\nBilder mit Widersprüchen\nwerden angezeigt";
    }

    private void button1_MouseEnter(object sender, EventArgs e)
    {
      lHilfe.Text = "startet die Umbenennung der Dateien";

    }

    private void bEnde_MouseEnter(object sender, EventArgs e)
    {
      lHilfe.Text = "beendet das Programm";

    }

    private void bEnde_Click(object sender, EventArgs e)
    {
      Props.Save();
      Close();
    }

    private void tbPrfix_MouseEnter(object sender, EventArgs e)
    {
      lHilfe.Text = "dieser Text\nwird den Dateinamen vorangestellt";

    }

    private void funktioniertNich(object sender, EventArgs e)
    {
      lHilfe.Text = "was soll bei unterschiedlichen Zeiten\nin den EXIF-Daten passieren?\n(funktioniert noch nicht)";

    }

    private void cbName_MouseEnter(object sender, EventArgs e)
    {
      lHilfe.Text = "Filter für Dateinamen";

    }

    private void cbSec_MouseEnter(object sender, EventArgs e)
    {
      lHilfe.Text = "der neu Dateiname enthält auch\ndie Sekunden der Aufnahmezeit und\neinen Zähler 00 ...";

    }

    private void cb(object sender, MouseEventArgs e)
    {
      lHilfe.Text = "Filter für Dateinamen";

    }

    private void cbSec_Click(object sender, EventArgs e)
    {
      lHilfe.Text = (!cbSec.Checked) ? "der neu Dateiname enthält keine Sekunden " :
      "der neu Dateiname enthält auch\ndie Sekunden der Aufnahmezeit ";
      Props.Sekunden = cbSec.Checked;

    }

    private void cbZähl_Click(object sender, EventArgs e)
    {
      lHilfe.Text = (!cbZähl.Checked) ? "der neu Dateiname enthält keinen Zähler " : "der neu Dateiname enthält auch\neinen Zähler 00 ...";
      Props.Zähl = cbZähl.Checked;

    }

    private void tbName_Leave(object sender, EventArgs e)
    {
      Filter = tbName.Text;
      Props.vorgegebenerName = Filter;
      Props.Save();
      Files = Verzeichnisanzeige(Suchpfad, Filtern, Filter);
    }
  }
}