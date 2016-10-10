//Calculator by Dario Passarello
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Calculator : Form
    {

        string operand1;
        string operand2;
        double memory;
        Operations oper;
        
        public Calculator()
        {
            InitializeComponent();
        }


        /*
         * OPERATION IDS
         * 0 - Equals
         * 1 - Plus
         * 2 - Minus
         * 3 - Times
         * 4 - Divide
         * 5 - Cancel
         * 6 - Reset
         * 7 - AddToMemory
         * 8 - SubtractToMemory
         * 9 - MemoryRecall
         * 10 - MemoryClear
         * 11 - Squareroot
         * */

        enum Operations
        {
            Equals,Plus,Minus,Times,Divide,Cancel,Reset,AddToMemory,SubtractToMemory,MemoryRecall,MemoryClear,SquareRoot,Power
        }

        

        //Interface
        private void buttonN0_Click(object sender, EventArgs e)
        {
            DisplayView.Text += "0";
        }

        private void buttonN1_Click(object sender, EventArgs e)
        {
            DisplayView.Text += "1";
        }

        private void buttonn2_Click(object sender, EventArgs e)
        {
            DisplayView.Text += "2";
        }

        private void buttonN3_Click(object sender, EventArgs e)
        {
            DisplayView.Text += "3";
        }

        private void buttonN4_Click(object sender, EventArgs e)
        {
            DisplayView.Text += "4";
        }

        private void buttonN5_Click(object sender, EventArgs e)
        {
            DisplayView.Text += "5";
        }

        private void buttonN6_Click(object sender, EventArgs e)
        {
            DisplayView.Text += "6";
        }

        private void buttonN7_Click(object sender, EventArgs e)
        {
            DisplayView.Text += "7";
        }

        private void buttonN8_Click(object sender, EventArgs e)
        {
            DisplayView.Text += "8";
        }

        private void buttonN9_Click(object sender, EventArgs e)
        {
            DisplayView.Text += "9";
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            operand1 = DisplayView.Text;
            oper = Operations.Plus;
            DisplayView.Text = "";
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            operand1 = DisplayView.Text;
            oper = Operations.Minus;
            DisplayView.Text = "";
        }

        private void buttonMultilpy_Click(object sender, EventArgs e)
        {
            operand1 = DisplayView.Text;
            oper = Operations.Times;
            DisplayView.Text = "";
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            operand1 = DisplayView.Text;
            oper = Operations.Divide;
            DisplayView.Text = "";
        }

        private void buttonEquals_Click(object sender, EventArgs e) 
        {
            string result = "";
            try //Checking dividing by Zero AND previous ERRORS
            {


                operand2 = DisplayView.Text;
                Double dOperand1;
                Double dOperand2;
                Double.TryParse(operand1,out dOperand1);
                Double.TryParse(operand2,out dOperand2);

                switch (oper)
                {
                    case Operations.Plus:
                        result = (dOperand1 + dOperand2).ToString();
                        break;
                    case Operations.Minus:
                        result = (dOperand1 - dOperand2).ToString();
                        break;
                    case Operations.Times:
                        result = (dOperand1 * dOperand2).ToString();
                        break;
                    case Operations.Divide:
                        result = (dOperand1 / dOperand2).ToString();
                        break;
                    case Operations.Power:
                        result = Math.Pow(dOperand1, dOperand2).ToString();
                        break;
                    default:
                        result = operand2;
                        break;

                }

            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                result = "ERROR";
            }
            finally
            {
                DisplayView.Text = result;
            }

        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            if(!DisplayView.Text.Contains(","))
            {
                DisplayView.Text += ",";
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            DisplayView.Text = "";
            operand1 = "";
            operand2 = "";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            double aNumber;
            if(DisplayView.Text.Length >= 1 && Double.TryParse(DisplayView.Text, out aNumber))
            {
                DisplayView.Text = DisplayView.Text.Substring(0, DisplayView.Text.Length - 1);
            }
            else
            {
                if(!Double.TryParse(DisplayView.Text, out aNumber))
                {
                    DisplayView.Text = "";
                }
            }
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            operand1 = DisplayView.Text;
            double radicant;
            bool ok = Double.TryParse(operand1,out radicant);
            if(radicant >= 0 && ok)
            {
                DisplayView.Text = Math.Sqrt(radicant).ToString();
            }
            else
            {
                DisplayView.Text = "ERROR";
            }
        }

        private void buttonMemoryPlus_Click(object sender, EventArgs e)
        {
            double aNumber;
            if(Double.TryParse(DisplayView.Text,out aNumber))
            {
                memory += aNumber;
            }
            
        }

        private void buttonMemoryMinus_Click(object sender, EventArgs e)
        {
            double aNumber;
            if (Double.TryParse(DisplayView.Text, out aNumber))
            {
                memory -= aNumber;
            }
        }

        private void buttonMemoryRegister_Click(object sender, EventArgs e)
        {
            DisplayView.Text = memory.ToString();
        }

        private void buttonMemoryClear_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            operand1 = DisplayView.Text;
            oper = Operations.Power;
            DisplayView.Text = "";
        }
    }
}
