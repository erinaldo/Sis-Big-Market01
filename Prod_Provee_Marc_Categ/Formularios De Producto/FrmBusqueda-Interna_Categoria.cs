﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prod_Provee_Marc_Categ.Formularios_De_Productos
{
    public partial class FrmBusqueda_Interna_Categoria : Form
    {
        

        public FrmBusqueda_Interna_Categoria()
        {
            InitializeComponent();
        }
        public void GetAll(string condicion)
        {
            string sql;
            MySqlDataAdapter consulta;
            DataSet resultado;
            sql = "SELECT * FROM db_categoria " + condicion;

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
        private void FrmBusqueda_Interna_Categoria_Load(object sender, EventArgs e)
        {
            GetAll("");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            string operacion;
            operacion = "WHERE  Descripcion LIKE '%" + txtBuscar.Text + "%' OR Estado LIKE '%" + txtBuscar.Text + "%'";
            GetAll(operacion);
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

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FrmNuevoProductos frm3 = (FrmNuevoProductos)Owner;
            frm3.txtCategoria.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[0].Value);
            frm3.txtCategoria2.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
            this.Close();
        }
    }
}
