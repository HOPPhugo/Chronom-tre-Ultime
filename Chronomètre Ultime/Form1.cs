using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chronomètre_Ultime
{
    public partial class Form1 : Form
    {
        double secondes = 3700;
        bool chrono = true;
        string virguls;
        double arrondie;
        double converted = 0;
        string CNT = "-";
        bool convertion = false;
        string couleurChrono = "Black";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private async void Chrono_Tick(object sender, EventArgs e)
        {
            if (chrono == true)
            {
                secondes++;
                label1.Text = "Chrono : " + secondes + "S";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                chrono = false;
                label1.Font = new Font(label1.Font, label1.Font.Style | FontStyle.Italic);
                label1.Text = "❄️ Chrono : " + secondes + "s ❄️";
                label1.ForeColor = Color.LightBlue;
                label1.Location = new Point(183, 168);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
                chrono = true;
                label1.Font = new Font(label1.Font, label1.Font.Style & ~FontStyle.Italic);
                label1.Text = "Chrono : " + secondes + "S";
                Couleur_label1();
                label1.Location = new Point(237, 168);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult rn = MessageBox.Show("Voulez vous vraiment Réinitialiser la valeur du chrono ?", "Reset", MessageBoxButtons.YesNo);
            if (rn == DialogResult.Yes)
            {
                secondes = 0;
                MessageBox.Show("Valeur du chrono Réinitialisée !");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult rn = MessageBox.Show("Quel Couleur voulez vous ?\nYes = Bleu\nNo = Rouge\nCancel = + de couleur", "Couleur", MessageBoxButtons.YesNoCancel);
            if (rn == DialogResult.Yes)
            {
                couleurChrono = "Blue";
                Couleur_label1();
            }
            if (rn == DialogResult.No)
            {
                couleurChrono = "Red";
                Couleur_label1();
            }
            if (rn == DialogResult.Cancel)
            {
                DialogResult ra = MessageBox.Show("Quel Couleur voulez vous ?\nYes = Vert\nNo = Violet\nCancel = + de couleur", "Couleur", MessageBoxButtons.YesNoCancel);
                if (ra == DialogResult.Yes)
                {
                    couleurChrono = "Green";
                    Couleur_label1();
                }
                if (ra == DialogResult.No)
                {
                    couleurChrono = "Purple";
                    Couleur_label1();
                }
                if (ra == DialogResult.Cancel)
                {
                    DialogResult re = MessageBox.Show("Quel Couleur voulez vous ?\nYes = Jaune\nNo = Noir\nCancel = Annuler", "Couleur", MessageBoxButtons.YesNoCancel);
                    if (re == DialogResult.Yes)
                    {
                        couleurChrono = "Yellow";
                        Couleur_label1();
                    }
                    if (re == DialogResult.No)
                    {
                        couleurChrono = "Black";
                        Couleur_label1();
                    }
                    if (re == DialogResult.Cancel)
                    {

                    }
                }
            }
        }
        private void Couleur_label1()
        {
            if (chrono == false)
            {
                label1.ForeColor = Color.LightBlue;
            }
            if (couleurChrono == "Black" && chrono == true)
            {
                label1.ForeColor = Color.Black;
            }
            if (couleurChrono == "Red" && chrono == true)
            {
                label1.ForeColor = Color.Red;
            }
            if (couleurChrono == "Yellow" && chrono == true)
            {
                label1.ForeColor = Color.Yellow;
            }
            if (couleurChrono == "Purple" && chrono == true)
            {
                label1.ForeColor = Color.Purple;
            }
            if (couleurChrono == "Green" && chrono == true)
            {
                label1.ForeColor = Color.Green;
            }
            if (couleurChrono == "Blue" && chrono == true)
            {
                label1.ForeColor = Color.Blue;
            }
            

            
        }

        private void label9_Click(object sender, EventArgs e)
        {
            convertion = true;
            CNT = "H";
            Convertion_on();
        }
        private async void Convertion_on()
        {
            int decimales;
            virguls = textBox1.Text;
            if (convertion == true && textBox1.Text != "")
            {
                
                try{
                    decimales = Convert.ToInt32(virguls); 
                    if (CNT == "H" && decimales <= 15)
                    {
                        converted = secondes / 3600;
                        arrondie = Math.Round(converted, decimales);
                        label12.Text = "Convertion : " + arrondie + "H";
                        label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                        label13.ForeColor = Color.Black;
                        label13.Text = "Nombre de décimales";
                    }
                    if (CNT == "H" && decimales > 15)
                    {
                        converted = secondes / 3600;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + "H";
                        label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                        label13.ForeColor = Color.Red;
                        label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                    }

                    if (CNT == "Min" && decimales <= 15)
                    {
                        converted = secondes / 60;
                        arrondie = Math.Round(converted, decimales);
                        label12.Text = "Convertion : " + arrondie + "Min";
                        label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                        label13.ForeColor = Color.Black;
                        label13.Text = "Nombre de décimales";
                    }
                    if (CNT == "Min" &&  decimales > 15)
                    {
                        converted = secondes / 60;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + "Min";
                        label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                        label13.ForeColor = Color.Red;
                        label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                    }

                    if (CNT == "Mil" && decimales <= 15)
                    {
                        converted = secondes * 1000;
                        arrondie = Math.Round(converted, decimales);
                        label12.Text = "Convertion : " + arrondie + "Mil";
                        label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                        label13.ForeColor = Color.Black;
                        label13.Text = "Nombre de décimales";
                    }
                    if (CNT == "Mil" && decimales > 15)
                    {
                        converted = secondes * 1000;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + "Mil";
                        label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                        label13.ForeColor = Color.Red;
                        label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                    }

                    if (CNT == "J" && decimales <= 15)
                    {
                        converted = secondes / 3600;
                        converted = converted / 24;
                        arrondie = Math.Round(converted, decimales);
                        label12.Text = "Convertion : " + arrondie + "J";
                        label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                        label13.ForeColor = Color.Black;
                        label13.Text = "Nombre de décimales";
                    }
                    if (CNT == "J" && decimales > 15)
                    {
                        converted = secondes / 3600;
                        converted = converted / 24;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + "J";
                        label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                        label13.ForeColor = Color.Red;
                        label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                    }

                    if (CNT == "Mois" && decimales <= 15)
                    {
                        converted = secondes / 3600;
                        converted = converted / 24;
                        converted = converted / 7;
                        converted = converted / 4;
                        arrondie = Math.Round(converted, decimales);
                        label12.Text = "Convertion : " + arrondie + " Mois";
                        label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                        label13.ForeColor = Color.Black;
                        label13.Text = "Nombre de décimales";
                    }
                    if (CNT == "Mois" && decimales > 15)
                    {
                        converted = secondes / 3600;
                        converted = converted / 24;
                        converted = converted / 7;
                        converted = converted / 4;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + " Mois";
                        label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                        label13.ForeColor = Color.Red;
                        label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                    }
                }
                catch {
                    if (CNT == "H")
                    {
                        converted = secondes / 3600;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + "H";
                        label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                        label13.ForeColor = Color.Black;
                        label13.Text = "Nombre de décimales";
                    }
                    if (CNT == "Min")
                    {
                        converted = secondes / 60;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + "Min";
                        label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                        label13.ForeColor = Color.Black;
                        label13.Text = "Nombre de décimales";
                    }
                    if (CNT == "Mil")
                    {
                        converted = secondes * 1000;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + "Mil";
                        label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                        label13.ForeColor = Color.Black;
                        label13.Text = "Nombre de décimales";
                    }
                    if (CNT == "J")
                    {
                        converted = secondes / 3600;
                        converted = converted / 24;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + "J";
                        label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                        label13.ForeColor = Color.Black;
                        label13.Text = "Nombre de décimales";
                    }
                    if (CNT == "Mois")
                    {
                        converted = secondes / 3600;
                        converted = converted / 24;
                        converted = converted / 7;
                        converted = converted / 4;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + " Mois";
                        label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                        label13.ForeColor = Color.Black;
                        label13.Text = "Nombre de décimales";
                    }
                    label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                    label13.ForeColor = Color.Red;
                    label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                }

                
            }
            else
            {
                if (convertion == true)
                {
                    if (CNT == "H")
                    {
                        converted = secondes / 3600;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + "H";
                    }

                    if (CNT == "Min")
                    {
                        converted = secondes / 60;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + "Min";
                    }

                    if (CNT == "Mil")
                    {
                        converted = secondes * 1000;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + "Mil";
                    }

                    if (CNT == "J")
                    {
                        converted = secondes / 3600;
                        converted = converted / 24;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + "J";
                    }

                    if (CNT == "Mois")
                    {
                        converted = secondes / 3600;
                        converted = converted / 24;
                        converted = converted / 7;
                        converted = converted / 4;
                        arrondie = Math.Round(converted, 3);
                        label12.Text = "Convertion : " + arrondie + " Mois";
                    }
                }
            }
        }
        

        private void label13_Click(object sender, EventArgs e)
        {
            DialogResult rn = MessageBox.Show("Voulez vous vraiment Réinitialiser la valeur de la convertion ?", "Reset", MessageBoxButtons.YesNo);
            if (rn == DialogResult.Yes)
            {
                convertion = false;
                CNT = "-";
                label12.Text = "Convertion--";
                MessageBox.Show("Valeur de la convertion Réinitialisée !");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            convertion = false;
            CNT = "-";
        }

        private void StopConvertion_Tick(object sender, EventArgs e)
        {

            if (convertion == false)
            {
                label12.Text = "Convertion--";
                CNT = "-";
            }
            if (CNT == "H")
            {
                label9.ForeColor = Color.SkyBlue;
            }
            else
            {
                label9.ForeColor = Color.Black;
            }
            if (CNT == "Min")
            {
                label8.ForeColor = Color.SkyBlue;
            }
            else
            {
                label8.ForeColor = Color.Black;
            }
            if (CNT == "Mil")
            {
                label7.ForeColor = Color.SkyBlue;
            }
            else
            {
                label7.ForeColor = Color.Black;
            }
            if (CNT == "Ans")
            {
                label5.ForeColor = Color.SkyBlue;
            }
            else
            {
                label5.ForeColor = Color.Black;
            }
            if (CNT == "Mois")
            {
                label10.ForeColor = Color.SkyBlue;
            }
            else
            {
                label10.ForeColor = Color.Black;
            }
            if (CNT == "J")
            {
                label11.ForeColor = Color.SkyBlue;
            }
            else
            {
                label11.ForeColor = Color.Black;
            }


        }

        private void label8_Click(object sender, EventArgs e)
        {
            convertion = true;
            CNT = "Min";
            Convertion_on();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            convertion = true;
            CNT = "Mil";
            Convertion_on();
            
        }

        private void label11_Click(object sender, EventArgs e)
        {
            convertion = true;
            CNT = "J";
            Convertion_on();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            convertion = true;
            CNT = "Mois";
            Convertion_on();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            convertion = true;
            CNT = "Ans";
            Convertion_on();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Convertion_on();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Autorise uniquement les chiffres et les touches de contrôle (ex: backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // empêche l'entrée
            }
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            Convertion_on();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
