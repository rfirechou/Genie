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
    public partial class InputBox : Form
    {
        private Main pmain;
        int product_number;

        public InputBox()
        {
            InitializeComponent();
        }

        public InputBox(Main pmain_ref, string rateS)
        {
            InitializeComponent();
            rate.Text = rateS;
            pmain = pmain_ref;
            product_number = -1;
        }

        public InputBox(Main pmain_ref, int product_index, string rateS)
        {
            InitializeComponent();
            
            pmain = pmain_ref;
            product_number = product_index;
            loadProductInfo(product_number);

            if (pmain.product[product_number].cost == 0)
            {
                rate.Text = rateS;
            }
            else
            {
                rate.Text = "1.0";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void InputBox_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price = 0, cost = 0;
            String message = "";

            if (inputName.Text.Length == 0)
            {
                message += "商品名稱未輸入\n";
            }

            if (inputPrice.Text.Length == 0)
            {
                price = 0;
            }
            else if (!int.TryParse(inputPrice.Text, out price))
            {
                message += "單價請輸入數字\n";
            }

            if (inputCost.Text.Length == 0)
            {
                cost = 0;
            }
            else if (!int.TryParse(inputCost.Text, out cost))
            {
                message += "成本請輸入數字";
            }

            if (message.Length != 0)
            {
                MessageBox.Show(message);
                this.DialogResult = DialogResult.None;
            }

            cost = (int)(cost * float.Parse(rate.Text) + 0.9);  // 無條件進位

            if (this.DialogResult == DialogResult.OK)
            {
                if (product_number == -1)
                {
                    pmain.product[pmain.product_count].name = inputName.Text;
                    pmain.product[pmain.product_count].price = price;
                    pmain.product[pmain.product_count].cost = cost;
                    pmain.product[pmain.product_count].remarks = inputRemarks.Text;

                    pmain.product_count++;
                }
                else
                {
                    pmain.product[product_number].name = inputName.Text;
                    pmain.product[product_number].price = price;
                    pmain.product[product_number].cost = cost;
                    pmain.product[product_number].remarks = inputRemarks.Text;
                }
            }
        }

        private void loadProductInfo(int index)
        {
            inputName.Text = pmain.product[index].name;
            inputPrice.Text = "" + pmain.product[index].price;
            inputCost.Text = "" + pmain.product[index].cost;
            inputRemarks.Text = pmain.product[index].remarks;
        }

        private void inputName_TextChanged(object sender, EventArgs e)
        {

        }
        private void inputPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputCost_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputRemarks_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
