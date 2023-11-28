using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace biblioteca.CLientes
{
    public partial class ClientesExcluir : Form
    {
        public ClientesExcluir(int cod)
        {
            InitializeComponent();
         
            textBox8.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=bibliotecapedro;UID=root;PASSWORD=;");
            conectar.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = conectar;
            Consulta.CommandText = "SELECT * FROM clientes where idclientes = " + cod + ";";
            MySqlDataReader Resultado = Consulta.ExecuteReader();
            if (Resultado.HasRows)
            {
                while (Resultado.Read())
                {
                    textBox8.Text = Resultado["idclientes"].ToString();
                    textBox1.Text = Resultado["nomecliente"].ToString();
                    textBox2.Text = Resultado["rg"].ToString();
                    textBox3.Text = Resultado["telefone"].ToString();
                    textBox4.Text = Resultado["endereco"].ToString();

                }
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado");
            }
            conectar.Close();
        }

        private void ClientesExcluir_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(textBox8.Text);
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=bibliotecapedro;UID=root;PASSWORD=;");
            conectar.Open();
           

            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = conectar;
            Consulta.CommandText = "delete from locacao where idcliente =" + cod + "; delete from clientes where idclientes = " + cod + ";";
            MySqlDataReader Resultado = Consulta.ExecuteReader();
            if (Resultado.HasRows)
            {
                while (Resultado.Read())
                {

                    textBox1.Text = Resultado["nomecliente"].ToString();
                    textBox2.Text = Resultado["rg"].ToString();
                    textBox3.Text = Resultado["telefone"].ToString();
                    textBox4.Text = Resultado["endereco"].ToString();

                }
            }
            else
            {
                MessageBox.Show("Deletado");
            }

           
            conectar.Close();

            



            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
