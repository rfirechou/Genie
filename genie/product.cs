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

            for (int prod_idx = 0; prod_idx < pmain.product_count; prod_idx++)
            {
                dataGridView1.Rows.Add(pmain.product[prod_idx].name, pmain.product[prod_idx].price, pmain.product[prod_idx].cost, pmain.product[prod_idx].remarks);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void order_Click(object sender, EventArgs e)
        {
            OrderList order = new OrderList(pmain, dataGridView1.CurrentCell.RowIndex);
            order.ShowDialog();
        }

        private void deleteProduct_Click(object sender, EventArgs e)
        {
            deleteProductInfo(dataGridView1.CurrentCell.RowIndex);
            dataGridView1.Rows.Clear();
            showProductList();
        }

        private void deleteProductInfo(int del_idx)
        {
            //deleteCustomerOrder(del_idx);     // TODO

            for (int i = del_idx; i < pmain.product_count - 1; i++)
            {
                pmain.product[i].name = pmain.product[i + 1].name;
                pmain.product[i].price = pmain.product[i + 1].price;
                pmain.product[i].cost = pmain.product[i + 1].cost;
                pmain.product[i].remarks = pmain.product[i + 1].remarks;
            }

            pmain.product[pmain.product_count - 1].name = "";
            pmain.product_count--;
        }

        private void modifyProduct_Click(object sender, EventArgs e)
        {
            int current_rowindex = dataGridView1.CurrentCell.RowIndex;
            InputBox input = new InputBox(pmain, current_rowindex);
            input.ShowDialog();

            if (input.DialogResult == DialogResult.OK)
            {
                showProductList();

                dataGridView1.CurrentCell = dataGridView1.Rows[current_rowindex].Cells[0];  // set select to modified row
            }
        }
    }
}
