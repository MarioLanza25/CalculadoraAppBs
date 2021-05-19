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
    public partial class Form1 : Form
    {
        private bool isOperationAdded;
        private String operation;
        private double result = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnOne_Click(object sender, EventArgs e)
        {
            if (lblShowNumber.Equals("0") || isOperationAdded )
            {
                lblShowNumber.Text =  " ";
                
            }
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
            if (result==0)
            {
                
                lblShowResult.Text = lblShowNumber.Text + " " + btn.Text;
                operation = btn.Text;
            }
            else
            {
                lblShowResult.Text += lblShowNumber.Text + " " + btn.Text;
                isOperationAdded = true;
            }     
        }

        private void PerformOperation(String operation)
        {
            double result = Double.Parse(lblShowNumber.Text);
            switch (operation)
            {
                case "+":
                    result = result + Double.Parse(lblShowNumber.Text);
                    break;
                case "-":
                    result = result + Double.Parse(lblShowNumber.Text);
                    break;
                case "*":
                    result = result + Double.Parse(lblShowNumber.Text);
                    break;
                case "/":
                   
                    double temp = Double.Parse(lblShowNumber.Text);
                    if( result == 0 && temp == 0)
                    {
                        lblShowResult.Text = "Undified";
                    }
                    else if (temp==0)
                    {
                        lblShowResult.Text = "ERROR";

                    }
                    else
                    {
                        result /= temp;
                    }
                        
                    break;
                default:
                    break;

            }
            lblShowResult.Text = result.ToString();
            operation = " ";
        }
    }
}
