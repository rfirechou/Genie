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
        public int product_count = 0;

        enum ReadState { NO_STATE = 0, READ_PRODUCT, READ_CUSTOMER, READ_ORDER };

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

        private void read_stat_Click(object sender, EventArgs e)
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
                            product_count++;
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

        private void save_Click(object sender, EventArgs e)
        {
            if (File.Exists("record.txt"))
            {
                if (File.Exists("record.txt.bak"))
                {
                    File.Delete("record.txt.bak");
                }

                File.Move("record.txt", "record.txt.bak");
            }

            File.Create("record.txt").Close() ;

            StreamWriter file = new StreamWriter(@"record.txt", false, Encoding.Default);

            file.WriteLine("$$$");

            for (int pro_idx = 0; pro_idx < product_count; pro_idx++)
            {
                /*
                file.WriteLine((pro_idx + 1) + ". " + product[pro_idx].name);
                file.WriteLine("    >> 單價: " + product[pro_idx].price);
                file.WriteLine("    >> 成本: " + product[pro_idx].cost);
                file.WriteLine("    >> 備註: " + product[pro_idx].remarks);
                file.WriteLine("\n");
                */
                string save_info = "";

                save_info += (pro_idx + " " + product[pro_idx].name + " ");
                save_info += (product[pro_idx].price + " ");
                save_info += (product[pro_idx].cost + " ");
                save_info += ((product[pro_idx].remarks == "")? "N/A" : product[pro_idx].remarks);
                file.WriteLine(save_info);
            }

            file.WriteLine("***");

            file.WriteLine();
            file.WriteLine("@@@");
            
            for (int cus_idx=0; cus_idx < 500; cus_idx++)
            {
                if (customer[cus_idx].name.Length == 0)
                {
                    break;
                }

                file.WriteLine(customer[cus_idx].name);
            }

            file.WriteLine("***");

            file.WriteLine();
            file.WriteLine("###");

            for (int cus_idx = 0; cus_idx < 500; cus_idx++)
            {
                string save_info = "";
                int order = 0;

                if (customer[cus_idx].name.Length == 0)
                {
                    break;
                }

                save_info += (customer[cus_idx].name + ": ");

                for (int ord_idx = 0; ord_idx < 50; ord_idx++)
                {
                    if (customer[cus_idx].order[ord_idx].index == -1)
                    {
                        continue;
                    }

                    order++;
                    save_info += (customer[cus_idx].order[ord_idx].index + "-" + customer[cus_idx].order[ord_idx].quantity);
                    save_info += " ";
                }

                if (order != 0)
                {
                    file.WriteLine(save_info);
                }
            }

            file.WriteLine("***");

            MessageBox.Show("保存成功");

            file.Close();
        }

        private void read_Click(object sender, EventArgs e)
        {
            if (!File.Exists("record.txt"))
            {
                MessageBox.Show("record.txt不存在!");
                return;
            }

            StreamReader file = new StreamReader(@"record.txt", Encoding.Default);

            string line;
            ReadState state = ReadState.NO_STATE;

            while ((line = file.ReadLine()) != null)
            {
                switch (line)
                {
                    case "$$$":
                        state = ReadState.READ_PRODUCT;
                        break;
                    case "@@@":
                        state = ReadState.READ_CUSTOMER;
                        break;
                    case "###":
                        state = ReadState.READ_ORDER;
                        break;
                    case "***":
                        state = ReadState.NO_STATE;
                        break;
                    default:
                        switch (state)
                        {
                            case ReadState.READ_PRODUCT:

                                string[] split = line.Split(' ');

                                if (product_count == 500)
                                {
                                    MessageBox.Show("商品爆表，要增加array上限");
                                }
                                else
                                {
                                    product[product_count].name = split[1];
                                    product[product_count].price = Int32.Parse(split[2]);
                                    product[product_count].cost = Int32.Parse(split[3]);
                                    if (split[4] == "N/A")
                                    {
                                        product[product_count].remarks = "";
                                    }
                                    else
                                    {
                                        product[product_count].remarks = split[4];
                                    }

                                    product_count++;
                                }

                                break;

                            case ReadState.READ_CUSTOMER:

                                for (int cust_idx = 0; cust_idx < 500; cust_idx++)
                                {
                                    if (customer[cust_idx].name.Length == 0)
                                    {
                                        customer[cust_idx].name = line;
                                        break;
                                    }

                                    if (cust_idx == 499)
                                    {
                                        MessageBox.Show("紀錄的客人太多?");
                                    }
                                }

                                break;

                            case ReadState.READ_ORDER:

                                string[] name_and_list = line.Split(':');

                                for (int cust_idx = 0; cust_idx < 500; cust_idx++)
                                {
                                    if (customer[cust_idx].name == name_and_list[0])
                                    {
                                        name_and_list[1] = name_and_list[1].Trim();

                                        string[] order_list = name_and_list[1].Split(' ');

                                        for (int list_idx = 0; list_idx < order_list.Length; list_idx++)
                                        {
                                            string[] index_and_quantity = order_list[list_idx].Split('-');

                                            for (int ord_idx = 0; ord_idx < 50; ord_idx++)
                                            {
                                                if (customer[cust_idx].order[ord_idx].index == -1)
                                                {
                                                    customer[cust_idx].order[ord_idx].index = Int32.Parse(index_and_quantity[0]);
                                                    customer[cust_idx].order[ord_idx].quantity = Int32.Parse(index_and_quantity[1]);
                                                    break;
                                                }

                                                if (ord_idx == 49)
                                                {
                                                    MessageBox.Show("訂單超過上限?");
                                                }
                                            }
                                        }

                                        break;
                                    }

                                    if (cust_idx == 499)
                                    {
                                        MessageBox.Show("找不到這個訂單的人?");
                                    }
                                }
                                break;

                            default:
                                break;
                        }
                        break;
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
