using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
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
        private int passturn = 0;
        private int ind;
        private int score_player1 = 0;
        private int score_player2 = 0;
        private PictureBox button1;
        private PictureBox button2;
        private PictureBox button;

        List<PictureBox> PBs = new List<PictureBox>();
        List<Image> Decks = new List<Image>();
        Random random = new Random();



        public Interface()
        {
            InitializeComponent();
        }


        private void Button_Click(Object sender, EventArgs e)
        {
            button = (PictureBox)sender;
            if (button.Name.Length == 3)
            {
                ind = Int32.Parse(button.Name[2].ToString()) - 1;

                Similarity(ind, button);
            }
            if (button.Name.Length == 4)
            {
                ind = Int32.Parse(button.Name[3].ToString());

                if (Int32.Parse(button.Name[2].ToString()) == 1)
                {
                    ind = ind + 10 - 1;
                }
                if (Int32.Parse(button.Name[2].ToString()) == 2)
                {
                    ind = ind + 20 - 1;
                }

                Similarity(ind, button);
            }
        }

        private void Button_Restart(object sender, EventArgs e)
        {
            string message = "Are you sure want to start a new game?";
            string title = "New game";

            MessageBoxButtons MessageBoxButtons = MessageBoxButtons.OKCancel;
            DialogResult ResultStart = MessageBox.Show(message, title, MessageBoxButtons);

            if (ResultStart == DialogResult.OK)
            {
                Shuffle();
                Reset_Cards();
            }
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
                foreach (PictureBox P in PBs)
                {
                    P.Image = Memory.Properties.Resources.cards;
                }
                cardsup = 0;
            }

            if (number1 == 0)
            {
                number1 = numbers[ind];
                button.Image = Decks[number1 - 1];
                cardsup++;
                button1 = button;
            }
            else
            {
                number2 = numbers[ind];
                button.Image = Decks[number2 - 1];
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
                {
                    if (passturn == 0)
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

            if (score_player1 + score_player2 == 10)
            {
                string str1 = "The winner of the game is: ";
                string str2 = " with a score of ";
                string winner;
                if (score_player1 >= score_player2)
                {
                    if (score_player1 == score_player2)
                    {
                        winner = "It's a tie. You both have scored 5 points";
                    }
                    else 
                    {
                        winner = str1 + Player1.Text + str2 + score_player1;
                    }
                }

                else
                {
                    winner = str1 + Player2.Text + str2 + score_player2;
                }

                MessageBox.Show(winner);
            }
            this.TotalTurns.Text = count.ToString();
            count++;
        }

        private void Reset_Cards()
        {
            foreach (PictureBox P in PBs)
            {
                P.Visible = true;
                P.Image = Memory.Properties.Resources.cards;
            }
        }

        private void Interface_Load(object sender, EventArgs e)
        {
            ResourceSet resourceSet = Memory.Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                Image resim = (Image)entry.Value;
                string resourceKey = (string)entry.Key;
                if (resourceKey != "cards")
                {
                    Decks.Add(resim);
                }
            }

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox)
                {
                    PBs.Add((PictureBox)ctrl);
                    ctrl.Visible = false;
                }
            }
        }
    }
}

