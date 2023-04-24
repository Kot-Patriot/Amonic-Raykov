using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AMONIC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static class Globals
        {
            public static int Role;

            public static Users userinfo { get; set; }
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Session1_XXEntities())
            {

                var auth = db.Users.AsNoTracking().FirstOrDefault(m => m.Email == Login.Text && m.Password == Password.Password);
                if (auth != null)
                {
                    Globals.Role = auth.RoleID;
                    Globals.userinfo = auth;
                    Page winavto = new Page();
                    winavto.Show();
                    Close();
                }
            //   else

          //      if (db.Users.AsNoTracking().FirstOrDefault(a => a.Active = "True");
            //    {
                    
            //    } надо доработать и мб сделать
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
