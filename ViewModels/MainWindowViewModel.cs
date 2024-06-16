using Loan_Calculator.Models;
using ReactiveUI;
using System.Windows.Input;

namespace Loan_Calculator.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand LendCompute { get; }

    public MainWindowViewModel(LoanModel loanModel) : base(loanModel)
    {
        LendCompute = ReactiveCommand.Create(() =>
        {
            // Code here will be executed when the button is clicked.
            loanModel.LoanAmount();
            loanModel.Percent();
            loanModel.MonthlyTerm();
            loanModel.MonthlyInterest();
            loanModel.CalcPI();
        });

    }
}

