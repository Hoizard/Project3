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
            monthly = top / bottom;
            return monthly;
        }

        protected void ComputeMortgage_Click(object sender, EventArgs e)
        {
            string inPrin = PrincipleAmount.Text;
            string inInt = OtherInterest.Text;
            string intRate = DropDownList1.SelectedItem.Text;
            
            double principal = 0;
            double years = 0;
            double rate = 0;

            if (double.TryParse(inPrin, out principal))
            {
                double monthly = ComputeMonthlyPayment(principal, years, rate);
                ResultPayment.Text = string.Format("The monthly payment is {0:C}", monthly); 
            }
            else
            {
                ResultPayment.Text = $"Please input a Principle Amount";
            }

            //textBox.Text = String.Empty;
            //textBox.Focus();
        }
    }
}