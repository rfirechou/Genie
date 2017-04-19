using System;
using System.Windows.Forms;

namespace genie
{
    public partial class ProductList : Form
    {
        private Main pmain;

        public ProductList(Main pmain_ref)
        {
            InitializeComponent();
            pmain = pmain_ref;

            showProductList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void productListBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            InputBox input = new InputBox(pmain);
            input.ShowDialog();

            if (input.DialogResult == DialogResult.OK)
            {
                showProductList();

                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];  // set select to final row
            }
        }

        private void showProductList()
        {
            dataGridView1.Rows.Clear();

            for (int prod_idx = 0; prod_idx < pmain.product_number; prod_idx++)
            {
                dataGridView1.Rows.Add(pmain.product[prod_idx].name, pmain.product[prod_idx].price, pmain.product[prod_idx].cost, pmain.product[prod_idx].remarks);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrderList order = new OrderList(pmain, dataGridView1.CurrentCell.RowIndex);
            order.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteProductInfo(dataGridView1.CurrentCell.RowIndex);
            dataGridView1.Rows.Clear();
            showProductList();
        }

        private void deleteProductInfo(int del_idx)
        {
            //deleteCustomerOrder(del_idx);

            for (int i = del_idx; i < pmain.product_number - 1; i++)
            {
                pmain.product[i].name = pmain.product[i + 1].name;
                pmain.product[i].price = pmain.product[i + 1].price;
                pmain.product[i].cost = pmain.product[i + 1].cost;
                pmain.product[i].remarks = pmain.product[i + 1].remarks;
            }

            pmain.product[pmain.product_number - 1].name = "";
            pmain.product_number--;
        }
    }
}
