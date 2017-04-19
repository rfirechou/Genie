using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace genie
{
    public partial class OrderList : Form
    {
        private Main pmain;
        private int current_product_index;
        //private int customer_number = 0;

        public OrderList()
        {
            InitializeComponent();
        }

        public OrderList(Main pmain_ref, int idx)
        {
            InitializeComponent();

            pmain = pmain_ref;
            current_product_index = idx;

            showOrderList();

            /*
             * add auto complete source
             */
            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
            inputName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            for (int cust_idx = 0; cust_idx < 500; cust_idx++)
            {
                if (pmain.customer[cust_idx].name.Length == 0)
                {
                    break;
                }

                acc.Add(pmain.customer[cust_idx].name);
            }

            inputName.AutoCompleteCustomSource = acc;
        }

        private void addOrder_Click(object sender, EventArgs e)
        {
            String message = "";
            int quantity = 0;

            if (inputName.Text.Length == 0)
            {
                message += "名稱未輸入\n";
            }

            if (inputQuantity.Text.Length == 0)
            {
                message += "數量未輸入\n";
            }
            else if (!int.TryParse(inputQuantity.Text, out quantity))
            {
                message += "數量請輸入數字\n";
            }
            else if (quantity == 0)
            {
                message += "數量不得為0，訂購0個是來亂的嗎?\n";
            }

            if (message.Length != 0)
            {
                MessageBox.Show(message);
                return;
            }

            for (int cust_idx = 0; cust_idx < 500; cust_idx++)
            {
                if (pmain.customer[cust_idx].name.Length == 0)      // new customer
                {
                    pmain.customer[cust_idx].name = inputName.Text;
                    pmain.customer[cust_idx].order[0].index = current_product_index;
                    pmain.customer[cust_idx].order[0].quantity = quantity;

                    AutoCompleteStringCollection acc = inputName.AutoCompleteCustomSource;
                    acc.Add(pmain.customer[cust_idx].name);
                    inputName.AutoCompleteCustomSource = acc;

                    break;
                }

                if (inputName.Text == pmain.customer[cust_idx].name)
                {
                    for (int ord_idx = 0; ord_idx < 50; ord_idx++)
                    {
                        if (pmain.customer[cust_idx].order[ord_idx].index == current_product_index)
                        {
                            if (pmain.customer[cust_idx].order[ord_idx].quantity != 0)
                            {
                                MessageBox.Show("已有訂購資料!");
                            }
                            else
                            {
                                MessageBox.Show("訂購0個? Something wrong!");
                            }
                            break;
                        }

                        if (pmain.customer[cust_idx].order[ord_idx].index == -1)
                        {
                            pmain.customer[cust_idx].order[ord_idx].index = current_product_index;
                            pmain.customer[cust_idx].order[ord_idx].quantity = quantity;

                            break;
                        }
                    }

                    break;
                }

                if (cust_idx == 499)
                {
                    MessageBox.Show("客人爆表，要增加array上限");
                }
            }

            inputName.Clear();
            inputQuantity.Clear();

            showOrderList();

            inputName.Focus();
        }

        private void showOrderList()
        {
            dataGridView1.Rows.Clear();

            for (int cust_idx = 0; cust_idx < 500; cust_idx++)
            {
                if (pmain.customer[cust_idx].name.Length == 0)
                {
                    break;
                }

                for (int ord_idx = 0; ord_idx < 50; ord_idx++)
                {
                    if (pmain.customer[cust_idx].order[ord_idx].index == -1)
                    {
                        continue;
                    }

                    if (pmain.customer[cust_idx].order[ord_idx].index == current_product_index)
                    {
                        dataGridView1.Rows.Add(pmain.customer[cust_idx].name, pmain.customer[cust_idx].order[ord_idx].quantity);
                        break;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int row_idx = dataGridView1.CurrentCell.RowIndex;
            deleteOrderList("" + dataGridView1.Rows[row_idx].Cells[0].Value);

            dataGridView1.Rows.Clear();
            showOrderList();
        }

        private void deleteOrderList(String del_name)
        {
            for (int cus_idx = 0; cus_idx < 500; cus_idx++)
            {
                if (pmain.customer[cus_idx].name.Length == 0)
                {
                    break;
                }

                if (pmain.customer[cus_idx].name == del_name)
                {
                    for (int ord_idx = 0; ord_idx < 50; ord_idx++)
                    {
                        if (pmain.customer[cus_idx].order[ord_idx].index == current_product_index)
                        {
                            pmain.customer[cus_idx].order[ord_idx].index = -1;
                        }
                    }
                }
            }
        }

        private void inputQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addOrder_Click(this, null);
                e.SuppressKeyPress = true;
            }
        }
    }
}
