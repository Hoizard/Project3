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

        private double ComputePayment(double pAmount, double yAmount, double rAmount)
        {
            double x = 1200;
            double y = -12;
            double z = 1;
            double Calc1 = pAmount * rAmount / x;
            double Calc2 = z - Math.Pow(z + (rAmount / x), y * yAmount);
            double monthly = Calc1 / Calc2;
            return monthly;
        }

        protected void ComputeMortgage_Click(object sender, EventArgs e)
        {
            //TextBox textBox = PrincipleAmount as TextBox;
            //TextBox textBox2 = OtherInterest as TextBox;
            //float otherInterest = float.Parse(textBox2.Text);
            //float PrincAmount = float.Parse(textBox.Text);

            double pAmount = 0;
            double yAmount = 0;
            double rAmount = 0;

            if (PrincipleAmount.Text == "")
            {
                ResultPayment.Text = $"Please input a Principle Amount";
            }
            else if (RadioButtonList1.SelectedItem == null)
            {
                ResultPayment.Text = $"Please select an Loan Duration!!";
            }
            else if (DropDownList1.SelectedItem == null)
            {
                ResultPayment.Text = $"Please Select an Interest Rate";
            }
            else
            {
                double finalResult = ComputePayment(pAmount, yAmount, rAmount);
                ResultPayment.Text = $"Principal of {0} with an interest rate of {1} for {2} years as monthly payment of {3:C}";


            }
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