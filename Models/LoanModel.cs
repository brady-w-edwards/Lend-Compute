using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Avalonia.Media;
using Loan_Calculator;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Loan_Calculator.Models;

public class LoanModel
{
    //Set Loan Type Property
    public string? LoanType { get; set; }

    // Initial Inputs
    public decimal Cost { get; set; }
    public decimal IntRate { get; set; }
    public double LoanTerm { get; set; }
    public decimal DwnPayment { get; set; }

    // Calculated Values
    public decimal Amount { get; set; }
    public decimal InterestPercent { get; set; }
    public double MonthTerm { get; set; }
    public decimal IntMonthly { get; set; }
    public decimal MonthlyPI { get; set; }


    // Calculating Methods
    public void LoanAmount()
    {
        Amount = Cost - DwnPayment;
    }
    public void Percent()
    {
        InterestPercent = IntRate / 100;
    }
    public void MonthlyTerm()
    {
        MonthTerm = LoanTerm * 12;
    }
    public void MonthlyInterest()
    {
        IntMonthly = InterestPercent / 12;
    }
    public decimal CalcPI()
    {
        decimal onePlus = IntMonthly + 1;
        MonthlyPI = Amount * (IntMonthly * DecimalPow(MonthTerm, onePlus)) / (DecimalPow(MonthTerm, onePlus) - 1);
        return MonthlyPI;
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


public class HomeLoan : LoanModel
{
    public decimal MortgageInsuracne { get; set; }
}


public class AutoLoan : LoanModel
{
    public decimal AutoInsuracne { get; set; }
}


public class PersonalLoan : LoanModel
{
    public decimal LoanInsuracne { get; set; }
}