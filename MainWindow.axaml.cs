using Avalonia.Controls;
using demo2811.Models;

//using demo2811.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace demo2811
{
    public partial class MainWindow : Window
    {
       // public 
        public MainWindow()
        {
            InitializeComponent();
            
        
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            List<User> users = Helper.context.Users.ToList();
            bool access = false;
            string passwordStr = passwd.Text;
            string loginStr = login.Text;
            foreach (User user in users)
            {

                if (user.Login == loginStr && user.Passwd == passwordStr)
                {
                    Helper.currUser = user;
                    access = true;
                }
            }
            if (access)
            {
                Spisok spisok = new Spisok();   
                spisok.Show();
                this.Close();
            }

        }

        private void Reg_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Close();
        }

        private void Adm_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Admin admin = new Admin();  
            admin.Show();
            this.Close();
        }

        private void Guest_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Helper.role = 0;
            Helper.currUser = null;
            NewZayavka newZ = new NewZayavka();
            newZ.Show();
            this.Close();
        }
    }
}