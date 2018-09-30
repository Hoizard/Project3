﻿using System;
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
                OtherYears.Enabled = false;
            }
        }

        protected void PrincipleAmount_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue.ToLower() == "Other".ToLower())
            {
                OtherYears.Enabled = true;
            }
            else
            {
                OtherYears.Enabled = false;
                OtherYears.Text = string.Empty;
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

        //private static Tuple<bool,float> ValidateInput (string)
        //{
        //    Tuple<bool, float> resultTuple;

        //}

        protected void ComputeMortgage_Click(object sender, EventArgs e)
        {
            string inPrin = PrincipleAmount.Text;
            string inYears = OtherYears.Text;
            string inRate = DropDownList1.SelectedItem.Text;
            
            double principal = 0;
            double years = 0;
            double rate = 0;

            bool check = false;

            if (double.TryParse(inPrin, out principal) == false)
            {
                ResultPayment.Text = $"Please input a Principle Amount";
                check = true;
            }

            if (RadioButtonList1.SelectedValue.ToLower() == "other".ToLower())
                if (double.TryParse(inYears, out years) == false)
                {
                    ResultPayment.Text = $"Please select an Loan Duration";
                    check = true;
                }
            else if (RadioButtonList1.SelectedItem.Text == "15")
                {
                    years = 15;
                }
            else
                {
                    years = 30;
                }

            if (double.TryParse(inRate, out rate) == false)
            {
                ResultPayment.Text = $"Please select an Interest Rate";
                check = true;
            }

            if (check == false)
            {
                double monthly = ComputeMonthlyPayment(principal, years, rate);
                ResultPayment.Text = string.Format("The monthly payment is {0:C}", monthly);

            }

            //textBox.Text = String.Empty;
            //textBox.Focus();
        }
    }
}