using System;
using System.Drawing;
using System.Windows.Forms;

namespace FotoNamen
{
  public partial class FFehler : Form
  {
    public FFehler()
    {
      InitializeComponent();
    }

    public string Artist { get; set; }
    public string DTDigit { get; set; }
    public string DTMain { get; set; }
    public string DTOrig { get; set; }
    public string Kamera { get; set; }
    /// <summary>
    /// der Hersteller
    /// </summary>
    public string Hersteller { get; set; }
    /// <summary>
    /// das Bild
    /// </summary>
    public Image Bild { get; set; }
    /// <summary>
    /// die Datei
    /// </summary>
    public string Datei { get; set; }

    private void fFehler_Shown(object sender, EventArgs e)
    {
      lDtMain.Text = DTMain;
      lDtOrig.Text = DTOrig;
      lDtDigit.Text = DTDigit;
      lHersteller.Text = Hersteller;
      lKamera.Text = $"{Kamera} von {Artist}";
      pb1.Image = Bild;
      lDatei.Text = Datei;
    }

  }
}
