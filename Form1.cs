using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ticTacToe
{
    public partial class tttForm : Form
    {
        public tttForm()
        {
            InitializeComponent();
            reset();
        }

        public enum Players
        {
            X, O
        }

        Players user;
        int playerWins = 0;
        int cpuWins = 0;
        Random random = new Random();
        List<Button> buttons;

        private void cpuMove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                user = Players.O;
                buttons[index].Text = user.ToString();
                buttons[index].BackColor = Color.LightCoral;
                buttons.RemoveAt(index);
                result();
                cputimer.Stop();
            }
        }

        private void playerMove(object sender, EventArgs e)
        {
            var button = (Button)sender;

            user = Players.X;
            button.Text = user.ToString();
            button.Enabled = false;
            button.BackColor = Color.LightGoldenrodYellow;
            buttons.Remove(button);
            result();
            cputimer.Start();
        }

        private void restart(object sender, EventArgs e)
        {
            reset();
        }

        private void result()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X" ||
                button4.Text == "X" && button5.Text == "X" && button6.Text == "X" ||
                button7.Text == "X" && button8.Text == "X" && button9.Text == "X" ||
                button1.Text == "X" && button4.Text == "X" && button7.Text == "X" ||
                button2.Text == "X" && button5.Text == "X" && button8.Text == "X" ||
                button3.Text == "X" && button6.Text == "X" && button9.Text == "X" ||
                button1.Text == "X" && button5.Text == "X" && button9.Text == "X" ||
                button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                cputimer.Stop();
                MessageBox.Show("You win.", "Result of this round is");
                playerWins++;
                playerScore.Text = "Player Victories: " + playerWins;
                reset();
            }

            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O" ||
                button4.Text == "O" && button5.Text == "O" && button6.Text == "O" ||
                button7.Text == "O" && button8.Text == "O" && button9.Text == "O" ||
                button1.Text == "O" && button4.Text == "O" && button7.Text == "O" ||
                button2.Text == "O" && button5.Text == "O" && button8.Text == "O" ||
                button3.Text == "O" && button6.Text == "O" && button9.Text == "O" ||
                button1.Text == "O" && button5.Text == "O" && button9.Text == "O" ||
                button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                cputimer.Stop();
                MessageBox.Show("CPU Wins!", "Result of this round is");
                cpuWins++;
                aiScore.Text = "AI Victories: " + cpuWins;
                reset();
            }
            else
            {
                if (buttons.Count == 0)
                {
                    MessageBox.Show("No one wins👎", "Result of this round is");
                }
            }
        }

        private void reset()
        {
            buttons = new List<Button>
            {
                button1, button2, button3, button4, button5, button6, button7, button8, button9
            };

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;

            }
        }
    }
}
