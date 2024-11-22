using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicioTelegrama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcularPrecio_Click(object sender, EventArgs e)
        {
            string textoTelegrama;
            double coste = 0;
            textoTelegrama = txtTelegrama.Text;

            char[] delimitadores = new char[]{' ', '\r', '\n'};
            int numPalabras = textoTelegrama.Split(delimitadores, StringSplitOptions.RemoveEmptyEntries).Length;

            if (!rbUrgente.Checked && !rbOrdinario.Checked)
            {
                MessageBox.Show("Por favor, indique si el telegrama es Ordinario o Urgente"); 

            }
            else
            {
                if (rbOrdinario.Checked)
                {
                    if (numPalabras <= 10 && numPalabras > 0)
                    {
                        coste = 2.5;
                    }
                    else if (numPalabras > 10)
                    {
                        coste = 2.5 + 0.5 * (numPalabras - 10);
                    }
                    else if (numPalabras == 0)
                    {
                        MessageBox.Show("Por favor, escriba el texto a enviar");
                    }
                }
                else if (rbUrgente.Checked)
                {
                    if (numPalabras <= 10 && numPalabras > 0)
                    {
                        coste = 5;
                    }
                    else if (numPalabras > 10)
                    {
                        coste = 5 + 0.75 * (numPalabras - 10);
                    }
                    else if (numPalabras == 0)
                    {
                        MessageBox.Show("Por favor, escriba el texto a enviar");
                    }
                }
            }
            
            txtPrecio.Text = coste.ToString() + " euros";
        }
    }
}
