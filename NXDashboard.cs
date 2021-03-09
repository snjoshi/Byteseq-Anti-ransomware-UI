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
    public partial class NXAntivirus : Form
        
    {
        public static int x = 0;
        public static string iniPath = "F:\\nxui.ini";
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        static int flag_virusprotection = 1;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
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
        // private object parser;
        public List<Panel> listpanel = new List<Panel>();
        List<Button>listbutton = new List<Button>();
        List<Panel> listinternalpanel = new List<Panel>();
      //  Protection protection;


        public NXAntivirus()
        {
            InitializeComponent();
            this.CenterToScreen();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
        }

        private void setsidepanelbutton()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(iniPath);
            string sidepanelbutton = data["MyProg"]["hamburgerpanel"];
            Color sidepanelbuttoncolour = System.Drawing.ColorTranslator.FromHtml(sidepanelbutton);
            button_status.BackColor = sidepanelbuttoncolour;
            button_protection.BackColor = sidepanelbuttoncolour;
            button_privacy.BackColor = sidepanelbuttoncolour;
            button_performance.BackColor = sidepanelbuttoncolour;
            button_settings.BackColor = sidepanelbuttoncolour;

        }
        

        public void SendPanelsBack()
        {
            for (int i = 0; i < listpanel.Count; i++)
            {
                listpanel[i].SendToBack();
            }

        }
       

        public void loadinternalpanels()
        {
            //virusprotection 0
            listinternalpanel.Add(panel_subvirusprotection);
            //scan settings 1-8
            listinternalpanel.Add(panel_subscansettings);
            listinternalpanel.Add(panel_subadvancednascan);
            listinternalpanel.Add(panel_subblocksuspiciousfiles);
            listinternalpanel.Add(panel_subautomaticroguewarescan);
            listinternalpanel.Add(panel_subscanschedule);
            listinternalpanel.Add(panel_subexcludefiles);
            listinternalpanel.Add(panel_subquarantine);
            listinternalpanel.Add(panel_subexcludeext);
            //browsing protection 9
            listinternalpanel.Add(panel_subbrowsingprotection);
            //phishing protection 10
            listinternalpanel.Add(panel_subphishingprotection);
            //safe banking 11
            listinternalpanel.Add(panel_subsafebanking);
            //external drive protection 12-13
            listinternalpanel.Add(panel_subautorunprotection);
            listinternalpanel.Add(panel_subscanexternaldrives);
            //malware protection 14
            listinternalpanel.Add(panel_submalwareprotection);
            //data backup 15
            listinternalpanel.Add(panel_subdatabackup);
            //manage backup 16
            listinternalpanel.Add(panel_submanagebackup);
            //restore backup 17
            listinternalpanel.Add(panel_subrestorebackup);
            //webcam protection 18
            listinternalpanel.Add(panel_subwebcamprotection);
            //registry restore 19
            listinternalpanel.Add(panel_subregistryrestore);
            //data theft protection 20
            listinternalpanel.Add(panel_subdatatheftprotection);
            //screenlockwer 21
            listinternalpanel.Add(panel_subscreenlocker);
            //anti keylogger 22
            listinternalpanel.Add(panel_subantikeylogger);

            for (var i = 0; i < listinternalpanel.Count; i++)
            {
                listinternalpanel[i].Visible = false;
            }

        }

        public void loadallprimarypanels()
        {   //0
            listpanel.Add(panel_Main);
            listpanel.Add(panel_Main2);
            listpanel.Add(panel_Secure);

            //3
            listpanel.Add(panel_submenu);
            listpanel.Add(panel_internalmenu);

            //5
            listpanel.Add(panel_internalflowprotection);
            listpanel.Add(panel_internalflowprivacy);
           //7
            listpanel.Add(panel_base);
            listpanel.Add(panel_userbase);
            listpanel.Add(panel_activationwindow);

            //10
             listpanel.Add(panel_activationheader);
            
        }
        private PictureBox pb;

        private void RoundButton()
        {
            button_ScanNow.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button_ScanNow.Width, button_ScanNow.Height, 30, 30));
            button_scanoptions.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button_scanoptions.Width, button_scanoptions.Height, 30, 30));
            button_pctuner.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button_scanoptions.Width, button_scanoptions.Height, 30, 30));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 30, 30));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 30, 30));
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 30, 30));
        }
        private void SetColours()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(iniPath);
            string hamburgerpanel = data["MyProg"]["hamburgerpanel"];
            string panelfront = data["MyProg"]["panelfront"];
            string scannowButton = data["MyProg"]["scannowbutton"];
            string label_update = data["Label"]["label_dbupdate"];
            string copyright = data["Label"]["label_copyright"];
            string productname = data["Label"]["label_product"];
            string submenubutton = data["MyProg"]["submenubutton"];
            string submenubuttonborder = data["MyProg"]["submenubuttonborder"];
            //  string submenu= data["MyProg"]["panelsubmenu"];

            Color myColor = System.Drawing.ColorTranslator.FromHtml(hamburgerpanel);
            panel_SideButtons.BackColor = myColor;
            button_status.FlatAppearance.BorderColor = myColor;
            button_protection.FlatAppearance.BorderColor = myColor;
            button_privacy.FlatAppearance.BorderColor = myColor;
            button_performance.FlatAppearance.BorderColor = myColor;
            button_settings.FlatAppearance.BorderColor = myColor;
            //button6.FlatAppearance.BorderColor = myColor;



            Color panelfrontcolour = System.Drawing.ColorTranslator.FromHtml(panelfront);
            panel_Main.BackColor = panelfrontcolour;
            panel_Main2.BackColor = panelfrontcolour;

            Color scannowButtoncolour = System.Drawing.ColorTranslator.FromHtml(scannowButton);
            button_ScanNow.BackColor = scannowButtoncolour;
            button_ScanNow.FlatAppearance.BorderColor = scannowButtoncolour;

            //  Color panelsubmenu = System.Drawing.ColorTranslator.FromHtml(submenu);
            //  panel_protection.BackColor = panelsubmenu;
            Color submenubuttons = System.Drawing.ColorTranslator.FromHtml(submenubutton);
            setsidepanelbutton();
            button_status.BackColor = submenubuttons;


            Color submenubuttonbordercolour = System.Drawing.ColorTranslator.FromHtml(submenubuttonborder);


            for (var i = 0; i < listbutton.Count; i++)
            {
                listbutton[i].FlatAppearance.BorderColor = submenubuttonbordercolour;
                listbutton[i].BackColor = submenubuttonbordercolour;
                listbutton[i].Padding = new Padding(0, 5, 0, 0);
                listbutton[i].Font = new Font("Microsoft Sans Serif", 12);

            }
            //set labels
            label_dbupdate.Text = label_update;
            label_copyright.Text = copyright;
            label_header.Text = productname;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           //Protection protection = new Protection();
           // protection.Execute();
          //  Console.WriteLine("\nThe call counter: {0}", ctr);


            setButtonImages();
            //pb = new PictureBox();
            //panel_base.Controls.Add(pb);
            //pb.Dock = DockStyle.Fill;

          //  loadbuttons();
            loadinternalpanels();
            loadallprimarypanels();
            pictureBox_userimage.Image = NXuisupport.Properties.Resources.user;
            //add panels;


            RoundButton();
            SetColours();
           // panel_SideButtons.Region= Region.FromHrgn(CreateRoundRectRgn(0, 0, panel_SideButtons.Width,panel_SideButtons.Height, 80, 100));
           //var MyIni = new IniFile(@"C:\\Users\\hp\\source\\repos\\NetluxUI\\nxui.ini");




            
            SendPanelsBack();

            panel_base.BringToFront();
            panel_activationheader.BringToFront();
            panel_activationwindow.BringToFront();

            

        }


        private void panel_SideButtons_Paint(object sender, PaintEventArgs e)
        {
                  
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Main2_Paint(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void label_copyright_Click(object sender, EventArgs e)
        {

        }

        private void button_status_Click(object sender, EventArgs e)
        {
            SendPanelsBack();

            listpanel[0].BringToFront();   
            listpanel[1].BringToFront();
            listpanel[2].BringToFront();
            setsidepanelbutton();

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(iniPath);
            string submenubutton = data["MyProg"]["submenubutton"];
            Color submenubuttons = System.Drawing.ColorTranslator.FromHtml(submenubutton);
            string sidepanel = data["MyProg"]["panelfront"];
            Color sidepanelcolour = System.Drawing.ColorTranslator.FromHtml(sidepanel);
            button_status.BackColor = submenubuttons;
            panel_SideButtons.BackgroundImage = NXuisupport.Properties.Resources.TTBTaskbar_white;

        }
        private void setButtonImages()
        {
            //protection.button_virusprotection.Image = NXuisupport.Properties.Resources.virus;
            //protection.button_virusprotection.ImageAlign = ContentAlignment.TopCenter;

            //protection.button_scansettings.Image = NXuisupport.Properties.Resources.scansettings;
            //protection.button_scansettings.ImageAlign = ContentAlignment.TopCenter;

            //protection.button_browsingprotection.Image = NXuisupport.Properties.Resources.browserprotection;
            //protection.button_browsingprotection.ImageAlign = ContentAlignment.TopCenter;

            //protection.button_safebanking.Image = NXuisupport.Properties.Resources.safebanking;
            //protection.button_safebanking.ImageAlign = ContentAlignment.TopCenter;

            //protection.button_usbdriveprotection.Image = NXuisupport.Properties.Resources.usbprotection;
            //protection.button_usbdriveprotection.ImageAlign = ContentAlignment.TopCenter;

            //protection.button_malwareprotection.Image = NXuisupport.Properties.Resources.malwareprotection;
            //protection.button_malwareprotection.ImageAlign = ContentAlignment.TopCenter;

            //protection.button_antimalware.Image = NXuisupport.Properties.Resources.antimalware;
            //protection.button_antimalware.ImageAlign = ContentAlignment.TopCenter;

            //protection.button_externaldriveprotection.Image = NXuisupport.Properties.Resources.externaldrive;
            //protection.button_externaldriveprotection.ImageAlign = ContentAlignment.TopCenter;

            //button_databackup.Image = NXuisupport.Properties.Resources.databackup;
            //button_databackup.ImageAlign = ContentAlignment.TopCenter;

            //button_managebackup.Image = NXuisupport.Properties.Resources.managebackup;
            //button_managebackup.ImageAlign = ContentAlignment.TopCenter;

            //button_restorebackup.Image = NXuisupport.Properties.Resources.restore;
            //button_restorebackup.ImageAlign = ContentAlignment.TopCenter;

            //button_filevault.Image = NXuisupport.Properties.Resources.filevault;
            //button_filevault.ImageAlign = ContentAlignment.TopCenter;

            //button_screenlocker.Image = NXuisupport.Properties.Resources.screenlock;
            //button_screenlocker.ImageAlign = ContentAlignment.TopCenter;

            //button_datatheftprotection.Image = NXuisupport.Properties.Resources.data_theft;
            //button_datatheftprotection.ImageAlign = ContentAlignment.TopCenter;

            //button_antikeylogger.Image = NXuisupport.Properties.Resources.keylogger;
            //button_antikeylogger.ImageAlign = ContentAlignment.TopCenter;

            //button_webcamprotection.Image = NXuisupport.Properties.Resources.webcam;
            //button_webcamprotection.ImageAlign = ContentAlignment.TopCenter;


            //button_wifiscanner.Image = NXuisupport.Properties.Resources.wifi;
            //button_wifiscanner.ImageAlign = ContentAlignment.TopCenter;

            //button_parentalcontrol.Image = NXuisupport.Properties.Resources.parental_control;
            //button_parentalcontrol.ImageAlign = ContentAlignment.TopCenter;

            //button_registryrestore.Image = NXuisupport.Properties.Resources.registry;
            //button_registryrestore.ImageAlign = ContentAlignment.TopCenter;

            //button_autosilentmode.Image = NXuisupport.Properties.Resources.autosilent;
            //button_autosilentmode.ImageAlign = ContentAlignment.TopCenter;

            //button_trackcleaner.Image = NXuisupport.Properties.Resources.cleaner;
            //button_trackcleaner.ImageAlign = ContentAlignment.TopCenter;

            //button_hijackrestore.Image = NXuisupport.Properties.Resources.hijackrestore;
            //button_hijackrestore.ImageAlign = ContentAlignment.TopCenter;

            //button_systemexplorer.Image = NXuisupport.Properties.Resources.systemexplorer;
            //button_systemexplorer.ImageAlign = ContentAlignment.TopCenter;

            //button_gamebooster.Image = NXuisupport.Properties.Resources.gamebooster;
            //button_gamebooster.ImageAlign = ContentAlignment.TopCenter;

            //button_automaticupdate.Image = NXuisupport.Properties.Resources.automaticupdate;
            //button_automaticupdate.ImageAlign = ContentAlignment.TopCenter;

            //button_viewquarantinefiles.Image = NXuisupport.Properties.Resources.quarantine;
            //button_viewquarantinefiles.ImageAlign = ContentAlignment.TopCenter;

            

            //button_reportsettings.Image = NXuisupport.Properties.Resources.reportsettings;
            //button_reportsettings.ImageAlign = ContentAlignment.TopCenter;

            //button_reportvirusstatistics.Image = NXuisupport.Properties.Resources.reportvirus;
            //button_reportvirusstatistics.ImageAlign = ContentAlignment.TopCenter;

            //button_restoredefaultsettings.Image = NXuisupport.Properties.Resources.restoredefaults;
            //button_restoredefaultsettings.ImageAlign = ContentAlignment.TopCenter;

            //button_passwordprotection.Image = NXuisupport.Properties.Resources.passwordprotection;
            //button_passwordprotection.ImageAlign = ContentAlignment.TopCenter;

            //button_selfprotection.Image = NXuisupport.Properties.Resources.selfprotection;
            //button_selfprotection.ImageAlign = ContentAlignment.TopCenter;

            //button_createemergency.Image = NXuisupport.Properties.Resources.emergencydisk;
            //button_createemergency.ImageAlign = ContentAlignment.TopCenter;
        }

        private void button_protection_Click(object sender, EventArgs e)
        {
            formclose();
            SendPanelsBack();
            //  setButtonImages();
            listpanel[0].BringToFront();
            listpanel[3].BringToFront();
          //  listpanel[4].BringToFront();
            setsidepanelbutton();

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(iniPath);
            string submenubutton = data["MyProg"]["submenubutton"];
            Color submenubuttons = System.Drawing.ColorTranslator.FromHtml(submenubutton);
            button_protection.BackColor = submenubuttons;

            //listbutton[0].Visible = false;
            //listbutton[1].Visible = false;
            //listbutton[2].Visible = false;
            //listbutton[6].Visible = false;


            // listpanel[4].BackColor = submenubuttons;
            listpanel[3].Controls.Clear();
            // panel_SideButtons.BackColor = submenubuttons;
            panel_SideButtons.BackgroundImage = NXuisupport.Properties.Resources.TTBTaskbar_black;
            listpanel[3].BackColor = submenubuttons;
            Protection protection = new Protection();
            protection.TopLevel = false;
            protection.AutoScroll = true;
            listpanel[3].Controls.Add(protection);
            protection.Show();


        }

        private void panel_protection_Paint(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
            //this.BackColor = Color.Black;
            //panel_protection.Visible = true;

        }

        private void panel_protection_Paint_1(object sender, PaintEventArgs e)
        {
         //   this.BackColor = Color.Black;
        }

        private void button_virusprotection_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[9].BringToFront();
            loadinternalpanels();
            label_flowprotection.Text = "Virus Protection";
            listinternalpanel[0].Visible = true;
           
        }

        private void button_scansettings_Click(object sender, EventArgs e)
        {

            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[9].BringToFront();

            label_flowprotection.Text = "Scan Settings";
            loadinternalpanels();
            for (var i = 1; i <= 8; i++)
            {
                listinternalpanel[i].Visible = true;
            }
        }

        private void button_privacy_Click(object sender, EventArgs e)
        {
            formclose();
            SendPanelsBack();

            listpanel[0].BringToFront();
            listpanel[3].BringToFront();
          //  listpanel[5].BringToFront();
            setsidepanelbutton();
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(iniPath);
            string submenubutton = data["MyProg"]["submenubutton"];
            Color submenubuttons = System.Drawing.ColorTranslator.FromHtml(submenubutton);
            button_privacy.BackColor = submenubuttons;
            panel_SideButtons.BackgroundImage = NXuisupport.Properties.Resources.TTBTaskbar_black;

            listpanel[3].Controls.Clear();
            Privacy Privacy = new Privacy();
            Privacy.TopLevel = false;
            Privacy.AutoScroll = true;
            listpanel[3].Controls.Add(Privacy);
            Privacy.Show();


            listpanel[4].BackColor = submenubuttons;
            listpanel[3].BackColor = submenubuttons;
        }

        private void button_performance_Click(object sender, EventArgs e)
        {
            formclose();
            SendPanelsBack();
            listpanel[0].BringToFront();
            listpanel[3].BringToFront();
          //  listpanel[6].BringToFront();
            setsidepanelbutton();
          
            
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(iniPath);
            string submenubutton = data["MyProg"]["submenubutton"];
            Color submenubuttons = System.Drawing.ColorTranslator.FromHtml(submenubutton);
            button_performance.BackColor = submenubuttons;
            panel_SideButtons.BackgroundImage = NXuisupport.Properties.Resources.TTBTaskbar_black;

            listpanel[3].Controls.Clear();
            Performance performance = new Performance();
            performance.TopLevel = false;
            performance.AutoScroll = true;
            listpanel[3].Controls.Add(performance);
            performance.Show();

            listpanel[4].BackColor = submenubuttons;
            listpanel[3].BackColor = submenubuttons;
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            formclose();
            SendPanelsBack();
            listpanel[0].BringToFront();
            listpanel[3].BringToFront();
          //  listpanel[7].BringToFront();
            setsidepanelbutton();
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(iniPath);
            string submenubutton = data["MyProg"]["submenubutton"];
            Color submenubuttons = System.Drawing.ColorTranslator.FromHtml(submenubutton);
            button_settings.BackColor = submenubuttons;
            panel_SideButtons.BackgroundImage = NXuisupport.Properties.Resources.TTBTaskbar_black;

            listpanel[3].Controls.Clear();
            Settings settings = new Settings();
            settings.TopLevel = false;
            settings.AutoScroll = true;
            listpanel[3].Controls.Add(settings);
            settings.Show();

            listpanel[4].BackColor = submenubuttons;
            listpanel[3].BackColor = submenubuttons;
        }

        private void formclose()
        {
            //Protection protection = new Protection();
            //Privacy privacy = new Privacy();
            //Settings settings = new Settings();
            //Performance performance = new Performance();

            //protection.Close();
            //privacy.Close();
            //settings.Close();
            //performance.Close();

            //protection.Dispose();
            //privacy.Dispose();
            //settings.Dispose();
            //performance.Dispose();
        }

        private void panel_privacy_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_performance_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Secure_Paint(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void panel_settings_Paint(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void panel_performance_Paint_1(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void panel_privacy_Paint_1(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void panel_protection_Paint_2(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void button_browsingprotection_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[9].BringToFront();

            label_flowprotection.Text = "Browsing Protection";
            loadinternalpanels();
            for (var i = 9; i == 9; i++)
            {
                listinternalpanel[i].Visible = true;
            }
        }

        private void button_safebanking_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[9].BringToFront();

            label_flowprotection.Text = "Safe Banking";
            loadinternalpanels();
            
            listinternalpanel[11].Visible = true;
            
        }

        private void button_usbdriveprotection_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void button_malwareprotection_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[9].BringToFront();

            label_flowprotection.Text = "Malware Protection";
            loadinternalpanels();

            listinternalpanel[14].Visible = true;
        }

        private void button_externaldriveprotection_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[9].BringToFront();

            label_flowprotection.Text = "External Drive Protection";
            loadinternalpanels();
            for (var i = 12; i <= 13; i++)
            {
                listinternalpanel[i].Visible = true;
            }
        }

        private void button_antimalware_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void button_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
       
       

        private void panel_top_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }

        private void panel_top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_back_Click(object sender, EventArgs e)
        {

        }

        private void button_togglevirusprotection_Click(object sender, EventArgs e)
        {
            if (flag_virusprotection == 1)
                flag_virusprotection = 0;
            else
                flag_virusprotection = 1;

            if (flag_virusprotection==1)
            {
                button_togglevirusprotection.BackgroundImage = Properties.Resources.togglebutton_on;

            }
            else 
            {
                button_togglevirusprotection.BackgroundImage = Properties.Resources.togglebutton_off;

            }
        }

        private void panel_internalmenu_Paint(object sender, PaintEventArgs e)
        {
                  
        }

        private void button_togglescanexternaldrives_Click(object sender, EventArgs e)
        {

        }

        private void button_databackup_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[10].BringToFront();

            label_flowprotection.Text = "Data Backup";
            loadinternalpanels();

            listinternalpanel[15].Visible = true;
        }

        private void button_managebackup_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[10].BringToFront();

            label_flowprotection.Text = "Manage Backup";
            loadinternalpanels();

            listinternalpanel[16].Visible = true;
        }

        private void button_restorebackup_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[10].BringToFront();

            label_flowprotection.Text = "Restore Backup";
            loadinternalpanels();

            listinternalpanel[17].Visible = true;
        }

        private void button_webcamprotection_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[10].BringToFront();

            label_flowprotection.Text = "Webcam Protection";
            loadinternalpanels();

            listinternalpanel[18].Visible = true;
        }

        private void button_registryrestore_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[10].BringToFront();

            label_flowprotection.Text = "Registry Restore";
            loadinternalpanels();

            listinternalpanel[19].Visible = true;
        }

        private void button_datatheftprotection_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[10].BringToFront();

            label_flowprotection.Text = "Data Theft Protection";
            loadinternalpanels();

            listinternalpanel[20].Visible = true;
        }

        private void button_screenlocker_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[10].BringToFront();

            label_flowprotection.Text = "Screen Locker Protection";
            loadinternalpanels();

            listinternalpanel[21].Visible = true;
        }

        private void button_antikeylogger_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[8].BringToFront();
            listpanel[10].BringToFront();

            label_flowprotection.Text = "Anti-Keylogger";
            loadinternalpanels();

            listinternalpanel[22].Visible = true;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel_activationwindow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_activationheader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label_nocodedata_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel_activatetrial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SendPanelsBack();
            listpanel[13].BringToFront();
            listpanel[14].BringToFront();
            listpanel[15].BringToFront();
        }

        private void label_activationheader_Click(object sender, EventArgs e)
        {

        }

        private void panel_activationwindow_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox_actkey1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox_actkey4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label_noactivationcode_Click(object sender, EventArgs e)
        {

        }

        private void label_entercode_Click(object sender, EventArgs e)
        {

        }

        private void groupBox_enterproductkey_Enter(object sender, EventArgs e)
        {

        }

        private void label_activationformat_Click(object sender, EventArgs e)
        {

        }

        private void button_activate_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            listpanel[13].BringToFront();
            listpanel[14].BringToFront();
            listpanel[15].BringToFront();
        }

        private void label_filldata_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_underscore_Click(object sender, EventArgs e)
        {

        }

        private void panel_userinfoheader_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linearGradientBrush =
   new LinearGradientBrush(panel4.ClientRectangle, Color.Red, Color.Yellow, 45);

            ColorBlend cblend = new ColorBlend(3);
            cblend.Colors = new Color[3] { Color.Olive, Color.LightGreen, Color.Green };
            cblend.Positions = new float[3] { 0f, 0.5f, 1f };

            linearGradientBrush.InterpolationColors = cblend;

            e.Graphics.FillRectangle(linearGradientBrush, panel4.ClientRectangle);
        }

        private void label_contactno_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_userimage_Click(object sender, EventArgs e)
        {
            
        }

        private void button_userinfocancel_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            //panel_userinfo.SendToBack();
            //panel_activationheading.BringToFront();
            //panel_activationwindow.BringToFront();
        }
        private void Blur()
        {
            Bitmap bmp = Screenshot.TakeSnapshot(panel_base);
            BitmapFilter.GaussianBlur(bmp, 4);

            pb.Image = bmp;
            pb.BringToFront();
        }

        private void UnBlur()
        {
            pb.Image = null;
            pb.SendToBack();
        }

        private void button_userinfosubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Activation Successful");
            SendPanelsBack();
            listpanel[0].BringToFront();
            listpanel[1].BringToFront();
            listpanel[2].BringToFront();
        }

        private void label_welcome_Click(object sender, EventArgs e)
        {

        }

        private void label_Secure_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_pctuner_Click(object sender, EventArgs e)
        {

        }

        private void panel_form_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_activate_Click_1(object sender, EventArgs e)
        {
            SendPanelsBack();
            panel_base.BringToFront();
            panel_userbase.BringToFront();
        }

        private void pictureBox_userimage_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_actkey1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox_actkey1.TextLength == textBox_actkey1.MaxLength) textBox_actkey2.Focus();
        }

        private void textBox_actkey2_TextChanged(object sender, EventArgs e)
        {
            if (textBox_actkey2.TextLength == textBox_actkey2.MaxLength) textBox_actkey3.Focus();
        }

        private void textBox_actkey3_TextChanged(object sender, EventArgs e)
        {
            if (textBox_actkey3.TextLength == textBox_actkey3.MaxLength) textBox_actkey4.Focus();
        }

        private void button_userinfosubmit_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Activation Successful");
            listpanel[0].BringToFront();
            listpanel[1].BringToFront();
            listpanel[2].BringToFront();
            panel_SideButtons.BringToFront();

        }

        private void button_userinfocancel_Click_1(object sender, EventArgs e)
        {
            SendPanelsBack();
            panel_base.BringToFront();
            panel_activationheading.BringToFront();
            panel_activationwindow.BringToFront();
        }
    }
    public class BitmapFilter
    {
        private static bool Conv3x3(Bitmap b, ConvMatrix m)
        {
            // Avoid divide by zero errors
            if (0 == m.Factor) return false;

            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = stride + 6 - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopMid) + (pSrc[8] * m.TopRight) +
                            (pSrc[2 + stride] * m.MidLeft) + (pSrc[5 + stride] * m.Pixel) + (pSrc[8 + stride] * m.MidRight) +
                            (pSrc[2 + stride2] * m.BottomLeft) + (pSrc[5 + stride2] * m.BottomMid) + (pSrc[8 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[5 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopMid) + (pSrc[7] * m.TopRight) +
                            (pSrc[1 + stride] * m.MidLeft) + (pSrc[4 + stride] * m.Pixel) + (pSrc[7 + stride] * m.MidRight) +
                            (pSrc[1 + stride2] * m.BottomLeft) + (pSrc[4 + stride2] * m.BottomMid) + (pSrc[7 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[4 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopMid) + (pSrc[6] * m.TopRight) +
                            (pSrc[0 + stride] * m.MidLeft) + (pSrc[3 + stride] * m.Pixel) + (pSrc[6 + stride] * m.MidRight) +
                            (pSrc[0 + stride2] * m.BottomLeft) + (pSrc[3 + stride2] * m.BottomMid) + (pSrc[6 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[3 + stride] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }

                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }

        public static bool GaussianBlur(Bitmap b, int nWeight /* default to 4*/)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 2;
            m.Factor = nWeight + 12;

            return BitmapFilter.Conv3x3(b, m);
        }

        public class ConvMatrix
        {
            public int TopLeft = 0, TopMid = 0, TopRight = 0;
            public int MidLeft = 0, Pixel = 1, MidRight = 0;
            public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
            public int Factor = 1;
            public int Offset = 0;
            public void SetAll(int nVal)
            {
                TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
            }
        }
    }

    class Screenshot
    {
        public static Bitmap TakeSnapshot(Control ctl)
        {
            Bitmap bmp = new Bitmap(ctl.Size.Width, ctl.Size.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
            g.CopyFromScreen(ctl.PointToScreen(ctl.ClientRectangle.Location), new Point(0, 0), ctl.ClientRectangle.Size);
            return bmp;
        }
    }
}

