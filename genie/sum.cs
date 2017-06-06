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
    public partial class SumList : Form
    {
        private Main pmain;

        public SumList()
        {
            InitializeComponent();
        }

        public SumList(Main pmain_ref)
        {
            InitializeComponent();

            pmain = pmain_ref;
        }

        private void sum_Load(object sender, EventArgs e)
        {
            sumByCustomer();
        }

        private void sumByCustomer()
        {
            String text;

            for (int cus_idx = 0; cus_idx < 500; cus_idx++)
            {
                int sum_price = 0;
                int order = 0;

                if (pmain.customer[cus_idx].name.Length == 0)
                {
                    break;
                }

                text = (pmain.customer[cus_idx].name + ":\r\n");

                for (int ord_idx = 0; ord_idx < 50; ord_idx++)
                {
                    int prod_idx;

                    if (pmain.customer[cus_idx].order[ord_idx].index == -1)
                    {
                        continue;
                    }

                    order++;

                    prod_idx = pmain.customer[cus_idx].order[ord_idx].index;
                    sum_price += pmain.product[prod_idx].price * pmain.customer[cus_idx].order[ord_idx].quantity;

                    text += ("    " + pmain.product[prod_idx].name + " " + pmain.product[prod_idx].price + " x " + pmain.customer[cus_idx].order[ord_idx].quantity);
                    text += (" = " + pmain.product[prod_idx].price * pmain.customer[cus_idx].order[ord_idx].quantity + "\r\n");
                }

                text += ("  合計: " + sum_price + "\r\n\r\n");

                if (order != 0)
                {
                    textBox1.Text += text;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
