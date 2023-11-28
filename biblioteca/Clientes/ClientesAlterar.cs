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
    public partial class ClientesAlterar : Form
    {
        public ClientesAlterar(int cod)
        {
            InitializeComponent();
            textBox8.Enabled = false;
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

        private void ClientesAlterar_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(textBox8.Text);
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=bibliotecapedro;UID=root;PASSWORD=;");
            conectar.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = conectar;
            Consulta.CommandText = "UPDATE clientes SET nomecliente = '" + textBox1.Text + "',rg = '" + textBox2.Text + "',telefone = '" + textBox3.Text + "',endereco = '" + textBox4.Text + "' WHERE idclientes = " + cod + ";";
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
                MessageBox.Show("Alterado");
            }
            conectar.Close();
            this.Close();
        }
    }
}
