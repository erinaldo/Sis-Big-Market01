﻿using MySql.Data.MySqlClient;
using Prod_Provee_Marc_Categ.Formularios_De_Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prod_Provee_Marc_Categ.Formularios
{
    public partial class FrmMenuProductos : Form
    {
        public FrmMenuProductos()
        {
            InitializeComponent();
        }
        //obtener todos los productos
        private char estadoActivo;
        public void GetAll(string condicion)
        {
            string sql;
            MySqlDataAdapter consulta;
            DataSet resultado;
            sql = "SELECT * FROM vistajoinproductos" + condicion;

            try
            {
                modulo.AbrirConexion();
                consulta = new MySqlDataAdapter(sql, modulo.conexion);
                resultado = new DataSet();
                consulta.Fill(resultado, "rsresultado");

                DataGridView1.DataSource = resultado.Tables["rsresultado"];
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /**OBTERNER LOS PRODUCTOS CON ESTADO 0**/

        public void GetAll2(string condicion)
        {
            string sql;
            MySqlDataAdapter consulta;
            DataSet resultado;
            sql = "SELECT * FROM vistaProfuctoEstado0" + condicion;

            try
            {
                modulo.AbrirConexion();
                consulta = new MySqlDataAdapter(sql, modulo.conexion);
                resultado = new DataSet();
                consulta.Fill(resultado, "rsresultado");

                DataGridView1.DataSource = resultado.Tables["rsresultado"];
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        private void FrmProductos_Load(object sender, EventArgs e)
        {
     
            if (bunifuiOSSwitch1.Value == true)
            {
                GetAll("");
            }
            else
            {
                GetAll2("");
            }
            
        }

  

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblNuevoProducto_MouseEnter(object sender, EventArgs e)
        {
            lblNuevoProducto.ForeColor = Color.LightCyan;
            lblNuevoProducto.Font = new Font("Century Gothic", 16, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        private void lblNuevoProducto_MouseLeave(object sender, EventArgs e)
        {
            
            lblNuevoProducto.ForeColor = Color.White;
            lblNuevoProducto.Font = new Font("Century Gothic", 14, FontStyle.Bold, GraphicsUnit.Pixel);
        }

        private void lblModificarProducto_MouseEnter(object sender, EventArgs e)
        {
            lblModificarProducto.ForeColor = Color.LightCyan;
            lblModificarProducto.Font = new Font("Century Gothic", 16, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        private void lblModificarProducto_MouseLeave(object sender, EventArgs e)
        {
            lblModificarProducto.ForeColor = Color.White;
            lblModificarProducto.Font = new Font("Century Gothic", 14, FontStyle.Bold, GraphicsUnit.Pixel);
        }



        private void bunifuCustomLabel1_MouseEnter(object sender, EventArgs e)
        {
            lblCerrar.ForeColor = Color.LightCyan;
            lblCerrar.Font = new Font("Century Gothic", 16, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        private void bunifuCustomLabel1_MouseLeave(object sender, EventArgs e)
        {
            lblCerrar.ForeColor = Color.White;
            lblCerrar.Font = new Font("Century Gothic", 14, FontStyle.Bold, GraphicsUnit.Pixel);
        }


        private void txtBuscar_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar")
            {
                txtBuscar.Text = "";
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text = "Buscar";
            }
        }

        private void lblNuevoProducto_Click(object sender, EventArgs e)
        {
            FrmNuevoProductos frm = new FrmNuevoProductos();
            frm.ShowDialog();
            GetAll("");
        }



        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblModificarProducto_Click(object sender, EventArgs e)
        {
            FrmEditarConBotonProductos frm10 = new FrmEditarConBotonProductos();
            AddOwnedForm(frm10);
            frm10.ShowDialog();
        }

        public static string valor33;
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            valor33 = DataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        
        private void bunifuiOSSwitch1_Click(object sender, EventArgs e)
        {
            if(bunifuiOSSwitch1.Value == true)
            {
                GetAll("");
            }
            else
            {
                GetAll2("");
            }
        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {

        }
    }
}
