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
    public partial class ClientesCadastrar : Form
    {
        public ClientesCadastrar()
        {
            InitializeComponent();
        }

        private void ClientesCadastrar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Algum campo está vazio!!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";


            }
            else
            {

                string nome = textBox1.Text;
                string rg = textBox2.Text;
                string telefone = textBox3.Text;
                string endereco = textBox4.Text;



                MySqlConnection conexao = new MySqlConnection();

                conexao.ConnectionString = ("SERVER = 127.0.0.1; DATABASE = bibliotecapedro; UID = root; PASSWORD = ;");

                conexao.Open();
                string inserir = "INSERT INTO clientes VALUES (null, '" + nome + "','" + rg + "' ,'" + telefone + "' ,'" + endereco + "');";

                MySqlCommand comandos = new MySqlCommand(inserir, conexao);

                comandos.ExecuteNonQuery();

                conexao.Close();
                MessageBox.Show("Cliente cadastrado com sucesso");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

            }
        }
    }
}
