using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Avalonia.Media;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Loan_Calculator;

public class LoanModel
{
    //Set Loan Type Property
    public string? loanType { get; set; }

    // Initial Inputs
    public decimal cost { get; set; }
    public decimal intRate { get; set; }
    public double loanTerm { get; set; }
    public decimal dwnPayment { get; set; }

    // Calculated Values
    public decimal amount { get; set; }
    public decimal interestPercent { get; set; }
    public double monthTerm { get; set; }
    public decimal intMonthly { get; set; }
    public decimal monthlyPI { get; set; }


    // Calculating Methods
    public void LoanAmount()
    {
        amount = cost - dwnPayment;
    }
    public void Percent()
    {
        interestPercent = intRate / 100;
    }
    public void MonthlyTerm()
    {
        monthTerm = loanTerm * 12;
    }
    public void MonthlyInterest()
    {
        intMonthly = interestPercent / 12;
    }
    public void calcPI()
    {
        decimal onePlus = intMonthly + 1;
        monthlyPI = amount * (intMonthly * DecimalPow(monthTerm, onePlus)) / (DecimalPow(monthTerm, onePlus) - 1);
    }

    // Declare a method of converting decimal to double and using Math.Pow()
    static decimal DecimalPow(double powExponent, decimal numBase)
    {
        double baseDouble = (double)numBase;
        double exponentDouble = (double)powExponent;
        double resultDouble = Math.Pow(baseDouble, exponentDouble);
        decimal resultDecimal = (decimal)resultDouble;

        return resultDecimal;
    }
}

