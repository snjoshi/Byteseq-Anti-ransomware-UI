using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using NXuisupport;
using System.Drawing.Imaging;

namespace NetluxUI
{
    public partial class Settings : Form
    {
        string iniPath = NXAntivirus.iniPath;
    private const int MAX_RECURSIVE_CALLS = 1000;
    static int ctr = 0;
    NXAntivirus nx = new NXAntivirus();

    //   public List<Panel> listpanel = new List<Panel>();
    List<Button> listbutton = new List<Button>();
    List<Panel> listinternalpanel = new List<Panel>();

    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    public static extern IntPtr CreateRoundRectRgn
        (
            int nLeft,
            int nTop,
            int nRight,
            int nWidthEllipse,
            int nBottom,
            int nHeightEllipse
        );
    public void SendPanelsBack()
    {
        for (int i = 0; i < nx.listpanel.Count; i++)
        {
            nx.listpanel[i].SendToBack();
        }

    }

    private void setButtonImages()
    {
            button_automaticupdate.Image = NXuisupport.Properties.Resources.automaticupdate;
            button_automaticupdate.ImageAlign = ContentAlignment.TopCenter;

            button_viewquarantinefiles.Image = NXuisupport.Properties.Resources.quarantine;
            button_viewquarantinefiles.ImageAlign = ContentAlignment.TopCenter;



            button_reportsettings.Image = NXuisupport.Properties.Resources.reportsettings;
            button_reportsettings.ImageAlign = ContentAlignment.TopCenter;

            button_reportvirusstatistics.Image = NXuisupport.Properties.Resources.reportvirus;
            button_reportvirusstatistics.ImageAlign = ContentAlignment.TopCenter;

            button_restoredefaultsettings.Image = NXuisupport.Properties.Resources.restoredefaults;
            button_restoredefaultsettings.ImageAlign = ContentAlignment.TopCenter;

            button_passwordprotection.Image = NXuisupport.Properties.Resources.passwordprotection;
            button_passwordprotection.ImageAlign = ContentAlignment.TopCenter;

            button_selfprotection.Image = NXuisupport.Properties.Resources.selfprotection;
            button_selfprotection.ImageAlign = ContentAlignment.TopCenter;

            button_createemergency.Image = NXuisupport.Properties.Resources.emergencydisk;
            button_createemergency.ImageAlign = ContentAlignment.TopCenter;
        }
    public void RoundButton()
    {
        for (var i = 0; i < listbutton.Count; i++)
        {
            listbutton[i].Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button_automaticupdate.Width, button_automaticupdate.Height, 30, 30));
        }
    }
    public void loadbuttons()
    {
            listbutton.Add(button_automaticupdate);
            listbutton.Add(button_viewquarantinefiles);
            listbutton.Add(button_reportsettings);
            listbutton.Add(button_reportvirusstatistics);
            listbutton.Add(button_restoredefaultsettings);
            listbutton.Add(button_passwordprotection);
            listbutton.Add(button_selfprotection);
            listbutton.Add(button_createemergency);
        }
  
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            loadbuttons();
            setButtonImages();
            RoundButton();
            // setPanels();
            nx.loadinternalpanels();
            nx.loadallprimarypanels();
            //  nx.setButtonImages();
            nx.SendPanelsBack();


            var parser = new FileIniDataParser();

            IniData data = parser.ReadFile(iniPath);

            string submenubuttonborder = data["MyProg"]["submenubuttonborder"];

            Color submenubuttonbordercolour = System.Drawing.ColorTranslator.FromHtml(submenubuttonborder);
            for (var i = 0; i < listbutton.Count; i++)
            {
                listbutton[i].FlatAppearance.BorderColor = submenubuttonbordercolour;
                listbutton[i].BackColor = submenubuttonbordercolour;
                listbutton[i].Padding = new Padding(0, 5, 0, 0);
                listbutton[i].Font = new Font("Microsoft Sans Serif", 12);

            }

            nx.listpanel[3].BringToFront();
            panel_settings.BringToFront();


            string submenubutton = data["MyProg"]["submenubutton"];
            Color submenubuttons = System.Drawing.ColorTranslator.FromHtml(submenubutton);

            panel_settings.BackColor = submenubuttons;
        }
    }
}
