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
    public partial class Protection : Form
    {
        string iniPath = NXAntivirus.iniPath;
        private const int MAX_RECURSIVE_CALLS = 1000;
        static int ctr = 0;
        NXAntivirus nx = new NXAntivirus();

     //   public List<Panel> listpanel = new List<Panel>();
        List<Button>listbutton = new List<Button>();
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
        public Protection()
        {
            InitializeComponent();
        }
        public void SendPanelsBack()
        {
            for (int i = 0; i < nx.listpanel.Count; i++)
            {
                nx.listpanel[i].SendToBack();
            }

        }

        public void RoundButton()
        {
            for (var i = 0; i < listbutton.Count; i++)
            {
                listbutton[i].Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button_virusprotection.Width, button_virusprotection.Height, 30, 30));
            }
        }
            public void loadbuttons()
        {
            listbutton.Add(button_virusprotection);
            listbutton.Add(button_scansettings);
            listbutton.Add(button_browsingprotection);
            listbutton.Add(button_safebanking);
            listbutton.Add(button_usbdriveprotection);
            listbutton.Add(button_externaldriveprotection);
            listbutton.Add(button_malwareprotection);
            listbutton.Add(button_antimalware);
        }

            private void panel_protection_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Execute()
        {
            ctr++;
            if (ctr % 50 == 0)
                Console.WriteLine("Call number {0} to the Execute method", ctr);

            if (ctr <= MAX_RECURSIVE_CALLS)
                Execute();

            ctr--;
        }
        public void button_virusprotection_Click(object sender, EventArgs e)
        {
            nx.SendPanelsBack();
           // listpanel[8].BringToFront();
          //  listpanel[9].BringToFront();
            nx.loadinternalpanels();
            nx.label_flowprotection.Text = "Virus Protection";
          //  nx.listinternalpanel[0].Visible = true;
        }
        private void setButtonImages()
        {
            button_virusprotection.Image = NXuisupport.Properties.Resources.virus;
            button_virusprotection.ImageAlign = ContentAlignment.TopCenter;

            button_scansettings.Image = NXuisupport.Properties.Resources.scansettings;
            button_scansettings.ImageAlign = ContentAlignment.TopCenter;

            button_browsingprotection.Image = NXuisupport.Properties.Resources.browserprotection;
            button_browsingprotection.ImageAlign = ContentAlignment.TopCenter;

            button_safebanking.Image = NXuisupport.Properties.Resources.safebanking;
            button_safebanking.ImageAlign = ContentAlignment.TopCenter;

            button_usbdriveprotection.Image = NXuisupport.Properties.Resources.usbprotection;
            button_usbdriveprotection.ImageAlign = ContentAlignment.TopCenter;

            button_malwareprotection.Image = NXuisupport.Properties.Resources.malwareprotection;
            button_malwareprotection.ImageAlign = ContentAlignment.TopCenter;

            button_antimalware.Image = NXuisupport.Properties.Resources.antimalware;
            button_antimalware.ImageAlign = ContentAlignment.TopCenter;

            button_externaldriveprotection.Image = NXuisupport.Properties.Resources.externaldrive;
            button_externaldriveprotection.ImageAlign = ContentAlignment.TopCenter;
        }

        private void setPanels()
        {
            listinternalpanel.Add(panel_protection1);
        }
            private void Protection_Load(object sender, EventArgs e)
        {
            loadbuttons();
            setButtonImages();
            RoundButton();
            setPanels();
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
            panel_protection1.BringToFront();

        
            string submenubutton = data["MyProg"]["submenubutton"];
            Color submenubuttons = System.Drawing.ColorTranslator.FromHtml(submenubutton);
           

            //listbutton[0].Visible = false;
            //listbutton[1].Visible = false;
            //listbutton[2].Visible = false;
            //listbutton[6].Visible = false;


            panel_protection1.BackColor = submenubuttons;
        }

        public void button_scansettings_Click(object sender, EventArgs e)
        {
            nx.SendPanelsBack();
         //   nx.listpanel[8].BringToFront();
         //   nx.listpanel[9].BringToFront();

            nx.label_flowprotection.Text = "Scan Settings";
            nx.loadinternalpanels();
            for (var i = 1; i <= 8; i++)
            {
             //   nx.listinternalpanel[i].Visible = true;
            }
        }

        private void button_browsingprotection_Click(object sender, EventArgs e)
        {
            nx.SendPanelsBack();
          //  nx.listpanel[8].BringToFront();
          //  nx.listpanel[9].BringToFront();

            nx.label_flowprotection.Text = "Browsing Protection";
            nx.loadinternalpanels();
            for (var i = 9; i == 9; i++)
            {
               // nx.listinternalpanel[i].Visible = true;
            }
        }

        private void button_safebanking_Click(object sender, EventArgs e)
        {
            nx.SendPanelsBack();
          //  nx.listpanel[8].BringToFront();
          //  nx.listpanel[9].BringToFront();

            nx.label_flowprotection.Text = "Safe Banking";
            nx.loadinternalpanels();

           // nx.listinternalpanel[11].Visible = true;
        }

        private void button_usbdriveprotection_Click(object sender, EventArgs e)
        {

        }

        private void button_malwareprotection_Click(object sender, EventArgs e)
        {
            nx.SendPanelsBack();
          //  nx.listpanel[8].BringToFront();
          //  nx.listpanel[9].BringToFront();

            nx.label_flowprotection.Text = "Malware Protection";
            nx.loadinternalpanels();

           // nx.listinternalpanel[14].Visible = true;
        }

        private void button_externaldriveprotection_Click(object sender, EventArgs e)
        {
            nx.SendPanelsBack();
           // nx.listpanel[8].BringToFront();
           // nx.listpanel[9].BringToFront();

            nx.label_flowprotection.Text = "External Drive Protection";
            nx.loadinternalpanels();
            for (var i = 12; i <= 13; i++)
            {
           //     nx.listinternalpanel[i].Visible = true;
            }
        }

        private void button_antimalware_Click(object sender, EventArgs e)
        {

        }
    }
}
