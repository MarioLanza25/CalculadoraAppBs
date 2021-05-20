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
            if (result==0)
            {
                result = Double.Parse(lblShowNumber.Text);
                lblShowOperation.Text = lblShowNumber.Text + " " + btn.Text;
                operation = btn.Text;
                isOperationAdded = true;
            }
            else
            {
                operation = btn.Text;
                isOperationAdded = true;
                PerformOperation(operation);
                lblShowOperation.Text= lblShowNumber.Text + " " + btn.Text;
                
            }     
        }

        private void PerformOperation(String operation)
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
            operation = "";
        }
    }
}
