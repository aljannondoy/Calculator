using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        int round = 1;
        double results = 0, num1 = 0, num2 = 0;
        string temp = "";
        string temp1 = "", temp2 = "";
        string ope="";
        private void Clear(object sender, EventArgs e)
        {
            res.Text = "0";
            results = 0;
            temp = "";
            num1 = 0;
            num2 = 0;
            ope = "";
            temp1 = "";
            temp2 = "";
            round = 1;
         
        }
        private void Delete(object sender, EventArgs e)
        {
            temp = res.Text;
            if (temp.Length != 1)
            {
                temp = temp.Remove(temp.Length - 1);
                res.Text = temp;
               
            }
            else
            {
                res.Text = "0";
                temp = "0";
                temp1 = "0";
                temp2 = "0";
            }
           

        }
        private void getOperator(object sender, EventArgs e)
        {
            var opText = sender as Button;
            ope = opText.Text;
            round+=1;
        }
        private void Percent(object sender, EventArgs e)
        {
            double perc;
           
            if (round == 1)
            {
                perc = Convert.ToDouble(temp1)*.01;
                num1 = perc;
            }
            else
            {
                perc = Convert.ToDouble(temp2)*.01;
                num2 = perc;
            }
            res.Text = perc.ToString();
                
        }
        private void getDigit(object sender, EventArgs e)
        {
            var getText = sender as Button;
            double number;
            if (res.Text == "0.")
            {
                if (round == 1)
                {
                    temp1 = res.Text;
                }
                else
                {
                    temp2 = res.Text;
                }
            }
            if (round == 1)
            {
                number = Convert.ToDouble(temp1 = temp1.Insert(temp1.Length, getText.Text));
                num1 = number;
            }else{
                number = Convert.ToDouble(temp2 = temp2.Insert(temp2.Length, getText.Text));
                num2 = number;
            }
            res.Text = number.ToString();
          
            
        }
       
        private void Point(object sender, EventArgs e)
        {
            string te="";
            if (res.Text.IndexOf('.') != 1)
            {
                if (res.Text == "0")
                {
                    res.Text = res.Text.Insert(res.Text.Length, ".");
                }
                else
                {
                    if (round == 1)
                    {
                        temp1 = temp1.Insert(temp1.Length, ".");
                        te = temp1;
                    }
                    else
                    {
                        temp2 = temp2.Insert(temp2.Length, ".");
                        te = temp2;
                    }
                    res.Text = te;
                }
            }
               
        }
        private void Equals(object sender, EventArgs e)
        {
            switch (ope)
            {
                case "+":
                    results = num1 + num2;
                    break;
                case "-":
                    results = num1 - num2;

                    break;
                case "x":
                    results = num1 * num2;

                    break;
                case "/":
                    results = num1 / num2;

                    break;
                default:
                    break;
            }

                res.Text = results.ToString();
            if (round != 1)
            {
                num1 = Convert.ToDouble(res.Text);
                temp2 = "0";
            }
                
                results = 0;
        }
    }
}
