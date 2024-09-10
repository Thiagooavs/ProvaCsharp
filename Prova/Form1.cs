using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prova
{
    public partial class Form1 : Form
    {
        int count = 1;
        double less = 0;
        

        public Form1()
        {
            InitializeComponent();
            lblVenda.Text = "1";
           
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            dgvProd.Rows.Add(txtProduto.Text, txtQuant.Text, txtValor.Text);
            double tot = double.Parse(lblTotal.Text);
            tot += double.Parse(txtQuant.Text) * double.Parse(txtValor.Text);
            lblTotal.Text = tot.ToString();          


        }

        private void btnRemo_Click(object sender, EventArgs e)
        {
            if (dgvProd.RowCount >0)
            {
               
                
                double less = double.Parse(dgvProd.CurrentRow.Cells[1].Value.ToString()) * double.Parse(dgvProd.CurrentRow.Cells[2].Value.ToString());
                double tot = double.Parse(lblTotal.Text);
                lblTotal.Text = (tot - less).ToString() ;
                dgvProd.Rows.RemoveAt(dgvProd.CurrentRow.Index);
                
                

                MessageBox.Show("Produto excluido com sucesso", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAlt_Click(object sender, EventArgs e)
        {
            if (txtAlt.Text != "")
            {
                double now = double.Parse(dgvProd.CurrentRow.Cells[1].Value.ToString()) * double.Parse(dgvProd.CurrentRow.Cells[2].Value.ToString());
                dgvProd.CurrentRow.Cells[1].Value = txtAlt.Text;
                double less = double.Parse(dgvProd.CurrentRow.Cells[1].Value.ToString()) * double.Parse(dgvProd.CurrentRow.Cells[2].Value.ToString());
                
                double tot = double.Parse(lblTotal.Text);
                lblTotal.Text = ((tot - now) + less).ToString();
            }

        }

        public void dgvProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvProd.RowCount > 0)
            {
                txtAlt.Text = dgvProd.CurrentRow.Cells[1].Value.ToString();  
                
                
                
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Venda feita com Sucesso", "Total: " + double.Parse(lblTotal.Text).ToString("C") + ";  ID Venda: " + lblVenda.Text , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            count++;
            lblVenda.Text = count.ToString();
            lblTotal.Text = "0";

            dgvProd.Rows.Clear();
            txtProduto.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblTotal.Text = "0";

            dgvProd.Rows.Clear();
            txtProduto.Focus();
        }

        private void btnFim_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
