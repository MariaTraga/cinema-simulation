using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Reflection;
using System.Threading;

namespace CinemaComplex
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer speechSynthesizer;

        private class async_lock
        {
            public static bool flag = true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            if (async_lock.flag.Equals(false))
            {
                return;
            }
            SelectUserForm user_selection = new SelectUserForm();
            user_selection.Show(this);
            this.Hide();
        }

        private void btn_enter_MouseHover(object sender, EventArgs e)
        {
            btn_enter.Image = Properties.Resources.icons8_front_gate_open_80px;
        }

        private void btn_enter_MouseLeave(object sender, EventArgs e)
        {
            btn_enter.Image = Properties.Resources.icons8_gate_80px;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private async void playIntro()
        {
            if (async_lock.flag)
            {
                async_lock.flag = false;
            }
            else
            {
                return;
            }
            btn_enter.Enabled = false;
            await Task.Run(new Action(() => { help(); }));
            btn_enter.Enabled = true;
            async_lock.flag = true;
        }

        private async Task help()
        {
            play("Hello and welcome to our cinema complex.");
            pct_clerk.Image = Properties.Resources.PinClipart;
            play("Click on the door icon in order to continue.");
            pct_clerk.Image = Properties.Resources.PinClipart_com_hardworking_clipart_5365585;
            play("If you need help, click on the questionmark icon.");
            play("And if you want to exit, click on the exit button.");
        }

        private void play(String txt_to_speech)
        {
            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak(txt_to_speech);
            speechSynthesizer.Dispose();
        }

        private void pct_switch_Click(object sender, EventArgs e)
        {
            if ((string)pct_switch.Tag == "on")
            {
                this.BackgroundImage = Properties.Resources.entrance_dark;
                pct_switch.Image = Properties.Resources.icons8_switch_off_128px;
                pct_switch.Tag = "off";
            }
            else
            {
                this.BackgroundImage = Properties.Resources.entrance_light;
                pct_switch.Image = Properties.Resources.icons8_switch_on_128px;
                pct_switch.Tag = "on";
            }
        }

        private void pct_help_Click(object sender, EventArgs e)
        {
            playIntro();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Task.Run(new Action(() => { playIntro(); }));
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Application was created by:\nDimitris Malliaris & Maria Traga");
        }
    }
}
