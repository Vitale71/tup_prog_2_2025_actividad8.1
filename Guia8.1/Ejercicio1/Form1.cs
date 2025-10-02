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
using System.Xml.Linq;
using Ejercicio1.models;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Cuenta> cuentas = new List<Cuenta>();
        private void button1_Click(object sender, EventArgs e)
        {
            string name = tbNombre.Text;
            int dni = Convert.ToInt32(tbDNI.Text);
            double importe = Convert.ToDouble(tbImporte.Text);
            Cuenta c = new Cuenta(name, dni, importe);
            cuentas.Sort();
            int idx = cuentas.BinarySearch(c);
            if (idx != -1)
            {
                cuentas[idx].Nombre = name;
                cuentas[idx].Importe = importe;
            }
            else
            {
                cuentas.Add(c);
            }

            tbNombre.Clear();
            tbDNI.Clear();
            tbImporte.Clear();


            button2.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbMostrar.Items.Clear();
            foreach (Cuenta c in cuentas)
            {
                lbMostrar.Items.Add(c);
            }

        }

        private void lbMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cuenta C = lbMostrar.SelectedItem as Cuenta;
            if (C != null)
            {
                tbDNI.Text = $"{C.DNI}";
                tbNombre.Text = C.Nombre;
                tbImporte.Text = $"{C.Importe}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string dni = line.Substring(0, 9);
                    string nombre = line.Substring(9, 10).Trim();
                    string Importe = line.Substring(19, 11);
                    Cuenta c = new Cuenta(nombre, Convert.ToInt32(dni), Convert.ToDouble(Importe));
                }
            }
        }
    }
}
