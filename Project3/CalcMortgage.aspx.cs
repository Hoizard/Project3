using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class CalcMortgage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OtherInterest.Enabled = false;
            }
        }

        protected void PrincipleAmount_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue.ToLower() == "Other".ToLower())
            {
                OtherInterest.Enabled = true;
            }
            else
            {
                OtherInterest.Enabled = false;
                OtherInterest.Text = string.Empty;
            }
        }

        private double ComputeMonthlyPayment(double principal, double years, double rate)
        {
            double monthly = 0;
            double top = principal * rate / 1200.00;
            double bottom = 1 - Math.Pow(1.0 + rate / 1200.0, -12.0 * years);
            // http://www.bankrate.com/calculators/mortgages/loan-calculator.aspx
            monthly = top / bottom;
            //Console.WriteLine();
            //Console.WriteLine("With a principl of ${0}, duration of {1} years and a interest rate of {2}% the monthly loan payment amount is {3:$0.00}", principal, years, rate, monthly);
            return monthly;
        }

        protected void ComputeMortgage_Click(object sender, EventArgs e)
        {
            TextBox textBox = PrincipleAmount as TextBox;
            TextBox textBox2 = OtherInterest as TextBox;
            string intRate = DropDownList1.SelectedItem.Text;

            double otherInterest;
            double PrincAmount;
            
            double principal = 0;
            double years = 0;
            double rate = 0;

            
            //if (PrincipleAmount.Text == "")
            //{
            //    ResultPayment.Text = $"Please input a Principle Amount";
            //}
            if (RadioButtonList1.SelectedItem == null)
            {
                ResultPayment.Text = $"Please select an Loan Duration!!";
            }
            //else if (DropDownList1.SelectedItem == null)
            //{
            //    ResultPayment.Text = $"Please Select an Interest Rate";
            //}
            if (double.TryParse(textBox.Text, out PrincAmount))
            {
                double finalResult = ComputeMonthlyPayment(principal, years, rate);
                ResultPayment.Text = $"Principal of {principal} with an interest rate of {rate} for {years} years as monthly payment of {finalResult}";

            }
            else
            {
                ResultPayment.Text = $"Please input a Principle Amount";
            }

            textBox.Text = String.Empty;
            textBox.Focus();

            //else if  (RadioButtonList1.SelectedValue.ToLower() == "Other".ToLower())
            //{
            //    string selectedValue = RadioButtonList1.SelectedValue;
            //    float result = PrincAmount * otherInterest;
            //    ResultPayment.Text = $"{result} Monthly Payments";
            //}
            //else if (RadioButtonList1.SelectedItem.Value == "15")
            //{
            //    float result = PrincAmount * 15;
            //    ResultPayment.Text = $"{result} Monthly Payments";
            //}
            //else if (RadioButtonList1.SelectedItem.Value == "30")
            //{
            //    float result = PrincAmount * 30;
            //    ResultPayment.Text = $"{result} Monthly Payments";
            //}

        }
    }
}