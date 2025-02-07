using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FreeImageAPI;
using Microsoft.VisualBasic;
using System.Globalization;



namespace FotoNamen
{
    /// <summary>
    /// Hauptformular
    /// </summary>
    public partial class fFNMain : Form
    {
        FFehler ffehler = new FFehler();
        /// <summary>
        /// Verzeichnis, in dem die Bilder umbenannt werden
        /// </summary>
        string Suchpfad;
        /// <summary>
        /// Liste der Dateien im ausgewählten Verzeichnis
        /// </summary>
        FileInfo[] Files;
        /// <summary>
        /// gespeicherte Programmparameter
        /// </summary>
        Properties.Settings Props;
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId = "System.Windows.Forms.Control.set_Text(System.String)")]
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
            tbName.Text = Props.vorgegebenerName;
            tbName.Enabled = cbName.Checked;
            Files = Verzeichnisanzeige(Suchpfad, Filtern, Filter);
            if (System.Environment.Is64BitProcess)
                Close();//inkompatibel mit FreeImage
        }

        /// <summary>
        /// Informationen für Verzeichnis
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", MessageId = "System.Windows.Forms.Control.set_Text(System.String)")]
        private FileInfo[] Verzeichnisanzeige(string suchpfad, bool filtern, string filter)
        {
            FileInfo[] files;
            lVerz.Text = suchpfad;
            DirectoryInfo di = new DirectoryInfo(suchpfad);
            if (di.Exists)
            {
                if (filtern) files = di.GetFiles(filter + BILDEREXT);
                else files = di.GetFiles(BILDEREXT);
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
            if (Files != null) foreach (FileInfo bild in Files)
                {
                    ctim = bild.CreationTime;
                    if (ctim < timmin) timmin = ctim;
                    if (ctim > timmax) timmax = ctim;
                    gr = bild.Length;
                    if (gr < grmin) grmin = gr;
                    if (gr > grmax) grmax = gr;
                }
            lDat.Text = timmin.ToString("von d. MMM yyyy HH:mm", CultureInfo.CurrentCulture) + timmax.ToString(@" bi\s d. MMM yyyy HH:mm", CultureInfo.CurrentCulture);
            if (grmax > 2000000) lGr.Text = "von " + Math.Round(grmin * .000001, 1).ToString("G", CultureInfo.CurrentCulture) + " bis " + Math.Round(.000001 * grmax, 1).ToString("G", CultureInfo.CurrentCulture) + " MB";
            else if (grmax > 2000) lGr.Text = "von " + Math.Round(grmin * .001, 1).ToString("G", CultureInfo.CurrentCulture) + " bis " + Math.Round(.001 * grmax, 1).ToString("G", CultureInfo.CurrentCulture) + " KB";
            else lGr.Text = "von " + grmin.ToString("G", CultureInfo.CurrentCulture) + " bis " + grmax.ToString("G", CultureInfo.CurrentCulture) + " Byte";
        }

        private void bBearb_Click(object sender, EventArgs e)
        {
            FreeImageAPI.Metadata.MetadataTag tag;
            FIBITMAP bm;
            if (!FreeImage.IsAvailable())
            {
                MessageBox.Show("FreeImage.dll seems to be missing. Aborting.");
                return;
            }

            if (Files != null) foreach (FileInfo bild in Files)
                {
                    string dtExifDigit = null, dtExifOrig = null, dtMain = null, Hersteller = null, Kamera = null;
                    bm = FreeImage.LoadEx(bild.FullName);
                    tag = Metadata1(ref bm, ref dtExifDigit, ref dtExifOrig);
                    if (tag != null)
                        MetaData2(ref tag, ref bm, ref dtMain, ref Hersteller, ref Kamera);
                    #region andere Tags
                    //    mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_COMMENTS, bm, out tag);
                    //   do {

                    //    } while (FreeImage.FindNextMetadata(mdh, out tag));

                    //    FreeImage.FindCloseMetadata(mdh);
                    //    mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_CUSTOM, bm, out tag);
                    //  do  {

                    //    }  while (FreeImage.FindNextMetadata(mdh, out tag));

                    //    FreeImage.FindCloseMetadata(mdh);
                    //    mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_EXIF_GPS, bm, out tag);
                    // do   {

                    //    }    while (FreeImage.FindNextMetadata(mdh, out tag));

                    //    FreeImage.FindCloseMetadata(mdh);
                    //    mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_EXIF_INTEROP, bm, out tag);
                    //do   {

                    //    }
                    //     while (FreeImage.FindNextMetadata(mdh, out tag));
                    //    FreeImage.FindCloseMetadata(mdh);
                    //    mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_EXIF_MAKERNOTE, bm, out tag);
                    //do    {

                    //    }
                    //    while (FreeImage.FindNextMetadata(mdh, out tag));
                    //    FreeImage.FindCloseMetadata(mdh);
                    //    mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_GEOTIFF, bm, out tag);
                    //do   {

                    //    }
                    //     while (FreeImage.FindNextMetadata(mdh, out tag));
                    //    FreeImage.FindCloseMetadata(mdh);
                    //    mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_IPTC, bm, out tag);
                    //do    {

                    //    }
                    //      while (FreeImage.FindNextMetadata(mdh, out tag));
                    //  FreeImage.FindCloseMetadata(mdh);
                    //    mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_NODATA, bm, out tag);
                    //do   {

                    //    }
                    //    while (FreeImage.FindNextMetadata(mdh, out tag));
                    //     FreeImage.FindCloseMetadata(mdh);
                    //    mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_XMP, bm, out tag);
                    //    do
                    //    {

                    //    }
                    //    while (FreeImage.FindNextMetadata(mdh, out tag));
                    //FreeImage.FindCloseMetadata(mdh);
                    #endregion
                    FreeImage.UnloadEx(ref bm);

                    fehler = (dtExifDigit == null) && (dtExifOrig == null) && (dtMain == null);
                    if (!fehler) fehler = (dtExifDigit != null) && (dtExifOrig != null) && !Equals(dtExifDigit, dtExifOrig);
                    if (!fehler) fehler = (dtExifDigit != null) && (dtMain != null) && !Equals(dtExifDigit, dtMain);
                    if (!fehler) if (dtMain == null)
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
                            ffehler.Bild = pb1.Image;
                            ffehler.Datei = bild.FullName;
                        }
                        if (ffehler.ShowDialog() == DialogResult.Cancel) break;
                    }
                    else
                    {
                        string name, fullname, pfad, ext;
                        fullname = bild.FullName;
                        pfad = Path.GetDirectoryName(fullname);
                        ext = Path.GetExtension(fullname);
                        name = Path.GetFileNameWithoutExtension(fullname);

                        //File.Move(fullname,
                    }
                }/*foreach bild*/
        }

        private static void MetaData2(ref FreeImageAPI.Metadata.MetadataTag tag, ref FIBITMAP bm, ref string dtMain, ref string Hersteller, ref string Kamera)
        {
            if (!bm.IsNull)
            {
                FIMETADATA mdh;
                mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_EXIF_MAIN, bm, out tag);
                if (!mdh.IsNull)
                    do /*while (FreeImage.FindNextMetadata(mdh, out tag))*/
                    {
                        if (tag.Key.Equals("DateTime", StringComparison.CurrentCultureIgnoreCase))
                            dtMain = tag.Value.ToString();
                        else if (tag.Key.Equals("Make", StringComparison.CurrentCultureIgnoreCase))
                            Hersteller = tag.Value.ToString();
                        else if (tag.Key.Equals("Model", StringComparison.CurrentCultureIgnoreCase))
                            Kamera = tag.Value.ToString();
                    } while (FreeImage.FindNextMetadata(mdh, out tag));
                FreeImage.FindCloseMetadata(mdh);
            }
        }
        private static FreeImageAPI.Metadata.MetadataTag Metadata1(ref FIBITMAP bm, ref string dtExifDigit, ref string dtExifOrig)
        {
            FIMETADATA mdh;

            if (bm.IsNull) return null;
            else
            {
                FreeImageAPI.Metadata.MetadataTag tag;
                mdh = FreeImage.FindFirstMetadata(FREE_IMAGE_MDMODEL.FIMD_EXIF_EXIF, bm, out tag);
                if (!mdh.IsNull) do
                    {/* es gibt Metadaten - welche sind es?*/
                        if (tag.Key.Equals("DateTimeDigitized", StringComparison.CurrentCultureIgnoreCase))
                            dtExifDigit = tag.Value.ToString();
                        else if (tag.Key.Equals("DateTimeOriginal", StringComparison.CurrentCultureIgnoreCase))
                            dtExifOrig = tag.Value.ToString();
                    } while (FreeImage.FindNextMetadata(mdh, out tag));

                FreeImage.FindCloseMetadata(mdh);
                return tag;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FreeImageAPI.Metadata.MetadataTag tag;
            FIBITMAP bm;
            if (!FreeImage.IsAvailable())
            {
                MessageBox.Show("FreeImage.dll seems to be missing. Aborting.");
                return;
            }
            lWarten.Visible = true;
            lWarten.Update();
            lFertig.Visible = false;
            lFertig.Update();
            if (Files != null) foreach (FileInfo bild in Files)
                {
                    string dtExifDigit = null, dtExifOrig = null, dtMain = null, Hersteller = null, Kamera = null;
                    bm = FreeImage.LoadEx(bild.FullName);
                    tag = Metadata1(ref bm, ref dtExifDigit, ref dtExifOrig);
                    MetaData2(ref tag, ref bm, ref dtMain, ref Hersteller, ref Kamera);
                    FreeImage.UnloadEx(ref bm);

                    fehler = (dtExifOrig == null);
                    if (fehler)
                    {
                        try
                        {
                            pb1.Load(bild.FullName); pb1.Update();
                        }
                        catch { }/* TODO das muss noch besser werden*/
                        finally
                        {

                            ffehler.DTDigit = dtExifDigit;
                            ffehler.DTOrig = dtExifOrig;
                            ffehler.DTMain = dtMain;
                            ffehler.Hersteller = Hersteller;
                            ffehler.Kamera = Kamera;
                            ffehler.Bild = pb1.Image;
                            ffehler.Datei = bild.FullName;
                        }
                        if (ffehler.ShowDialog() == DialogResult.Cancel) break;
                    }
                    else /* if (fehler)*/
                    {
                        Random rnd=new Random();
                        char[] del = new char[] { ':', '\0' };
                        string[] teile;
                        string name, neuname, neubasis, fullname, fullCR2name, pfad, ext, prfx, start, neufullname, neufullCR2name;
                        fullname = bild.FullName;
                        pfad = Path.GetDirectoryName(fullname);
                        ext = Path.GetExtension(fullname);
                        name = Path.GetFileNameWithoutExtension(fullname);
                        fullCR2name = pfad + "\\" + name + ".CR2";
                       
                        teile = dtExifOrig.Split(del);
                        if (String.CompareOrdinal(teile[0], "1900") > 0)
                        {
                            prfx = tbPrfix.Text.Trim();
                            if (prfx.Length > 0)
                                start = prfx + " ";
                            else
                                start = "";
                            neubasis = start + teile[0] + teile[1] + teile[2] + teile[3] + teile[4] + teile[5]; neuname = neubasis + "00";
                            neufullname = pfad + "\\" + neuname + ext;
                            while(File.Exists(neufullname))
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
                                    Directory.CreateDirectory(pfad + "\\RAW");
                                    File.Move(fullCR2name, neufullCR2name);
                                }
                            }
                        }
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

    private void tbName_Leave(object sender, EventArgs e)
        {
            Filter = tbName.Text;
            Props.vorgegebenerName = Filter;
            Props.Save();
            Files = Verzeichnisanzeige(Suchpfad, Filtern, Filter);
        }
    }
}