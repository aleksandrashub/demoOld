using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using demo2811.Models;
using MsBox.Avalonia;
using System;
using System.IO;
using System.Linq;

namespace demo2811;

public partial class Reg : Window
{
    public Bitmap bitm;
    public string filename;
    public string path;
    public string destpath;
    public Reg()
    {
        InitializeComponent();
    }

    private async void img_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        OpenFileDialog op = new OpenFileDialog();
        var res = await op.ShowAsync(this);
        if (res == null) return;
        path = res.ToString() + "";
        if (res != null)
        {
            bitm = new Bitmap(path);
            
        }
        imgOut.Source=bitm;
        filename = Path.GetFileName(path);
        destpath = Path.Combine(path, AppDomain.CurrentDomain.BaseDirectory + "\\" + "Assets");
    }

    private void vyhod_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow main = new MainWindow(); 
        main.Show();
        this.Close();

    }

    private void Reg_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        bool check = true;
         User user = new User();
         user.IdUser = Helper.context.Users.OrderBy(x => x.IdUser).Last().IdUser + 1;
        if (passwdInp.Text != "")
        {
                  user.Passwd = passwdInp.Text;
        }
        else
        {
            check = false;
            var ms = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Заполните  пароль");
            ms.ShowAsync();
        }

        if (loginInp.Text != "")
        {
            user.Login = loginInp.Text;
        }
        else
        {
            check = false;
            var ms = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Заполните логин");
            ms.ShowAsync();
        }
        if (nameUs.Text != "")
        {

            user.Name = nameUs.Text;
        }
        else
        {
            check = false;
            var ms = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Заполните имя");
            ms.ShowAsync();
        }


        if (otchUs.Text != "")
        {
            user.Otchestvo = otchUs.Text;
        }
        else
        {
            var ms = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Заполните  отчество");
            ms.ShowAsync();
        }

        if (surnUs.Text != "")
        {
            user.Surname = surnUs.Text;
        }
        else
        {
            check = false;
            var ms = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Заполните фамилию");
            ms.ShowAsync();
        }
        if (phoneMask.Text != "")
        {
            user.Phone = phoneMask.Text;
        }
        else
        {
            var ms = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Заполните телефон");
            ms.ShowAsync();
        }
        if (seriaMask.Text != "")
        {
            user.Seria = seriaMask.Text;
        }
        else
        {
            check = false;
            var ms = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Проверьте серию");
            ms.ShowAsync();
        }
        if (nomerMask.Text != "")
        {
            user.Nomer = nomerMask.Text;
        }
        else
        {
            check = false;
            var ms = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Проверьте номер паспорта");
            ms.ShowAsync();
        }
        if (mailUs.Text != "" && !mailUs.Text.StartsWith("@") && mailUs.Text.Contains("@")
            && !mailUs.Text.StartsWith(".") && mailUs.Text.Contains("."))
        {
            user.Mail = mailUs.Text;


        }
        else
        {
            check = false;
            var ms = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Проверьте email");
            ms.ShowAsync();
        }

        if (filename == null)
        {
            filename = "User.jpg";
            user.Image = filename;

        }
        else
        {
            File.Move(path, destpath);
            user.Image = filename;
        }
        if (primechanieInp.Text != "")
        {
            user.Primechanie = primechanieInp.Text;
        }
        else
        {
            check = false;
            var ms = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Проверьте примечание");
            ms.ShowAsync();
        }
        if (check)
        {
            Helper.context.Users.Add(user);
            Helper.context.SaveChanges();
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }


    }
}