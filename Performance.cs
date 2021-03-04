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
    public partial class Performance : Form
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

            button_autosilentmode.Image = NXuisupport.Properties.Resources.autosilent;
            button_autosilentmode.ImageAlign = ContentAlignment.TopCenter;

            button_trackcleaner.Image = NXuisupport.Properties.Resources.cleaner;
            button_trackcleaner.ImageAlign = ContentAlignment.TopCenter;

            button_hijackrestore.Image = NXuisupport.Properties.Resources.hijackrestore;
            button_hijackrestore.ImageAlign = ContentAlignment.TopCenter;

            button_systemexplorer.Image = NXuisupport.Properties.Resources.systemexplorer;
            button_systemexplorer.ImageAlign = ContentAlignment.TopCenter;

            button_gamebooster.Image = NXuisupport.Properties.Resources.gamebooster;
            button_gamebooster.ImageAlign = ContentAlignment.TopCenter;
        }
        public void RoundButton()
        {
            for (var i = 0; i < listbutton.Count; i++)
            {
                listbutton[i].Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button_autosilentmode.Width, button_autosilentmode.Height, 30, 30));
            }
        }
        public void loadbuttons()
        {
            listbutton.Add(button_autosilentmode);
            listbutton.Add(button_trackcleaner);
            listbutton.Add(button_hijackrestore);
            listbutton.Add(button_systemexplorer);
            listbutton.Add(button_gamebooster);
            listbutton.Add(button_trackcleaner);
        }
        public Performance()
        {
            InitializeComponent();
        }

        private void Performance_Load(object sender, EventArgs e)
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
            panel_performance.BringToFront();


            string submenubutton = data["MyProg"]["submenubutton"];
            Color submenubuttons = System.Drawing.ColorTranslator.FromHtml(submenubutton);

            panel_performance.BackColor = submenubuttons;

            
        }
    }
}
