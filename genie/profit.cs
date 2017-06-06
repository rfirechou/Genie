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
    public partial class ProfitShow : Form
    {
        private Main pmain;

        public ProfitShow()
        {
            InitializeComponent();
        }

        public ProfitShow(Main pmain_ref)
        {
            InitializeComponent();

            pmain = pmain_ref;
        }

        private void ProfitShow_Load(object sender, EventArgs e)
        {
            profitByItem();
        }

        private void profitByItem()
        {
            String text;

            int total_profit = 0;
            int item_profit = 0;
            int[] quantity = new int[500];

            /*
             * calculate quantity
             */
            
            for (int cust_idx = 0; cust_idx < 500; cust_idx++)
            {
                if (pmain.customer[cust_idx].name.Length == 0)
                {
                    break;
                }

                for (int ord_idx = 0; ord_idx < 50; ord_idx++)
                {
                    if (pmain.customer[cust_idx].order[ord_idx].index != -1)
                    {
                        quantity[pmain.customer[cust_idx].order[ord_idx].index] += pmain.customer[cust_idx].order[ord_idx].quantity;
                    }
                }
            }

            for (int prod_idx = 0; prod_idx < pmain.product_count; prod_idx++)
            {
                if (pmain.product[prod_idx].price == 0)
                {
                    item_profit = 0;
                }
                else
                {
                    item_profit = (pmain.product[prod_idx].price - pmain.product[prod_idx].cost) * quantity[prod_idx];
                }
                
                total_profit += item_profit;

                text = pmain.product[prod_idx].name + ": \r\n";
                text += ("    單價 = " + pmain.product[prod_idx].price + ", 成本 = " + pmain.product[prod_idx].cost + ", 數量 = " + quantity[prod_idx] + "\r\n");
                text += ("    獲利 = " + item_profit + "\r\n");
                text += "\r\n";

                textBox1.Text += text;
            }

            textBox1.Text += ("總獲利 = " + total_profit);
        }
    }
}
