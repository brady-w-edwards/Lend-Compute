using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Loan_Calculator.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void ButtonClicked(object source, RoutedEventArgs args)
    {
        Console.WriteLine("Click!");
    }
}