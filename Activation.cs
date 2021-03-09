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
    public partial class Activation : Form
    {
        NXAntivirus nx = new NXAntivirus();
        string iniPath = NXAntivirus.iniPath;
        List<Panel> listpanel = new List<Panel>();
        public Activation()
        {
            InitializeComponent();
        }
        public void Listallpanels()
        {
            listpanel.Add(panel_activationwindow);
            listpanel.Add(panel_userinfo);
            listpanel.Add(panel_userinfoheader);
            listpanel.Add(panel_userbase);

        }
        public void SendPanelsBack()
        {
            for (int i = 0; i < listpanel.Count; i++)
            {
                listpanel[i].SendToBack();
            }

        }
        private void button_activate_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            panel_userbase.BringToFront();
            //listpanel[2].BringToFront();
            //listpanel[15].BringToFront();
        }

        private void textBox_actkey1_TextChanged(object sender, EventArgs e)
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

        private void textBox_actkey4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_userinfosubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Activation Successful");
            NXAntivirus.x = 1;
            this.Close();
            this.Dispose();
            Application.Restart();
            
            //this.Hide();
            
            //Environment.Exit(1);
           // nx.Show();
            //nx.listpanel[0].BringToFront();
            //nx.listpanel[1].BringToFront();
            //nx.listpanel[2].BringToFront();

        }

        private void Activation_Load(object sender, EventArgs e)
        {
            Listallpanels();
            SendPanelsBack();

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(iniPath);
            string sidepanelbutton = data["MyProg"]["hamburgerpanel"];
            Color activationheader = System.Drawing.ColorTranslator.FromHtml(sidepanelbutton);
            panel_userinfoheader.BackColor = activationheader;

            panel_activationwindow.BringToFront();
             
            pictureBox_userimage.Image = NXuisupport.Properties.Resources.user;
        }

        private void button_userinfocancel_Click(object sender, EventArgs e)
        {
            SendPanelsBack();
            panel_userinfo.SendToBack();
            panel_activationheading.BringToFront();
            panel_activationwindow.BringToFront();
        }

        private void button_userinfocancel_Click_1(object sender, EventArgs e)
        {
            SendPanelsBack();
            panel_userinfo.SendToBack();
            panel_activationwindow.BringToFront();
            panel_activationheading.BringToFront();
        }

        private void pictureBox_userimage_Click(object sender, EventArgs e)
        {
            pictureBox_userimage.Image = NXuisupport.Properties.Resources.user;
        }
    }
}
