using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计算器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<double> value_list = new List<double>();//存用户输入的数字
        private List<int> operator_list = new List<int>();//存用户输入的运算符，定义+为0，-为1，×为2，÷为3
        //状态记录                                                  
        private bool add_flag = false;//+按下
        private bool minus_flag = false;//-按下
        private bool multi_flag = false;//×按下
        private bool div_flag = false;//÷按下
        private bool result_flag = false;//=按下
        private bool can_operate_flag = false;//按下=是否响应
        private bool character_flag = false;//多个运算符输入判断
        string str1;//中间参数
        public void Initialize()   //初始化
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
        }

        private void num_down(string num) //数字输入
        {
            if (result_flag) { label1.Text = ""; }
            if (add_flag || minus_flag || multi_flag || div_flag || result_flag)
            {
                if (result_flag)//按下等号，刚刚算完一个运算的状态
                {
                    label2.Text = "";
                }
                label2.Text = "";//如果用户刚刚输入完一个运算符
                add_flag = false;
                minus_flag = false;
                multi_flag = false;
                div_flag = false;
                result_flag = false;
            }
            if ((num.Equals(".") && label2.Text.IndexOf(".") < 0) || !num.Equals("."))
            {
                //如果用户输入的是小数点.，则要判断当前已输入的数字中是否含有小数点.才允许输入
                if ((num==".")&&((label2.Text.Length == 0)&&(label1.Text.Length>=0))) //|| (label1.Text.Length == 0)))
                {
                    label1.Text += "0";
                    label2.Text += "0";
                }
                if ((label1.Text.Length == 1) && (label1.Text == "0") && ((num == "1") || (num == "2") || (num == "3") || (num == "4") || (num == "5") || (num == "6") || (num == "7") || (num == "8") || (num == "9")))
                {
                    label1.Text = label2.Text = "";
                }
                label2.Text += num;
                label1.Text += num;
                //str2 = label2.Text;
                can_operate_flag = true;
            }
            character_flag = false;
        }

        private void button12_Click(object sender, EventArgs e) //“0”
        {
            if((label1.Text.LastIndexOf(".")!=-1)&&(label2.Text.LastIndexOf(".") != -1) || (label2.Text.Length==1)|| (label2.Text.IndexOf("1") == 0) || (label2.Text.IndexOf("2") == 0) || (label2.Text.IndexOf("3") == 0) || (label2.Text.IndexOf("4") == 0) || (label2.Text.IndexOf("5") == 0) || (label2.Text.IndexOf("6") == 0) || (label2.Text.IndexOf("7") == 0) || (label2.Text.IndexOf("8") == 0) || (label2.Text.IndexOf("9") == 0))
                num_down("0");
        }

        private void button5_Click(object sender, EventArgs e) //“1”
        {
            num_down("1");
        }

        private void button11_Click(object sender, EventArgs e) //“2”
        {
            num_down("2");
        }

        private void button17_Click(object sender, EventArgs e) //“3”
        {
            num_down("3");
        }

        private void button4_Click(object sender, EventArgs e) //“4”
        {
            num_down("4");
        }

        private void button10_Click(object sender, EventArgs e) //“5”
        {
            num_down("5");
        }

        private void button16_Click(object sender, EventArgs e) //“6”
        {
            num_down("6");
        }

        private void button3_Click(object sender, EventArgs e) //“7”
        {
            num_down("7");
        }

        private void button9_Click(object sender, EventArgs e)//“8”
        {
            num_down("8");
        }

        private void button15_Click(object sender, EventArgs e) //“9”
        {
            num_down("9");
        }

        private void button18_Click(object sender, EventArgs e) //“.”
        {
            num_down(".");
            character_flag = true;
        }

        private void button23_Click(object sender, EventArgs e) //加法
        {
            if ((character_flag != true) && (label1.Text.Length != 0))
            {
                if (!add_flag)//防止用户多次输入一个符号键，符号键只允许输入一次
                {
                    if (result_flag == false)
                    {
                        value_list.Add(double.Parse(label2.Text));//将当前已输入的数字放入value_list
                        operator_list.Add(0);
                        label1.Text += "+";
                        add_flag = true;
                        can_operate_flag = false;//刚刚输入完符号，不能构成一条正常的表达式，如111+，设置为不可运行状态
                    }
                    else
                    {
                        value_list.Add(double.Parse(label3.Text));
                        operator_list.Add(0);
                        label1.Text += "+";
                        add_flag = true;
                        can_operate_flag = false;
                    }
                    label2.Text = "";
                    str1 = label1.Text;
                    result_flag = false;
                    character_flag = true;
                }
            }
        }

        private void button22_Click(object sender, EventArgs e) //减法
        {
            if ((character_flag != true)&& (label1.Text.Length != 0))
            {
                if (!minus_flag)
                {
                    if (result_flag == false)
                    {
                        value_list.Add(double.Parse(label2.Text));
                        operator_list.Add(1);
                        label1.Text += "-";
                        minus_flag = true;
                        can_operate_flag = false;
                    }
                    else
                    {
                        value_list.Add(double.Parse(label3.Text));
                        operator_list.Add(1);
                        label1.Text += "-";
                        minus_flag = true;
                        can_operate_flag = false;
                    }
                    label2.Text = "";
                    str1 = label1.Text;
                    result_flag = false;
                    character_flag = true;
                }
            }
        }

        private void button21_Click(object sender, EventArgs e) //乘法
        {
            if ((character_flag != true) && (label1.Text.Length != 0))
            {
                if (!multi_flag)
                {
                    if (result_flag == false)
                    {
                        value_list.Add(double.Parse(label2.Text));
                        operator_list.Add(2);
                        Double a;
                        a = Convert.ToDouble(label1.Text);
                        if (a < 0)
                        { label1.Text = "(" + label1.Text + ")" + "×"; }
                        else { label1.Text = label1.Text + "×"; }
                        multi_flag = true;
                        can_operate_flag = false;
                    }
                    else
                    {
                        value_list.Add(double.Parse(label3.Text));
                        operator_list.Add(2);
                        label1.Text = "(" + label1.Text + ")" + "×";
                        multi_flag = true;
                        can_operate_flag = false;
                    }
                    label2.Text = "";
                    str1 = label1.Text;
                    result_flag = false;
                    character_flag = true;
                }
            }
        }

        private void button20_Click(object sender, EventArgs e) //除法
        {
            if ((character_flag != true)&& (label1.Text.Length != 0))
            {
                if (!div_flag)
                {
                    if (result_flag == false)
                    {
                        value_list.Add(double.Parse(label2.Text));
                        operator_list.Add(3);
                        Double a;
                        a = Convert.ToDouble(label1.Text);
                        if (a < 0)
                        { label1.Text = "(" + label1.Text + ")" + "÷"; }
                        else { label1.Text = label1.Text + "÷"; }
                        div_flag = true;
                        can_operate_flag = false;
                    }
                    else
                    {
                        value_list.Add(double.Parse(label3.Text));
                        operator_list.Add(3);
                        label1.Text = "(" + label1.Text + ")" + "÷";
                        div_flag = true;
                        can_operate_flag = false;
                    }
                    //label2.Text = "";
                    str1 = label1.Text;
                    result_flag = false;
                    character_flag = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)  //CE 
        {
            if (character_flag == false) { label1.Text = ""; }
            if (label2.Text.Length != 0) 
            {
                label1.Text = str1;
                label2.Text = "";
            }
            operator_list.Clear();//清空累积数字与运算数组
            value_list.Clear();
            character_flag = true;
        }

        private void button19_Click(object sender, EventArgs e) //退格
        {
            if ((label2.Text.Length != 0)&&(label1.Text.Length != 0))
            {
                label2.Text = label2.Text.Substring(0, label2.Text.Length - 1);
                label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
            }
        }

        private void button24_Click(object sender, EventArgs e) //等于 结果计算
        {
            if (value_list.Count > 0 && operator_list.Count > 0 && can_operate_flag)
            {//需要防止用户没输入数字，或者只输入了一个数，就按=。
                value_list.Add(double.Parse(label2.Text));
                double total = value_list[0];
                for (int i = 0; i < operator_list.Count; i++)
                {
                    int _operator = operator_list[i];//operator是C#的运算符重载的关键字，前面加个_来区别
                    switch (_operator)
                    {
                        case 0:
                            total += value_list[i + 1];
                            break;
                        case 1:
                            total -= value_list[i + 1];
                            break;
                        case 2:
                            total *= value_list[i + 1];
                            break;
                        case 3:
                            total /= value_list[i + 1];
                            break;
                    }
                }
                label2.Text = "";
                label3.Text = total + "";
                str1 = "";
                if (label3.Text == "∞") { label3.Text = "";label2.Text = "被除数不能为零！"; }
                //label2.Text = total + "";
                //label1.Text = total + "";
                operator_list.Clear();//算完，就清空累积数字与运算数组
                value_list.Clear();
                result_flag = true;//表示=按下
            }
        }

        private void button13_Click(object sender, EventArgs e) //C 清空
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            str1 = "";
            operator_list.Clear();//清空累积数字与运算数组
            value_list.Clear();
        }

        private void button6_Click(object sender, EventArgs e)// 数值取反
        {
            if ((result_flag == false)&&(character_flag == false)&&(label1.Text.Length!=0))
            {
                Double a = Convert.ToDouble(label2.Text);
                label2.Text = Convert.ToString(-a);
                if (a > 0)
                {
                    if (label1.Text.Length > label2.Text.Length) { label1.Text = str1 + "(" + label2.Text + ")"; }
                    else { label1.Text = str1 + label2.Text; }
                }
                else if (a == 0)
                {
                    label1.Text = label2.Text = "0";
                }
                else
                {
                    label1.Text = str1 + label2.Text;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // % 取百分数
        {
            if ((result_flag == false) && (character_flag == false)&&(label2.Text.Length!=0))
                {
                    Double a, b;
                    a = Convert.ToDouble(label2.Text);
                    b = a / 100;
                    label2.Text = Convert.ToString(b);
                    label1.Text = str1 + label2.Text;
                }
        }

        private void button2_Click(object sender, EventArgs e) // 1/x 取倒
        {
            if ((result_flag == false) && (character_flag == false)&&(label2.Text.Length!=0))
            {
                Double a, b;
                a = Convert.ToDouble(label2.Text);
                if (a != 0)
                {
                    b = 1 / a;
                    label2.Text = Convert.ToString(b);
                    label1.Text = str1 + label2.Text;
                }
                else
                {
                    label1.Text ="";
                    label2.Text = "除数不能为零！";
                }
                
            }

        }

        private void button8_Click(object sender, EventArgs e) // 平方
        {
            if ((result_flag == false) && (character_flag == false) && (label2.Text.Length != 0))
            {
                Double a, b;
                a = Convert.ToDouble(label2.Text);
                b = a * a;
                label2.Text = Convert.ToString(b);
                label1.Text = str1 + label2.Text;
            }
        }

        private void button14_Click(object sender, EventArgs e) // 开方
        {
            if ((result_flag == false) && (character_flag == false) && (label2.Text.Length != 0))
            {
                Double a, b;
                a = Convert.ToDouble(label2.Text);
                b = Math.Sqrt(a);
                label2.Text = Convert.ToString(b);
                label1.Text = str1 + label2.Text;
                result_flag = false;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e) // 键盘响应
        {
            switch (e.KeyData)
            {
                case Keys.D0: case Keys.NumPad0: button12_Click(sender, e); break;
                case Keys.D1: case Keys.NumPad1: button5_Click(sender, e); break;
                case Keys.D2: case Keys.NumPad2: button11_Click(sender, e); break;
                case Keys.D3: case Keys.NumPad3: button17_Click(sender, e); break;
                case Keys.D4: case Keys.NumPad4: button4_Click(sender, e); break;
                case Keys.D5: case Keys.NumPad5: button10_Click(sender, e); break;
                case Keys.D6: case Keys.NumPad6: button16_Click(sender, e); break;
                case Keys.D7: case Keys.NumPad7: button3_Click(sender, e); break;
                case Keys.D8: case Keys.NumPad8: button9_Click(sender, e); break;
                case Keys.D9: case Keys.NumPad9: button15_Click(sender, e); break;
                case Keys.Decimal: button18_Click(sender, e); break;
                case Keys.Add: button23_Click(sender, e); break;
                case Keys.Subtract: button22_Click(sender, e); break;
                case Keys.Multiply: button21_Click(sender, e); break;
                case Keys.Divide: button20_Click(sender, e); break;
                case Keys.Back: button19_Click(sender, e); break;
                case Keys.Enter: button24_Click(sender, e); break;
                default: break;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
