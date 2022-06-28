using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaComplex
{
    public partial class ValidateTicket : Form
    {
        public String[] arrayNames = new String[] { "Bobby Yanne", "Flss Geake", "Fanya Jarley", "Evey Scarsbrooke", "Kiah Wimlett", "Tarra O'Hannay", "Douglass Darragh", "Alon Will", "Evania Poli", "Branden Gartside" };
        public String[] arrayMovies = new String[] { "The Godfather", "Pulp Fiction", "Joker", "One Flew Over the Cuckoo's Nest" };
        String roomTicketPrevious, nameTicketPrevious, movieTicketPrevious, seatTicketPrevious, roomAccessPrevious, movieAccessPrevious, statusTicketPrevious;
        String roomOrderPrevious, nameOrderPrevious, cornPrevious, nachosPrevious, colaPrevious, waterPrevious, statusOrderPrevious;

        public ValidateTicket()
        {
            InitializeComponent();
        }

        private void ValidateTicket_Load(object sender, EventArgs e)
        {
            btn_PreviousTicket.Enabled = false;
            btn_PreviousOrder.Enabled = false;
            createRandomsTicket();
            createRandomsOrder();
        }

        private void createRandomsTicket()
        {
            Random rand = new Random();
            int roomTicket = rand.Next(1, 3);
            int nameTicketIndex = rand.Next(1, 10);
            int movieTicketIndex = rand.Next(1, 4);
            int seatTicketNumber = rand.Next(1, 213);
            
            int roomAccess = rand.Next(1, 3);
            int movieAccessIndex = rand.Next(1, 4);

            String seatNUM;
            if (seatTicketNumber < 26)
            {
                seatNUM = $"A{seatTicketNumber}";
            }
            else if (seatTicketNumber < 51)
            {
                seatNUM = $"B{seatTicketNumber - 25}";
            }
            else if (seatTicketNumber < 76)
            {
                seatNUM = $"C{seatTicketNumber - 50}";
            }
            else if (seatTicketNumber < 101)
            {
                seatNUM = $"D{seatTicketNumber - 75}";
            }
            else if (seatTicketNumber < 126)
            {
                seatNUM = $"E{seatTicketNumber - 100}";
            }
            else if (seatTicketNumber < 149)
            {
                seatNUM = $"G{seatTicketNumber - 125}";
            }
            else if (seatTicketNumber < 172)
            {
                seatNUM = $"H{seatTicketNumber - 148}";
            }
            else if (seatTicketNumber < 193)
            {
                seatNUM = $"H{seatTicketNumber - 171}";
            }
            else
            {
                seatNUM = $"I{seatTicketNumber - 192}";
            }

            lbl_TMovie.Text = arrayMovies[movieTicketIndex];
            lbl_TName.Text = arrayNames[nameTicketIndex];
            lbl_TRoom.Text = roomTicket.ToString();
            lbl_TSeat.Text = seatNUM;

            lbl_AMovie.Text = arrayMovies[movieAccessIndex];
            lbl_ARoom.Text = roomAccess.ToString();


        }

        private void createRandomsOrder()
        {
            Random rand = new Random();
            int roomOrder = rand.Next(1, 3);
            int nameOrderIndex = rand.Next(1, 10);

            int nachos = rand.Next(0, 5);
            int corn = rand.Next(0, 5);
            int cola = rand.Next(0, 5);
            int water = rand.Next(0, 5);         

            lbl_OName.Text = arrayNames[nameOrderIndex];
            lbl_ORoom.Text = roomOrder.ToString();

            lbl_Cola.Text = "x" + cola;
            lbl_Corn.Text = "x" + corn;
            lbl_Nachos.Text = "x" + nachos;
            lbl_Water.Text = "x" + water;

        }

        private void btn_Valid_Click(object sender, EventArgs e)
        {
            statusChange(1);
        }

        private void ValidateTicket_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Invalid_Click(object sender, EventArgs e)
        {
            statusChange(2);
        }

        private void btn_SkipTicket_Click(object sender, EventArgs e)
        {
            statusChange(3);
        }

        private void btn_PreviousTicket_Click(object sender, EventArgs e)
        {
            if (btn_PreviousTicket.Text == "Previous")
            {
                btn_PreviousTicket.Text = "Next";
                btn_Valid.Enabled = false;
                btn_Invalid.Enabled = false;
                btn_SkipTicket.Enabled = false;
                statusChange(4);
            }
            else
            {
                btn_PreviousTicket.Text = "Previous";
                btn_Valid.Enabled = true;
                btn_Invalid.Enabled = true;
                btn_SkipTicket.Enabled = true;
                statusChange(9);
            }
            
        }

        private void btn_SendWaiter_Click(object sender, EventArgs e)
        {
            statusChange(5);
        }

        private void btn_SkipOrder_Click(object sender, EventArgs e)
        {
            statusChange(6);
        }

        private void btn_PreviousOrder_Click(object sender, EventArgs e)
        {
            if(btn_PreviousOrder.Text == "Previous")
            {
                btn_PreviousOrder.Text = "Next";
                btn_SendWaiter.Enabled = false;
                btn_SkipOrder.Enabled = false;
                statusChange(7);
            }
            else
            {
                btn_PreviousOrder.Text = "Previous";
                btn_SendWaiter.Enabled = true;
                btn_SkipOrder.Enabled = true;
                statusChange(8);
            }
            
        }

        private async Task statusChange(int status)
        {
            if(status == 1)
            {
                lbl_TicketStatus.Text = "Validated";
                await Task.Delay(500);
                lbl_TicketStatus.Text = "Preparing Next Ticket...";
                await Task.Delay(500);
                statusTicketPrevious = "Valid";
                savePreviousTicket();
                createRandomsTicket();
                btn_PreviousTicket.Enabled = true;
                lbl_TicketStatus.Text = "-";

            }
            else if (status == 2)
            {
                lbl_TicketStatus.Text = "Invalidated";
                await Task.Delay(500);
                lbl_TicketStatus.Text = "Preparing Next Ticket...";
                await Task.Delay(500);
                statusTicketPrevious = "Invalid";
                savePreviousTicket();
                createRandomsTicket();
                btn_PreviousTicket.Enabled = true;
                lbl_TicketStatus.Text = "-";
            }
            else if(status == 3)
            {
                lbl_TicketStatus.Text = "Preparing Next Ticket...";
                await Task.Delay(500);
                statusTicketPrevious = "Skipped";
                savePreviousTicket();
                createRandomsTicket();
                btn_PreviousTicket.Enabled = true;
                lbl_TicketStatus.Text = "-";
            }
            else if(status == 4)
            {
                lbl_TicketStatus.Text = "Showing Previous...";
                await Task.Delay(500);
                showSavedTicket();
            }
            else if(status == 5)
            {
                lbl_OrderStatus.Text = "Waiter sent to complete order.";
                await Task.Delay(500);
                lbl_OrderStatus.Text = "Preparing Next Order...";
                await Task.Delay(500);
                statusOrderPrevious = "Completed";
                savePreviousOrder();
                createRandomsOrder();
                btn_PreviousOrder.Enabled = true;
                lbl_OrderStatus.Text = "-";
            }
            else if (status == 6)
            {
                lbl_OrderStatus.Text = "Preparing Next Order...";
                await Task.Delay(500);
                statusOrderPrevious = "Skipped";
                savePreviousOrder();
                createRandomsOrder();
                btn_PreviousOrder.Enabled = true;
                lbl_OrderStatus.Text = "-";
            }
            else if(status == 7)
            {
                lbl_OrderStatus.Text = "Showing Previous...";
                await Task.Delay(500);
                showSavedOrder();
            }
            else if (status == 8)
            {
                lbl_OrderStatus.Text = "Showing Different Order...";
                await Task.Delay(500);
                createRandomsOrder();
                lbl_OrderStatus.Text = "-";
            }
            else
            {
                lbl_TicketStatus.Text = "Showing Different Ticket...";
                await Task.Delay(500);
                createRandomsTicket();
                lbl_TicketStatus.Text = "-";
            }
        }

        private void savePreviousTicket()
        {
            roomTicketPrevious = lbl_TRoom.Text;
            nameTicketPrevious = lbl_TName.Text;
            movieTicketPrevious = lbl_TMovie.Text;
            seatTicketPrevious = lbl_TSeat.Text;
            roomAccessPrevious = lbl_ARoom.Text;
            movieAccessPrevious = lbl_AMovie.Text;
        }

        private void savePreviousOrder()
        {
            roomOrderPrevious = lbl_ORoom.Text;
            nameOrderPrevious = lbl_OName.Text;
            cornPrevious = lbl_Corn.Text;
            colaPrevious = lbl_Cola.Text;
            nachosPrevious = lbl_Nachos.Text;
            waterPrevious = lbl_Water.Text;
        }

        private void showSavedTicket()
        {
            lbl_TRoom.Text = roomTicketPrevious;
            lbl_TName.Text = nameTicketPrevious;
            lbl_TMovie.Text = movieTicketPrevious;
            lbl_TSeat.Text = seatTicketPrevious;
            lbl_ARoom.Text = roomAccessPrevious;
            lbl_AMovie.Text = movieAccessPrevious;
            lbl_TicketStatus.Text = statusTicketPrevious;
        }

        private void showSavedOrder()
        {
            lbl_ORoom.Text = roomOrderPrevious;
            lbl_OName.Text = nameOrderPrevious;
            lbl_Corn.Text = cornPrevious;
            lbl_Cola.Text = colaPrevious;
            lbl_Nachos.Text = nachosPrevious;
            lbl_Water.Text = waterPrevious;
            lbl_OrderStatus.Text = statusOrderPrevious;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
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
            changeColor(btn_Valid);
            changeColor(btn_Invalid);
            play("After evaluating the ticket you can click on the Valid Ticket or the Invalid Ticket button.");
            changeColor(btn_Valid);
            changeColor(btn_Invalid);

            changeColor(btn_SendWaiter);
            play("You can also send a waiter to complete a snack order by clicking on the Send Waiter button.");
            changeColor(btn_SendWaiter);

            changeColor(btn_SkipOrder);
            play("In order to skip an order for later evaluation you can click on the Skip button.");
            changeColor(btn_SkipOrder);

            changeColor(btn_PreviousOrder);
            play("Click on the Previous button to view the previous order and then go to a new order by clicking the Next button.");
            changeColor(btn_PreviousOrder);

            changeColor(btn_exit);
            play("Lastly you can click on the Back button to move back to the Control Panel.");
            changeColor(btn_exit);
        }

        private void changeColor(Button button)
        {
            button.Invoke(new Action(() =>
            {
                if(button.BackColor == Color.Blue)
                {
                    button.BackColor = Color.Transparent;
                }
                else
                {
                    button.BackColor = Color.Blue;
                }
            }));
        }

        private void pct_help_Click(object sender, EventArgs e)
        {
            help();
        }

        private void play(String txt_to_speech)
        {
            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak(txt_to_speech);
            speechSynthesizer.Dispose();
        }

        private void SeatSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }           
}
