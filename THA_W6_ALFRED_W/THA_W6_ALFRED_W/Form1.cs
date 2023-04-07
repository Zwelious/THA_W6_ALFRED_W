using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W6_ALFRED_W
{
    public partial class Form1 : Form
    {
        TextBox textBox_input;
        Button btn_play;
        Label lbl_input;
        Label lbl_judul;
        public static int input;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_play = new Button();
            btn_play.Location = new Point(153, 200);
            btn_play.Size = new Size(50, 20);
            btn_play.Text = "Play!";
            btn_play.Click += btn_submit_Click;
            btn_play.TextAlign = ContentAlignment.MiddleCenter;

            textBox_input = new TextBox();
            textBox_input.Location = new Point(130, 160);

            lbl_input = new Label();
            lbl_input.Location = new Point(80, 130);
            lbl_input.Text = "Set How Much You Can Guess!";
            lbl_input.Size = new Size(200, 30);
            lbl_input.TextAlign = ContentAlignment.MiddleCenter;

            lbl_judul = new Label();
            lbl_judul.Location = new Point(130, 100);
            lbl_judul.Text = "WORDLE";
            lbl_judul.Font = new Font("Arial", lbl_judul.Font.Size, FontStyle.Bold);
            lbl_judul.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(btn_play);
            this.Controls.Add(textBox_input);
            this.Controls.Add(lbl_input);
            this.Controls.Add(lbl_judul);
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox_input.Text, out input))
            {
                MessageBox.Show("Input a number", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(Convert.ToInt32(textBox_input.Text) <= 3)
            {
                MessageBox.Show("Number must be greater than 3", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                input = Convert.ToInt32(textBox_input.Text);
                Form2 form2 = new Form2();
                form2.Show();
            }
        }
    }
}
