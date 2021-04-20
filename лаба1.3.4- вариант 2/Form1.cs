using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лаба1._3._4__вариант_2
{
    public partial class Form1 : Form
    {
        public const int n = 15; //15 участников 
        public int[] Raund = new int[15];
        public bool[] loser = new bool[15];
        public int winners = 0;
        public int winner = 0;
        public Random RandStep = new Random();
        public bool isPlaying = false;

        public int step;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Chartreuse;
            button1.Text = "Идёт игра";
            //for (var i = 0; i < 15; i++) loser[i] = false;
            
            //for(var i = 1; i <= 15; i++) richTextBox1.AppendText(i + " игрок: \n");
            
            for (var j = 0; j < 14; j++) //14 заездов
            {
                
                for (var i = 0; i < 15; i++)//чистка перед заездом
                {
                    //ends[i] = false;
                    Raund[i] = 0;
                }
                winners = 0;
                isPlaying = true;
                
                richTextBox2.AppendText("Новый заезд! \n");
                Zaezd(j);
            }
            richTextBox2.AppendText("\n \n \n" + (winner+1) + " ПОБЕДИЛ!");
        }

        private void Zaezd(int j)
        {
            while (isPlaying) // пока идёт заезд 
            {
                for (var k = 0; k < 15; k++) // 15 игроков
                {
                    step = RandStep.Next(1, 6);
                    if (Raund[k] < 100 && !loser[k] /*&& !ends[k] */)
                    {
                        Raund[k] += step;
                        if (Raund[k] >= 100)
                        {
                            if (winners < 14)
                            {
                                richTextBox2.AppendText((k+1) + " игрок закончил заезд \n");
                                winners += 1;
                                //ends[k] = true;
                            }
                            else if (winners == 14)
                            {
                                richTextBox2.AppendText((k+1) + " игрок закончил заезд последний,\n Он выбывает \n");
                                loser[k] = true;
                                isPlaying = false;
                            }

                            /*if (j == 13)
                            {
                                
                                winner = k;
                            }*/
                        }
                        
                    }
                    
                }
            }
        }
        
        
    }
}