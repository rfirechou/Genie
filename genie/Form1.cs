using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace genie
{
    public partial class Main : Form
    {
        public customer_t[] customer = new customer_t[500];
        public product_t[] product = new product_t[500];
        public int product_number = 0;

        public Main()
        {
            InitializeComponent();

            for (int i = 0; i < 500; i++)
            {
                customer[i] = new customer_t();
                product[i] = new product_t();
            }
        }

        private void product_Click(object sender, EventArgs e)
        {
            ProductList product = new ProductList(this);
            product.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SumList sum = new SumList(this);
            sum.ShowDialog();
        }

        private void read_Click(object sender, EventArgs e)
        {
            string line;
            int current_cust = -1;
            char[] sep = new char[2]{ ' ', ':' };

            StreamReader file = new StreamReader(@"result.txt", Encoding.Default);

            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                string[] split = line.Split(sep);

                if (line.Length != 0 && line[line.Length - 1] == ':')          // 客人
                {
                    for (int cust_idx = 0; cust_idx < 500; cust_idx++)
                    {
                        if (customer[cust_idx].name.Length == 0)
                        {
                            line = line.TrimEnd(':');
                            customer[cust_idx].name = line;
                            current_cust = cust_idx;
                            break;
                        }

                        if (cust_idx == 499)
                        {
                            MessageBox.Show("客人爆表，要增加array上限");
                        }
                    }
                }
                else if (split.Length == 6)         // 訂購列表
                {
                    int product_index = -1;

                    if (current_cust == -1)
                    {
                        MessageBox.Show("還沒parse到正確的人名，something wrong");
                    }

                    for (int prod_idx = 0; prod_idx < 500; prod_idx++)
                    {
                        if (product[prod_idx].name == split[0])
                        {
                            // product is already exist
                            product_index = prod_idx;
                            break;
                        }

                        if (product[prod_idx].name.Length == 0)     // add new product
                        {
                            product[prod_idx].name = split[0];
                            product[prod_idx].price = Int32.Parse(split[1]);
                            product_index = prod_idx;
                            product_number++;
                            break;
                        }

                        if (prod_idx == 499)
                        {
                            MessageBox.Show("商品爆表，要增加array上限");
                        }
                    }

                    for (int ord_idx = 0; ord_idx < 50; ord_idx++)
                    {
                        if (customer[current_cust].order[ord_idx].index == -1)
                        {
                            if (product_index == -1)
                            {
                                MessageBox.Show("存入訂單商品編號-1，something wrong");
                            }
                            else
                            {
                                customer[current_cust].order[ord_idx].index = product_index;
                                customer[current_cust].order[ord_idx].quantity = Int32.Parse(split[3]);
                                break;
                            }
                        }

                        if (ord_idx == 49)
                        {
                            MessageBox.Show("訂單爆表，要增加array上限");
                        }
                    }
                }
                else if (split.Length == 2)         // 總價
                {
                    current_cust = -1;  // reset
                }
            }

            MessageBox.Show("讀取完畢");

            file.Close();
        }
    }

    public class product_t
    {
        public String name;
        public int price;
        public int cost;
        public String remarks;

        public product_t()
        {
            name = "";
            price = 0;
            cost = 0;
            remarks = "";
        }
    }

    public class order_t
    {
        public int index;
        public int quantity;

        public order_t()
        {
            index = -1;
            quantity = -1;
        }
    }

    public class customer_t
    {
        public String name;
        public String phone;
        public String address;
        public order_t[] order = new order_t[50];

        public customer_t()
        {
            name = "";
            phone = "";
            address = "";

            for (int i = 0; i < 50; i++)
            {
                order[i] = new order_t();
            }
        }
    }

}
