using System;
using System.Reactive;
using ReactiveUI;
using Loan_Calculator.Models;

namespace Loan_Calculator.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        private readonly LoanModel loanModel;

        // Privat Backing Field
        private string? loanType;
        private decimal cost;
        private decimal intRate;
        private double loanTerm;
        private decimal dwnPayment;
        private decimal loanAmount;
        private decimal monthlyPI;


        public ViewModelBase(LoanModel loanModel)
        {
            this.loanModel = loanModel;

            var canCalculate = this.WhenAnyValue(
                x => x.Cost,
                x => x.DwnPayment,
                x => x.IntRate,
                x => x.LoanTerm,
                (cost, dwnPayment, intRate, loanTerm) =>
                    cost > 0 &&
                    dwnPayment >= 0 &&
                    intRate > 0 &&
                    loanTerm > 0
            );
        }

        public string? LoanType
        {
            get => loanModel.LoanType;
            set => this.RaiseAndSetIfChanged(ref loanType, value);
        }

        public decimal Cost
        {
            get => loanModel.Cost;
            set => this.RaiseAndSetIfChanged(ref cost, value);
        }

        public decimal IntRate
        {
            get => loanModel.IntRate;
            set => this.RaiseAndSetIfChanged(ref intRate, value);
        }

        public double LoanTerm
        {
            get => loanModel.LoanTerm;
            set => this.RaiseAndSetIfChanged(ref loanTerm, value);
        }

        public decimal DwnPayment
        {
            get => loanModel.DwnPayment;
            set => this.RaiseAndSetIfChanged(ref dwnPayment, value);
        }

        public decimal LoanAmount
        {
            get => loanModel.Amount;
            private set => this.RaiseAndSetIfChanged(ref loanAmount, value);
        }

        public decimal MonthlyPI
        {
            get => loanModel.MonthlyPI;
            private set => this.RaiseAndSetIfChanged(ref monthlyPI, value);
        }


    }
}
