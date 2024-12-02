using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo2811.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace demo2811;

public partial class AddZayavka : Window
{
    public List<Sotrudnik> fio = Helper.context.Sotrudniks.ToList();
    public List<string> aims = Helper.context.Aims.Select(x => x.Name).ToList();
    public List<string> podrs = Helper.context.Podrazds.Select(x => x.Name).ToList();  
    public AddZayavka()
    {
        InitializeComponent();
        if (Helper.currUser == null && Helper.role == 0)
        {
            infPos.IsVisible = true;

        }
        else
        { 
        infPos.IsVisible = false;
        }
        aimCB.ItemsSource = aims;
        podrCB.ItemsSource = podrs;
        sotrCB.ItemsSource = fio.Select(x => x.Name) + " " + fio.Select(x => x.Otchestvo) + " " + fio.Select(x => x.Surname); ;
    }

    private void vyhod_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
       Spisok spisok = new Spisok();
        spisok.Show();
        this.Close();
    }


    private void Ok_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        bool check = true;
        DateOnly srokNach = DateOnly.FromDateTime((DateTime)nachD.SelectedDate.Value.DateTime);
        DateOnly srokKon = DateOnly.FromDateTime((DateTime)endD.SelectedDate.Value.DateTime);
        Zayavka zayavka = new Zayavka();
        zayavka.IdZayavka = Helper.context.Zayavkas.OrderBy(x => x.IdZayavka).Last().IdZayavka + 1;
        zayavka.IdAimNavigation = Helper.context.Aims.Where(x => x.Name == aimCB.SelectedValue.ToString()).First();
        zayavka.IdAim = Helper.context.Aims.Where(x => x.Name == aimCB.SelectedValue.ToString()).First().IdAim;
        zayavka.SrokNach = srokNach;
        zayavka.SrokKonets = srokKon;
        zayavka.IdPodrazdNavigation = Helper.context.Podrazds.Where(x => x.Name == podrCB.SelectedValue.ToString()).First();
        zayavka.IdPodrazd = Helper.context.Podrazds.Where(x => x.Name == podrCB.SelectedValue.ToString()).First().IdPodrazd;
        zayavka.IdStatNavigation = Helper.context.Statuses.Where(x => x.IdStat == 1).First();
        zayavka.IdStat = 1;
       Helper.context.Zayavkas.Add(zayavka);
        
    }
}