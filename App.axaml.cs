using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Loan_Calculator.ViewModels;
using Loan_Calculator.Views;
using Loan_Calculator.Models;

namespace Loan_Calculator;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var loanModel = new LoanModel();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(loanModel)
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}