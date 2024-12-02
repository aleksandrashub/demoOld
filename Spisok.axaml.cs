using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo2811.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace demo2811;

public partial class Spisok : Window
{
    public List<Zayavka> zayavkas = Helper.context.Zayavkas.Where(x => x.IdUser == Helper.currUser.IdUser).Include(x => x.IdPodrazdNavigation).Include(x=> x.IdStatNavigation).ToList();
    public Spisok()
    {
        InitializeComponent();
        update();
    }

    private void update()
    {
        var list = zayavkas;
            //Helper.context.Zayavkas;
      listB.ItemsSource=list.ToList();
    }

    private void vyhod_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow main = new MainWindow();
        main.Show();    
        this.Close();
    }

    private void NewZ_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }
}