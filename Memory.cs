using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class Interface : Form
    {
        private int[] numbers = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10 };
        private int count = 0;
        private int number1 = 0;
        private int number2 = 0;
        private int cardsup = 0;
        private int score_player1 = 0;
        private int score_player2 = 0;
        private PictureBox button1;
        private PictureBox button2;
        private int passturn = 0;
        private Image[] Deck = {Memory.Properties.Resources.pair_1, Memory.Properties.Resources.pair_2, Memory.Properties.Resources.pair_3,
        Memory.Properties.Resources.pair_4, Memory.Properties.Resources.pair_5, Memory.Properties.Resources.pair_6,
        Memory.Properties.Resources.pair_7, Memory.Properties.Resources.pair_8, Memory.Properties.Resources.pair_9,
        Memory.Properties.Resources.pair_10}; 

        Random random = new Random();

        public Interface()
        {
            InitializeComponent();
        }

        private void Button_Restart(object sender, EventArgs e)
        {
            Shuffle();
            Reset_Cards();
            MessageBox.Show("The cards are shuffled, scores are set. Let's go!");
        }

        private void Shuffle()
        {
            TotalTurns.Text = "0";
            Pairs1.Text = "0";
            Pairs2.Text = "0";
            count = 1;
            score_player1 = 0;
            score_player2 = 0;


            Pairs1.BackColor = Color.Green;
            Pairs2.BackColor = Color.Red;

            numbers = numbers.OrderBy(x => random.Next()).ToArray();
        }

        private void Similarity(int ind, PictureBox button)
        {
            // Het nummer dat omgedraaid wordt, wordt opgeslagen onder variabelen number1 of number2
            passturn = 0;
            if (cardsup > 1)
            {
                PictureBox[] PBs = { PB1, PB2, PB3, PB4, PB5, PB6, PB7, PB8, PB9, PB10, PB11, PB12, PB12, PB13, PB14, PB15, PB16, PB17, PB18, PB19, PB20 };
                foreach (PictureBox P in PBs)
                {
                    P.Image = Memory.Properties.Resources.cards;
                }
                cardsup = 0;
            }

            if (number1 == 0)
            {
                number1 = numbers[ind];
                button.Image = Deck[number1 - 1];
                cardsup++;
                button1 = button;
            }
            else
            {
                number2 = numbers[ind];
                button.Image = Deck[number2 - 1];
                cardsup++;
                button2 = button;
            }
            // Als er een nummer opgeslagen is onder beide variabelen, dan controleren of de nummers gelijk zijn
            // en de score update als het goed is
            if (number2 != 0)
            {
                if (number1 == number2 && this.Pairs1.BackColor == Color.Green && button1.Name != button2.Name)
                {
                    score_player1++;
                    Pairs1.Text = score_player1.ToString();
                    button1.Visible = false;
                    button2.Visible = false;
                    passturn = 1;
                }
                if (number1 == number2 && this.Pairs2.BackColor == Color.Green && button1.Name != button2.Name)
                {
                    score_player2++;
                    Pairs2.Text = score_player2.ToString();
                    button1.Visible = false;
                    button2.Visible = false;
                    passturn = 1;
                }
                else
                {   if (passturn == 0)
                    {
                        if (this.Pairs1.BackColor == Color.Red)
                        {
                            this.Pairs1.BackColor = Color.Green;
                            this.Pairs2.BackColor = Color.Red;
                        }
                        else
                        {
                            this.Pairs1.BackColor = Color.Red;
                            this.Pairs2.BackColor = Color.Green;
                        }
                    } 
                }
                

                number1 = 0;
                number2 = 0;
            }
            this.TotalTurns.Text = count.ToString();
            count++;
        }

        private void Reset_Cards()
        {
            PictureBox[] PBs = { PB1, PB2, PB3, PB4, PB5, PB6, PB7, PB8, PB9, PB10, PB11, PB12, PB12, PB13, PB14, PB15, PB16, PB17, PB18, PB19, PB20 };
            foreach (PictureBox P in PBs)
            {
                P.Visible = true;
                P.Image = Memory.Properties.Resources.cards;
            }
        }

        private void Interface_Load(object sender, EventArgs e)
        {
            Shuffle();
        }

        private void PB1_Click(object sender, EventArgs e)
        {
            string index = (this.PB1.Name[2]).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB1);
        }

        private void PB2_Click(object sender, EventArgs e)
        {
            string index = (this.PB2.Name[2]).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB2);
        }

        private void PB3_Click(object sender, EventArgs e)
        {
            string index = (this.PB3.Name[2]).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB3);
        }

        private void PB4_Click(object sender, EventArgs e)
        {
            string index = (this.PB4.Name[2]).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB4);
        }

        private void PB5_Click(object sender, EventArgs e)
        {
            string index = (this.PB5.Name[2]).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB5);
        }

        private void PB6_Click(object sender, EventArgs e)
        {
            string index = (this.PB6.Name[2]).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB6);
        }

        private void PB7_Click(object sender, EventArgs e)
        {
            string index = (this.PB7.Name[2]).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB7);
        }

        private void PB8_Click(object sender, EventArgs e)
        {
            string index = (this.PB8.Name[2]).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB8);
        }

        private void PB9_Click(object sender, EventArgs e)
        {
            string index = (this.PB9.Name[2]).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB9);
        }

        private void PB10_Click(object sender, EventArgs e)
        {
            string index = (10).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB10);
        }

        private void PB11_Click(object sender, EventArgs e)
        {
            string index = (11).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB11);
        }

        private void PB12_Click(object sender, EventArgs e)
        {
            string index = (12).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB12);
        }

        private void PB13_Click(object sender, EventArgs e)
        {
            string index = (13).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB13);
        }

        private void PB14_Click(object sender, EventArgs e)
        {
            string index = (14).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB14);
        }

        private void PB15_Click(object sender, EventArgs e)
        {
            string index = (15).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB15);
        }

        private void PB16_Click(object sender, EventArgs e)
        {
            string index = (16).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB16);
        }

        private void PB17_Click(object sender, EventArgs e)
        {
            string index = (17).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB17);
        }

        private void PB18_Click(object sender, EventArgs e)
        {
            string index = (18).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB18);
        }

        private void PB19_Click(object sender, EventArgs e)
        {
            string index = (19).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB19);
        }

        private void PB20_Click(object sender, EventArgs e)
        {
            string index = (20).ToString();
            int ind = Int32.Parse(index) - 1;
            int image = Int32.Parse(index);

            Similarity(ind, this.PB20);
        }

    }
}

