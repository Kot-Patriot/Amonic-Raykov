using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AMONIC
{
    /// <summary>
    /// Логика взаимодействия для Page.xaml
    /// </summary>
    public partial class Page : Window
    {
        Session1_XXEntities db = new Session1_XXEntities();
        public Page()
        {
            InitializeComponent();
            if (MainWindow.Globals.Role == 1)
            {
                AddUser.IsEnabled = true;
                EnbDis.IsEnabled = true;
                ChgRole.IsEnabled = true;
            }
            else
            {
                AddUser.IsEnabled = false;
                EnbDis.IsEnabled = false;
                ChgRole.IsEnabled = false;
            }
            //   DGridGrids.ItemsSource = Session1_XXEntities.GetContext().Users.ToList();
            var officesese = Session1_XXEntities.GetContext().Offices.ToList();
            officesese.Insert(0, new Offices
            {
                Title = "All offices"
            });
            ComboOffices.SelectedIndex = 0;
            ComboOffices.ItemsSource = officesese;
            UpdateTable();
          //  DGridGrids.ItemsSource = Session1_XXEntities.GetContext().Roles.ToList();
          //  DGridGrids.ItemsSource = Session1_XXEntities.GetContext().Users.ToList();

        }


        public void UpdateTable()
        {
            var thisUsers = db.Users.ToList();
            if (ComboOffices.SelectedIndex > 0 && ComboOffices.SelectedIndex  != 1)
            {
                thisUsers = thisUsers.Where(p => p.OfficeID == ComboOffices.SelectedIndex + 1).ToList();
            }
            else if (ComboOffices.SelectedIndex == 1)
            {
                thisUsers = thisUsers.Where(p => p.Offices.Title == "Abu dhabi").ToList();
            }
            DGridGrids.ItemsSource = thisUsers;
        }
        private void MenuItemAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addeditwin = new AddEditWindow();
            addeditwin.Show();
            this.Close();
            addeditwin.Focus();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow winavto = new MainWindow();
            winavto.Show();
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         //   ComboOffices.ItemsSource = Session1_XXEntities.GetContext().Offices.ToList();
        }

        private void All_offices(object sender, SelectionChangedEventArgs e)
        {
            UpdateTable();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Session1_XXEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGridGrids.ItemsSource = Session1_XXEntities.GetContext().Users.ToList();
        }

        private void EnbDis_click(object sender, RoutedEventArgs e)
        {
            var enbdis = DGridGrids.SelectedItems.Cast<Users>().ToList();
            int userid = enbdis.FirstOrDefault().ID;
            Users users = db.Users.Find(userid);
            if (users.Active == true)
            {
                users.Active = false;
            }
            else
            {
                users.Active = true;
            }
            db.SaveChanges();
            UpdateTable();
        }

        private void ButtonChangeRole_Click(object sender, RoutedEventArgs e)
        {
            Users user = DGridGrids.SelectedItem as Users;
            if (user.RoleID == 1)
            {
                user.RoleID = 2;
                MessageBox.Show("Роль изменена на " + "User");
            }
            else
            {
                user.RoleID = 1;
                MessageBox.Show("Роль изменена на " + "Administrator");
            }
            Session1_XXEntities.GetContext().SaveChanges();
            Session1_XXEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            UpdateTable();
            DGridGrids.ItemsSource = Session1_XXEntities.GetContext().Users.ToList();
        }
    }
}
