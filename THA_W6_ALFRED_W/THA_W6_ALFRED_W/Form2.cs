using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W6_ALFRED_W
{
    public partial class Form2 : Form
    {
        Button[,] buttons;
        int totalGuess, letterLength, x, y, keyX, keyY, guessX, guessY;
        string[] alphabets;
        List<string> words;
        string answer;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            x = 10;
            y = 10;
            guessX = 0;
            guessY = 0;
            alphabets = new string[26] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M"};
            totalGuess = Form1.input;
            letterLength = 5;
            buttons = new Button[letterLength, totalGuess];
            for(int i = 0; i < letterLength; i++)
            {
                for(int j = 0; j < totalGuess; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Tag = i.ToString() + "," + j.ToString();
                    buttons[i, j].Size = new Size(50, 50);
                    buttons[i, j].Location = new Point(x, y);
                    this.Controls.Add(buttons[i, j]);
                    y += 50;
                }
                x += 50;
                y = 10;
            }

            keyX = 304;
            keyY = 35;

            foreach(string letter in alphabets)
            {
                if(letter == "A")
                {
                    keyX = 331;
                    keyY = 86;
                }
                if(letter == "Z")
                {
                    keyX = 380;
                    keyY = 137;
                }
                Button key = new Button();
                key.Text = letter;
                key.Location = new Point(keyX, keyY);
                key.Size = new Size(45, 45);
                key.Click += key_Click;
                this.Controls.Add(key);
                keyX += 47;
            }

            Button btn_Enter = new Button();
            btn_Enter.Location = new Point(305, 137);
            btn_Enter.Size = new Size(71, 45);
            btn_Enter.Text = "Enter";
            btn_Enter.Click += btn_Enter_Click;
            this.Controls.Add(btn_Enter);

            Button btn_Delete = new Button();
            btn_Delete.Location = new Point(709, 137);
            btn_Delete.Size = new Size(70, 45);
            btn_Delete.Text = "Delete";
            btn_Delete.Click += btn_Delete_Click;
            this.Controls.Add(btn_Delete);

            string file = "Wordle Word List.txt";
            string[] wordLines = File.ReadAllLines(file);
            words = new List<string>();
            foreach(string wordLine in wordLines)
            {
                words.AddRange(wordLine.Split(','));
            }
            answer = words[new Random().Next(words.Count - 1)].ToUpper();
        }
        private void key_Click(object sender, EventArgs e)
        {
            var send = sender as Button;
            
            if(guessX != 5)
            {
                buttons[guessX, guessY].Text = send.Text;
                guessX++;
            }
        }
        private void btn_Enter_Click(object sender, EventArgs e)
        { 
            int green = 0;
            if (guessX != 5)
            {
                MessageBox.Show("Word must be 5 letters long", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string kata = "";
                for(int i = 0; i < guessX; i++)
                {
                    kata += buttons[i, guessY].Text;
                }
                if (words.Contains(kata.ToLower()))
                {
                    for (int i = 0; i < guessX; i++)
                    {
                        if (answer.Contains(buttons[i, guessY].Text))
                        {
                            buttons[i, guessY].BackColor = Color.Yellow;
                        }
                        if (answer[i].ToString() == buttons[i, guessY].Text)
                        {
                            buttons[i, guessY].BackColor = Color.Green;
                            green++;
                        }
                    }
                    guessY++;
                    if (green == 5)
                    {
                        MessageBox.Show("You won!");
                        this.Close();
                    }
                    else if (green != 5 && guessY == totalGuess)
                    {
                        MessageBox.Show("Game over! Correct word is " + answer);
                        this.Close();
                    }
                    else
                    {
                        guessX = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Word not found in word list", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        { 
            if(guessX != 0)
            {
                guessX--;
                buttons[guessX, guessY].Text = "";
            }
            
        }
    }
}
