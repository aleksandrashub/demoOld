using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace demo2811;

public partial class NewZayavka : Window
{
    public NewZayavka()
    {
        InitializeComponent();
    }

    private void Group_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        AddZayavka add = new AddZayavka();
        add.Show();
        this.Close();

    }

    private void Lichn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        AddZayavka add = new AddZayavka();
        add.Show();
        this.Close();

    }
}