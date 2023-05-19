using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Alfina
{
    public partial class Form1 : Form
    {
        DatabaseHelpers datab;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            datab = new DatabaseHelpers();
            Data();
        }

        private void Data()
        {
            string sql = "select * from mahasiswa";
            dataGridView1.DataSource = datab.getData(sql);

            dataGridView1.Columns["NIM"].HeaderText = "NIM";
            dataGridView1.Columns["nama"].HeaderText = "Nama";
            dataGridView1.Columns["alamat"].HeaderText = "Alamat";
            dataGridView1.Columns["prodi"].HeaderText = "Prodi";
            dataGridView1.Columns["edit"].DisplayIndex = 5;
            dataGridView1.Columns["delete"].DisplayIndex = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO mahasiswa(NIM, nama, alamat, prodi) VALUES ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}')";
            DialogResult dialogResult = MessageBox.Show("APAKAH ANDA YAKIN?", "INSERT DATA MAHASISWA", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Berhasil!");
                datab.exc(sql);
                Data();
                button3.PerformClick();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Gagal!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button1.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                button1.Enabled = false;
                textBox1.Enabled = false;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["NIM"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["nama"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["alamat"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["prodi"].Value.ToString();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                var NIM = dataGridView1.Rows[e.RowIndex].Cells["NIM"].Value.ToString();
                string sql = $"delete from mahasiswa where NIM = '{NIM}'";

                DialogResult dialogResult = MessageBox.Show("APAKAH ANDA YAKIN?", "DELETE DATA MAHASISWA", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show("Berhasil!");
                    datab.exc(sql);
                    Data();
                    button3.PerformClick();
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Gagal!");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = $"update mahasiswa set nama = '{textBox2.Text}', alamat = '{textBox3.Text}', prodi = '{textBox4.Text}' where NIM = '{textBox1.Text}'";

            DialogResult dialogResult = MessageBox.Show("APAKAH ANDA YAKIN?", "UPDATE BUKU", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Berhasil!");
                datab.exc(sql);
                Data();
                button3.PerformClick();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Gagal!");
            }
        }
    }
}
