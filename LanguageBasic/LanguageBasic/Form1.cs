using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageBasic
{
    public partial class Calculadora : Form
    {
        private bool isOperationAdded;
        private String operation;
        private double result = 0;

        public Calculadora()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnOne_Click(object sender, EventArgs e)
        {
            if (lblShowNumber.Text.Equals("0") || isOperationAdded )
            {
                lblShowNumber.Text =  "";
                
            }
            isOperationAdded = false;
            Button btn = (Button)sender;//Objeto que castea a button
            if(btn.Text.Equals(".", StringComparison.CurrentCultureIgnoreCase))
            {
                if (lblShowNumber.Text.Contains("."))
                {
                    return;
                }
            }
            lblShowNumber.Text += btn.Text;
        }

        private void BtnSum_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (result==0  || isOperationAdded)
            {
                result = Double.Parse(lblShowNumber.Text);
                //lblShowOperation.Text = lblShowNumber.Text + " " + btn.Text;
                //isOperationAdded = true;
            }
            else
            {
                PerformOperation();
                //lblShowOperation.Text= lblShowNumber.Text + " " + btn.Text;
                
            }
            operation = btn.Text;
            isOperationAdded = true;
            lblShowOperation.Text = lblShowNumber.Text + " " +  operation;
        }

        private void PerformOperation()
        {
       
            switch (operation)
            {
                case "+":
                    result+= Double.Parse(lblShowNumber.Text);
                    break;
                case "-":
                    result-=  Double.Parse(lblShowNumber.Text);
                    break;
                case "*":
                    result*= Double.Parse(lblShowNumber.Text);
                    break;
                case "/":
                   
                    double temp = Double.Parse(lblShowNumber.Text);
                    if( result == 0 && temp == 0)
                    {
                        lblShowNumber.Text= "Undefined";
                    }
                    else if (temp==0)
                    {
                        lblShowNumber.Text = "Error";

                    }
                    else
                    {
                        result /= temp;
                    }
                        
                    break;
                default:
                    break;

            }
            lblShowNumber.Text = result.ToString();
            lblShowOperation.Text = "";
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            PerformOperation();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            lblShowOperation.Text = "";
            result = 0;
            lblShowNumber.Text = "0";
        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            lblShowNumber.Text = "";
        }

        private void BtnSqrt_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            double number = Double.Parse(lblShowNumber.Text);
            result = Math.Sqrt(number);

            lblShowNumber.Text = result.ToString();
            lblShowOperation.Text = "√(" + number + ")";
        }
    }
}
