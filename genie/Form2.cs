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

        public InputBox()
        {
            InitializeComponent();
        }

        public InputBox(Main pmain_ref)
        {
            InitializeComponent();
            pmain = pmain_ref;
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
                message += "單價未輸入\n";
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

            if (this.DialogResult == DialogResult.OK)
            {
                pmain.product[pmain.product_number].name = inputName.Text;
                pmain.product[pmain.product_number].price = price;
                pmain.product[pmain.product_number].cost = cost;
                pmain.product[pmain.product_number].remarks = inputRemarks.Text;

                pmain.product_number++;
            }
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
