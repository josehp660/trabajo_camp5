using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabajo_camp5
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }
        private double ObtenerPension(string categoria)
        {
            switch (categoria)
            {
                case "A": return 550;
                case "B": return 500;
                case "C": return 450;
                case "D": return 400;
                default: return 0;
            }
        }

        private double ObtenerDescuento(double promedio)
        {
            if (promedio >= 14 && promedio < 16)
                return 0.10;
            else if (promedio >= 16 && promedio < 18)
                return 0.12;
            else if (promedio >= 18 && promedio <= 20)
                return 0.15;
            else
                return 0.0;
        }

        private double CalcularRebaja(double pension, double descuento)
        {
            return Math.Round(pension * descuento, 2);
        }

        private double CalcularNuevaPension(double pension, double rebaja)
        {
            return Math.Round(pension - rebaja, 2);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string categoria = cmbCategoria.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(categoria))
            {
                MessageBox.Show("Selecciona una categoría válida.");
                return;
            }

            if (!double.TryParse(txtPromedio.Text, out double promedio) || promedio < 0 || promedio > 20)
            {
                MessageBox.Show("Ingresa un promedio válido entre 0 y 20.");
                return;
            }

            double pension = ObtenerPension(categoria);
            double descuento = ObtenerDescuento(promedio);
            double rebaja = CalcularRebaja(pension, descuento);
            double nuevaPension = CalcularNuevaPension(pension, rebaja);

            lblRebaja.Text = $"Rebaja: S/. {rebaja:F2}";
            lblNuevaPension.Text = $"Nueva pensión: S/. {nuevaPension:F2}";
        }
    }
}
