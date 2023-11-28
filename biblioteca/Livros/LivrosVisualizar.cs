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

namespace biblioteca.Livros
{
    public partial class LivrosVisualizar : Form
    {
        public LivrosVisualizar()
        {
            InitializeComponent();
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=bibliotecapedro;UID=root;PASSWORD=;");
            conectar.Open();

            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = conectar;
            Consulta.CommandText = "SELECT * FROM livros";

            dataGridView1.Rows.Clear();
            MySqlDataReader Resultado = Consulta.ExecuteReader();
            if (Resultado.HasRows)
            {
                while (Resultado.Read())
                {
                    dataGridView1.Rows.Add(Resultado["idlivro"].ToString(),
                                            Resultado["nome"].ToString(),
                                            Resultado["editora"].ToString(),
                                            Resultado["autor"].ToString(),
                                            Resultado["anoPublic"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado");
            }
            conectar.Close();
        }
        Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("SERVER=localhost;DATABASE=bibliotecapedro;UID=root;PASSWORD=;");
            conectar.Open();

            MySqlCommand Consulta = new MySqlCommand();
            Consulta.Connection = conectar;
            Consulta.CommandText = "SELECT * FROM livros WHERE " + comboBox1.Text + " LIKE '%" + textBox1.Text + "%';";

            dataGridView1.Rows.Clear();
            MySqlDataReader Resultado = Consulta.ExecuteReader();
            if (Resultado.HasRows)
            {
                while (Resultado.Read())
                {
                    dataGridView1.Rows.Add(Resultado["idlivro"].ToString(),
                                            Resultado["nome"].ToString(),
                                            Resultado["editora"].ToString(),
                                            Resultado["autor"].ToString(),
                                            Resultado["anoPublic"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado");
            }
            conectar.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                //
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                //
                XcelApp.Columns.AutoFit();
                //
                XcelApp.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
