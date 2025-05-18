using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;

namespace Calculator_CasadD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string formula = "", numStr=" ";
        float num1 = 0, i = 1, esp = 0;
        List<float> num= new List<float>();
        /// <summary>
        /// code for all numerical buttons of the calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void number_Click(object sender, EventArgs e)
        {
            Button b= sender as Button;
            int n;
            switch (b.Text)
            {
                case "0":
                    n = 0;
                    break;
                case "1":
                    n = 1;
                    break;
                case "2":
                    n = 2;
                    break;
                case "3":
                    n = 3;
                    break;
                case "4":
                    n = 4;
                    break;
                case "5":
                    n = 5;
                    break;
                case "6":
                    n = 6;
                    break;
                case "7":
                    n = 7;
                    break;
                case "8":
                    n = 8;
                    break;
                case "9":
                    n = 9;
                    break;
                default:
                    n = 0;
                    break;
            }
            if (i <= 0)
            {
                esp++;
            }
            num1 = (float)(num1 * Math.Pow(10, i)+n/Math.Pow(10,esp));
            LabelDisplay.Text = num1.ToString();
        }


        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                num1 = (num1 - num1 % 10) / 10;
                
            }
            else//float part
            {
                num1 = (float)(num1 * Math.Pow(10, esp) - num1 * Math.Pow(10, esp) % 10) /(float) (Math.Pow(10,esp));
                esp--;
                if (esp<=0)
                {
                    i = 1;
                }
            }
            LabelDisplay.Text = num1.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (numStr==" ")
            {
                numStr = num1.ToString();
                formula = formula +numStr + "+";
                numStr = " ";
            }
            else
            {
                formula = formula + numStr + "+";
            }
            
            num1 = 0;
            esp = 0;
            i = 1;
            LabelDisplay.Text = "";
        }

        private void BtnSub_Click(object sender, EventArgs e)
        {
            if (numStr == " ")
            {
                numStr = num1.ToString();
                formula = formula + numStr + "-";
                numStr = " ";
            }
            else
            {
                formula = formula + numStr + "-";
            }
            
            num1 = 0;
            esp = 0;
            i = 1;
            LabelDisplay.Text = "";
        }

        private void BtnMul_Click(object sender, EventArgs e)
        {
            if (numStr == " ")
            {
                numStr = num1.ToString();
                formula = formula + numStr + "*";
                numStr = " ";
            }
            else
            {
                formula = formula + numStr + "*";
            }
            num1 = 0;
            esp = 0;
            i = 1;
            LabelDisplay.Text = "";
        }

        private void BtnDiv_Click(object sender, EventArgs e)
        {
            if (numStr == " ")
            {
                numStr = num1.ToString();
                formula = formula + numStr + "/";
                numStr = " ";
            }
            else
            {
                formula = formula + numStr + "/";
            }
            num1 = 0;
            esp = 0;
            i = 1;
            LabelDisplay.Text = "";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            
            formula = "";
            numStr = " ";
        }

        private void BtnFloat_Click(object sender, EventArgs e)
        {
            i = 0;
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            
            if (numStr == " ")
            {
                numStr = num1.ToString();
                formula = formula + numStr;
                numStr = " ";
            }
            else
            {
                formula = formula + numStr;
            }
            num1=0;
            numStr = "";
            esp = 0;
            i = 1;
            
            var expression = new Expression(formula);
            var result = expression.Evaluate();
            formula=result.ToString();
           
            LabelDisplay.Text=result.ToString();

        }
    }
}
