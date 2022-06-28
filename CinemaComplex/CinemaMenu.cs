using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaComplex
{
    public partial class CinemaMenu : Form
    {
        List<float> selectedItems = new List<float>();
        float total = 0f;
        public CinemaMenu()
        {
            InitializeComponent();
        }

        private void txtBox_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if(tb.Text.Equals("0"))
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void txtBox_Leave (object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals(""))
            {
                tb.Text = "0";
                tb.ForeColor = Color.Silver;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CalculateSum();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Dispose();
        }

        private void CalculateSum()
        {
            selectedItems.Clear();
            try
            {
                if(total == 0)
                {
                    MessageBox.Show("Please add at least one item to your cart or click 'Cancel'.");
                }
                else
                {
                    MessageBox.Show("The total amount to be paid is " + total.ToString() + "€. \n" +
                        "Please add your card information to proceed with the transaction.");
                    CreditCard cc = new CreditCard("Snack");
                    cc.Show(this);
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Please enter the appropriate quantity!");
            }
            
        }

        private void pct_MouseEnter(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            panel1.Controls.OfType<PictureBox>().ToList()[int.Parse(p.Tag.ToString())].Visible = true;
        }

        private void pct_MouseLeave(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            panel1.Controls.OfType<PictureBox>().ToList()[int.Parse(p.Tag.ToString())].Visible = false;
        }

        private void pct_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            if (p.Tag.ToString().Equals("1"))
            {
                txtNachos.Value++;
            }
            else if (p.Tag.ToString().Equals("3"))
            {
                txtWater.Value++;
            }
            else if (p.Tag.ToString().Equals("5"))
            {
                txtCola.Value++;
            }
            else if (p.Tag.ToString().Equals("7"))
            {
                txtCorn.Value++;
            }
        }

        public void Buy()
        {
            Application.OpenForms.OfType<MainHall>().ToList()[0].ChangeFoodBeverage((int)txtCorn.Value, (int)txtNachos.Value, (int)txtCola.Value, (int)txtWater.Value);
        }

        private void CinemaMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CalculateTotal()
        {
            selectedItems.Clear();
            foreach (NumericUpDown tb in panel1.Controls.OfType<NumericUpDown>())
            {
                selectedItems.Add(float.Parse(tb.Value.ToString()) * float.Parse(tb.Tag.ToString()));
            }
            total = selectedItems.Sum();
        } 

        private void ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
            txt_total.Text = $"{total}€";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            MainHall mh = Application.OpenForms.OfType<MainHall>().First();
            if (mh.waveOut.PlaybackState == NAudio.Wave.PlaybackState.Playing)
            {
                button.Image = Properties.Resources.icons8_no_audio_80px;
                mh.waveOut.Pause();
            }
            else
            {
                button.Image = Properties.Resources.icons8_sound_80px;
                mh.PlayMusic();
            }
        }


        SpeechSynthesizer speechSynthesizer;

        private class async_lock
        {
            public static bool flag = true;
        }

        private async void help()
        {
            if (async_lock.flag)
            {
                Application.OpenForms.OfType<MainHall>().First().waveOut.Pause();
                pct_audio.Image = Properties.Resources.icons8_no_audio_80px;
                async_lock.flag = false;
            }
            else
            {
                return;
            }
            await Task.Run(new Action(() => { playIntro(); }));
            async_lock.flag = true;
        }

        private async Task playIntro()
        {
            panel1.Invoke(new Action(() =>
            {
                pct_CircleCoke.Visible = true;
                pct_CirclePop.Visible = true;
                pct_CircleWater.Visible = true;
                pct_CircleNachos.Visible = true;
            }));
            play("Select the amount of each item you want to purchase from the list.");
            play("You can also click on the picture of the item you want to purchase to increase the quantity.");
            panel1.Invoke(new Action(() =>
            {
                pct_CircleCoke.Visible = false;
                pct_CirclePop.Visible = false;
                pct_CircleWater.Visible = false;
                pct_CircleNachos.Visible = false;
                btnOk.BackColor = Color.Blue;
                btnCancel.BackColor = Color.Blue;
            }));
            play("Click on the Purchase button to proceed with your transaction.");
            play("After clicking the Purchase button you will be asked for your credit card information.");
            play("Or you can click on the Cancel button in order to stop the transaction.");
            panel1.Invoke(new Action(() =>
            {
                btnOk.BackColor = Color.DarkSlateGray;
                btnCancel.BackColor = Color.DarkSlateGray;
            }));
        }

        private void play(String txt_to_speech)
        {
            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak(txt_to_speech);
            speechSynthesizer.Dispose();
        }

        private void pct_help_Click(object sender, EventArgs e)
        {
            help();
        }
    }
}
