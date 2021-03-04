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
    public partial class Privacy : Form
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
            
            button_databackup.Image = NXuisupport.Properties.Resources.databackup;
            button_databackup.ImageAlign = ContentAlignment.TopCenter;

            button_managebackup.Image = NXuisupport.Properties.Resources.managebackup;
            button_managebackup.ImageAlign = ContentAlignment.TopCenter;

            button_restorebackup.Image = NXuisupport.Properties.Resources.restore;
            button_restorebackup.ImageAlign = ContentAlignment.TopCenter;

            button_filevault.Image = NXuisupport.Properties.Resources.filevault;
            button_filevault.ImageAlign = ContentAlignment.TopCenter;

            button_screenlocker.Image = NXuisupport.Properties.Resources.screenlock;
            button_screenlocker.ImageAlign = ContentAlignment.TopCenter;

            button_datatheftprotection.Image = NXuisupport.Properties.Resources.data_theft;
            button_datatheftprotection.ImageAlign = ContentAlignment.TopCenter;

            button_antikeylogger.Image = NXuisupport.Properties.Resources.keylogger;
            button_antikeylogger.ImageAlign = ContentAlignment.TopCenter;

            button_webcamprotection.Image = NXuisupport.Properties.Resources.webcam;
            button_webcamprotection.ImageAlign = ContentAlignment.TopCenter;

            button_wifiscanner.Image = NXuisupport.Properties.Resources.wifi;
            button_wifiscanner.ImageAlign = ContentAlignment.TopCenter;

            button_parentalcontrol.Image = NXuisupport.Properties.Resources.parental_control;
            button_parentalcontrol.ImageAlign = ContentAlignment.TopCenter;

            button_registryrestore.Image = NXuisupport.Properties.Resources.registry;
            button_registryrestore.ImageAlign = ContentAlignment.TopCenter;
        }
            public void RoundButton()
        {
            for (var i = 0; i < listbutton.Count; i++)
            {
                listbutton[i].Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button_databackup.Width, button_databackup.Height, 30, 30));
            }
        }
        public void loadbuttons()
        {
            listbutton.Add(button_databackup);
            listbutton.Add(button_managebackup);
            listbutton.Add(button_restorebackup);
            listbutton.Add(button_filevault);
            listbutton.Add(button_parentalcontrol);
            listbutton.Add(button_webcamprotection);
            listbutton.Add(button_registryrestore);
            listbutton.Add(button_datatheftprotection);
            listbutton.Add(button_wifiscanner);
            listbutton.Add(button_screenlocker);
            listbutton.Add(button_antikeylogger);
        }
        public Privacy()
        {
            InitializeComponent();
        }

        private void panel_privacy_Load(object sender, EventArgs e)
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
            panel_privacy1.BringToFront();


            string submenubutton = data["MyProg"]["submenubutton"];
            Color submenubuttons = System.Drawing.ColorTranslator.FromHtml(submenubutton);

            panel_privacy1.BackColor = submenubuttons;

        }

        private void panel_privacy1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
