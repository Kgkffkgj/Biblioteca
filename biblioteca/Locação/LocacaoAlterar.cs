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


namespace biblioteca.Locação
{
    public partial class LocacaoAlterar : Form
    {
        public LocacaoAlterar(int cod)
        {
            InitializeComponent();
            textBox8.Enabled = false;
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=bibliotecapedro;UID=root;PASSWORD=;");
            conectar.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = conectar;
            Consulta.CommandText = "SELECT * FROM locacao where idlocacao = " + cod + ";";
            MySqlDataReader Resultado = Consulta.ExecuteReader();
            if (Resultado.HasRows)
            {
                while (Resultado.Read())
                {
                    textBox8.Text = Resultado["idlocacao"].ToString();
                    textBox1.Text = Resultado["idlivro"].ToString();
                    textBox2.Text = Resultado["idclientes"].ToString();

                }
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado");
            }
            conectar.Close();
        }

        private void LocacaoAlterar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(textBox8.Text);
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=bibliotecapedro;UID=root;PASSWORD=;");
            conectar.Open();
            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = conectar;
            Consulta.CommandText = "UPDATE locacao SET idlivro = '" + textBox1.Text + "',idclientes = '" + textBox2.Text + "'WHERE idlocacao = '" + cod + "';";
            MySqlDataReader Resultado = Consulta.ExecuteReader();
            if (Resultado.HasRows)
            {
                while (Resultado.Read())
                {

                    textBox1.Text = Resultado["idlivro"].ToString();
                    textBox2.Text = Resultado["idclientes"].ToString();

                }
            }
            else
            {
                MessageBox.Show("Alterado");
            }
            conectar.Close();
        }
    }
}
