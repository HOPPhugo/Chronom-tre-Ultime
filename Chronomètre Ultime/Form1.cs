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
        // Variables globales pour le chronomètre
        double secondes = 0;       // Compteur de secondes
        double minutes = 0;        // Compteur de minutes
        bool chrono = true;        // État d'activation du chronomètre (true = actif, false = en pause)
        string virguls;            // Stocke le nombre de décimales pour l'affichage des conversions
        double arrondie;           // Valeur arrondie pour l'affichage
        double converted = 0;      // Valeur après conversion d'une unité à une autre
        string TypeChrono = "S";   // Type d'unité du chronomètre (S = secondes, Min = minutes, etc.)
        string CNT = "-";          // Type d'unité pour la conversion
        bool convertion = false;   // État d'activation de la conversion (true = activée)
        string couleurChrono = "Black"; // Couleur d'affichage du chronomètre

        // Constructeur du formulaire
        public Form1()
        {
            InitializeComponent();
        }

        // Événement déclenché au chargement du formulaire
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Événement déclenché à chaque tick du timer pour le comptage des secondes
        private async void Chrono_Tick(object sender, EventArgs e)
        {
            // Incrémente le compteur de secondes si le chronomètre est actif et en mode Secondes
            if (chrono == true && TypeChrono == "S")
            {
                label8.Text = "--> Minutes";
                secondes++;
                label1.Text = "Chrono : " + secondes + "S";
            }
            // Réinitialise les secondes si on n'est pas en mode Secondes
            if (TypeChrono != "S")
            {
                secondes = 0;
            }
        }

        // Bouton pour mettre le chronomètre en pause
        private void button2_Click(object sender, EventArgs e)
        {
            if (TypeChrono == "S")
            {
                chrono = false;
                label1.Font = new Font(label1.Font, label1.Font.Style | FontStyle.Italic);
                label1.Text = "❄️ Chrono : " + secondes + "s ❄️";
                label1.ForeColor = Color.LightBlue;
                label1.Location = new Point(183, 168);
            }

        }

        // Bouton pour reprendre le chronomètre
        private void button3_Click(object sender, EventArgs e)
        {
            if (TypeChrono == "S")
            {
                chrono = true;
                label1.Font = new Font(label1.Font, label1.Font.Style & ~FontStyle.Italic);
                label1.Text = "Chrono : " + secondes + "S";
                Couleur_label1();
                label1.Location = new Point(237, 168);
            }
        }

        // Bouton pour réinitialiser le chronomètre
        private void button4_Click(object sender, EventArgs e)
        {
            if (TypeChrono == "S")
            {
                // Demande confirmation avant de réinitialiser
                DialogResult rn = MessageBox.Show("Voulez vous vraiment Réinitialiser la valeur du chrono ?", "Reset", MessageBoxButtons.YesNo);
                if (rn == DialogResult.Yes)
                {
                    secondes = 0;
                    MessageBox.Show("Valeur du chrono Réinitialisée !");
                }
            }
        }

        // Événement pour changer la couleur du chronomètre
        private void label2_Click(object sender, EventArgs e)
        {
            // Premier dialogue pour choisir une couleur
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
                // Deuxième dialogue pour plus de choix de couleurs
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
                    // Troisième dialogue pour encore plus de choix
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
                        // Ne rien faire si annulation
                    }
                }
            }
        }

        // Méthode pour appliquer la couleur sélectionnée au chronomètre
        private void Couleur_label1()
        {
            // Si le chronomètre est en pause, il reste en bleu clair
            if (chrono == false)
            {
                label1.ForeColor = Color.LightBlue;
                label2.Text = "LightBlue";
            }
            // Applique la couleur sélectionnée si le chronomètre est actif
            if (couleurChrono == "Black" && chrono == true)
            {
                label1.ForeColor = Color.Black;
                label2.Text = "Color : Black";
            }
            if (couleurChrono == "Red" && chrono == true)
            {
                label1.ForeColor = Color.Red;
                label2.Text = "Color : Red";
            }
            if (couleurChrono == "Yellow" && chrono == true)
            {
                label1.ForeColor = Color.Yellow;
                label2.Text = "Color : Yellow";
            }
            if (couleurChrono == "Purple" && chrono == true)
            {
                label1.ForeColor = Color.Purple;
                label2.Text = "Color : Purple";
            }
            if (couleurChrono == "Green" && chrono == true)
            {
                label1.ForeColor = Color.Green;
                label2.Text = "Color : Green";
            }
            if (couleurChrono == "Blue" && chrono == true)
            {
                label1.ForeColor = Color.Blue;
                label2.Text = "Color : Blue";
            }



        }

        // Conversion en heures
        private void label9_Click(object sender, EventArgs e)
        {
            convertion = true;
            CNT = "H";
            Convertion_on();
        }

        // Méthode principale qui gère toutes les conversions de temps
        private async void Convertion_on()
        {
            int decimales;
            virguls = textBox1.Text;
            if (TypeChrono == "S")
            {
                if (convertion == true && textBox1.Text != "")
                {

                    try
                    {
                        // Récupère le nombre de décimales souhaité
                        decimales = Convert.ToInt32(virguls);

                        // Conversion secondes vers heures
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
                            // Limite à 3 décimales si la demande dépasse 15
                            converted = secondes / 3600;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "H";
                            label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                            label13.ForeColor = Color.Red;
                            label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                        }

                        // Conversion secondes vers minutes
                        if (CNT == "Min" && decimales <= 15)
                        {
                            converted = secondes / 60;
                            arrondie = Math.Round(converted, decimales);
                            label12.Text = "Convertion : " + arrondie + "Min";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                        if (CNT == "Min" && decimales > 15)
                        {
                            converted = secondes / 60;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "Min";
                            label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                            label13.ForeColor = Color.Red;
                            label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                        }

                        // Conversion secondes vers millisecondes
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

                        // Conversion secondes vers jours
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

                        // Conversion secondes vers mois
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

                        // Conversion secondes vers années
                        if (CNT == "Ans" && decimales <= 15)
                        {
                            converted = secondes / 3600;
                            converted = converted / 24;
                            converted = converted / 7;
                            converted = converted / 4;
                            converted = converted / 12;
                            arrondie = Math.Round(converted, decimales);
                            label12.Text = "Convertion : " + arrondie + " Ans";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                        if (CNT == "Ans" && decimales > 15)
                        {
                            converted = secondes / 3600;
                            converted = converted / 24;
                            converted = converted / 7;
                            converted = converted / 4;
                            converted = converted / 12;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + " Ans";
                            label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                            label13.ForeColor = Color.Red;
                            label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                        }
                    }
                    catch
                    {
                        // En cas d'erreur de conversion, utilise 3 décimales par défaut
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
                        if (CNT == "Ans")
                        {
                            converted = secondes / 3600;
                            converted = converted / 24;
                            converted = converted / 7;
                            converted = converted / 4;
                            converted = converted / 12;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + " Ans";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                    }


                }
                else
                {
                    // Si la conversion est activée mais aucun nombre de décimales n'est spécifié
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

                        if (CNT == "Ans")
                        {
                            converted = secondes / 3600;
                            converted = converted / 24;
                            converted = converted / 7;
                            converted = converted / 4;
                            converted = converted / 12;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + " Ans";
                        }
                    }
                }
            }
            // Conversions quand le chrono est en mode Minutes (TypeChrono == "Min")
            if (TypeChrono == "Min")
            {
                if (convertion == true && textBox1.Text != "")
                {

                    try
                    {
                        decimales = Convert.ToInt32(virguls);
                        // Conversion minutes vers heures
                        if (CNT == "H" && decimales <= 15)
                        {
                            converted = minutes / 60;
                            arrondie = Math.Round(converted, decimales);
                            label12.Text = "Convertion : " + arrondie + "H";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                        if (CNT == "H" && decimales > 15)
                        {
                            converted = minutes / 60;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "H";
                            label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                            label13.ForeColor = Color.Red;
                            label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                        }

                        // Conversion minutes vers secondes
                        if (CNT == "S" && decimales <= 15)
                        {
                            converted = minutes * 60;
                            arrondie = Math.Round(converted, decimales);
                            label12.Text = "Convertion : " + arrondie + "S";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                        if (CNT == "S" && decimales > 15)
                        {
                            converted = minutes * 60;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "S";
                            label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                            label13.ForeColor = Color.Red;
                            label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                        }

                        // Conversion minutes vers millisecondes
                        if (CNT == "Mil" && decimales <= 15)
                        {
                            converted = minutes * 60;
                            converted = converted * 1000;
                            arrondie = Math.Round(converted, decimales);
                            label12.Text = "Convertion : " + arrondie + "Mil";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                        if (CNT == "Mil" && decimales > 15)
                        {
                            converted = minutes * 60;
                            converted = converted * 1000;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "Mil";
                            label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                            label13.ForeColor = Color.Red;
                            label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                        }

                        // Conversion minutes vers jours
                        if (CNT == "J" && decimales <= 15)
                        {
                            converted = minutes / 60;
                            converted = converted / 24;
                            arrondie = Math.Round(converted, decimales);
                            label12.Text = "Convertion : " + arrondie + "J";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                        if (CNT == "J" && decimales > 15)
                        {
                            converted = minutes / 60;
                            converted = converted / 24;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "J";
                            label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                            label13.ForeColor = Color.Red;
                            label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                        }

                        // Conversion minutes vers mois
                        if (CNT == "Mois" && decimales <= 15)
                        {
                            converted = minutes / 60;
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
                            converted = minutes / 60;
                            converted = converted / 24;
                            converted = converted / 7;
                            converted = converted / 4;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + " Mois";
                            label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                            label13.ForeColor = Color.Red;
                            label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                        }

                        // Conversion minutes vers années
                        if (CNT == "Ans" && decimales <= 15)
                        {
                            converted = minutes / 60;
                            converted = converted / 24;
                            converted = converted / 7;
                            converted = converted / 4;
                            converted = converted / 12;
                            arrondie = Math.Round(converted, decimales);
                            label12.Text = "Convertion : " + arrondie + " Ans";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                        if (CNT == "Ans" && decimales > 15)
                        {
                            converted = minutes / 60;
                            converted = converted / 24;
                            converted = converted / 7;
                            converted = converted / 4;
                            converted = converted / 12;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + " Ans";
                            label13.Font = new Font(label13.Font, label13.Font.Style | FontStyle.Italic);
                            label13.ForeColor = Color.Red;
                            label13.Text = "Le nombre de decimal ne doit pas dépasser 15.";
                        }
                    }
                    catch
                    {
                        // Gestion des erreurs de conversion pour le mode minutes
                        if (CNT == "H")
                        {
                            converted = minutes / 60;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "H";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                        if (CNT == "S")
                        {
                            converted = minutes * 60;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "Min";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                        if (CNT == "Mil")
                        {
                            converted = minutes * 60;
                            converted = converted * 1000;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "Mil";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                        if (CNT == "J")
                        {
                            converted = minutes / 60;
                            converted = converted / 24;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "J";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                        if (CNT == "Mois")
                        {
                            converted = minutes / 60;
                            converted = converted / 24;
                            converted = converted / 7;
                            converted = converted / 4;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + " Mois";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                        if (CNT == "Ans")
                        {
                            converted = minutes / 60;
                            converted = converted / 24;
                            converted = converted / 7;
                            converted = converted / 4;
                            converted = converted / 12;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + " Ans";
                            label13.Font = new Font(label13.Font, label13.Font.Style & ~FontStyle.Italic);
                            label13.ForeColor = Color.Black;
                            label13.Text = "Nombre de décimales";
                        }
                    }


                }
                else
                {   // Gestions des décimals si l'utilisateur n'a pas choisi de nombre de décimals
                    if (convertion == true)
                    {
                        if (CNT == "H")
                        {
                            converted = minutes / 60;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "H";
                        }

                        if (CNT == "S")
                        {
                            converted = minutes * 60;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "Min";
                        }

                        if (CNT == "Mil")
                        {
                            converted = minutes * 60000;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "Mil";
                        }

                        if (CNT == "J")
                        {
                            converted = minutes / 60;
                            converted = converted / 24;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + "J";
                        }

                        if (CNT == "Mois")
                        {
                            converted = minutes / 60;
                            converted = converted / 24;
                            converted = converted / 7;
                            converted = converted / 4;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + " Mois";
                        }

                        if (CNT == "Ans")
                        {
                            converted = minutes / 60;
                            converted = converted / 24;
                            converted = converted / 7;
                            converted = converted / 4;
                            converted = converted / 12;
                            arrondie = Math.Round(converted, 3);
                            label12.Text = "Convertion : " + arrondie + " Ans";
                        }
                    }
                }
            }

        }
        private void label14_Click(object sender, EventArgs e)
        {
            //arrêt de la convertion
            convertion = false;
            CNT = "-";
        }
        private void changement_Unités()
        {
            // changement de l'unité affichée selon le type de chrono choisi
            if (TypeChrono == "S")
            {
                label1.Text = "Chrono : 0S";
            }
            if (TypeChrono == "Min")
            {
                label1.Text = "Chrono : 0Min";
            }
        }
        private void StopConvertion_Tick(object sender, EventArgs e)
        {
            //Gère le changement de convertion et l'arrêt
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
            // active la convertion en minutes
            convertion = true;
            CNT = "Min";
            Convertion_on();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // active la convertion en miliescondes
            convertion = true;
            CNT = "Mil";
            Convertion_on();
            
        }

        private void label11_Click(object sender, EventArgs e)
        {
            // active la convertion en Jours
            convertion = true;
            CNT = "J";
            Convertion_on();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            // active la convertion en Mois
            convertion = true;
            CNT = "Mois";
            Convertion_on();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // active la convertion en années
            convertion = true;
            CNT = "Ans";
            Convertion_on();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            // au click du textBox1 la valeur se réinitialise
            textBox1.Text = "";
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //permet de refresh les decimal en temps réel ( appelle la fonction de decimal à chaque fois que le text change)
            Convertion_on();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //empêche d'écrire autre chose que des chiffres et de supprimer
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            // permet de refresh la convertion quand le chrono change de chiffre 
            Convertion_on();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // permet de changer de type de chrono ( en minutes ou en secondes selon celui déjà actif )
            if (TypeChrono == "S"){
                DialogResult rn = MessageBox.Show("Souhaitez vous passer en chrono Minutes ?", "Changement d'unité de Chrono", MessageBoxButtons.YesNo);
                if (rn == DialogResult.Yes)
                {
                    TypeChrono = "Min";
                    button1.Text = "Changer : Minutes";
                    secondes = 0;
                    changement_Unités();
                    return;
                }
                if (rn == DialogResult.No)
                {

                }
            }
            if (TypeChrono == "Min")
            {
                DialogResult rn = MessageBox.Show("Souhaitez vous passer en chrono Secondes ?", "Changement d'unité de Chrono", MessageBoxButtons.YesNo);
                if (rn == DialogResult.Yes)
                {
                    TypeChrono = "S";
                    button1.Text = "Changer : Secondes";
                    minutes = 0;
                    changement_Unités();
                    return;
                }
                if (rn == DialogResult.No)
                {

                }
            }
            
        }

        private void Chrono_minutes_Tick(object sender, EventArgs e)
        {
             // chrono en minutes
            if (chrono == true && TypeChrono == "Min")
            {
                label8.Text = "--> Secondes";
                minutes++;
                label1.Text = "Chrono : " + minutes + "Min";
            }
            if (TypeChrono != "Min")
            {
                minutes = 0;
            }
        }
    }
}
