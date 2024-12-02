using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Castle.Core.Resource;
using demo2811.Models;

using System.Collections.Generic;
using System.Linq;

namespace demo2811;

public partial class Admin : Window
{
    public List<Sotrudnik> sotr = Helper.context.Sotrudniks.ToList();
    public Admin()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        bool check = false;

        foreach (Sotrudnik s in sotr)
        {
            if (codeAdm.Text == s.Code)
            {
                check = true;
            }


        }
        if (check)
        {


        }
    }
}