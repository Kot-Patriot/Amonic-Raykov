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
using System.Windows.Shapes;

namespace AMONIC
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private Offices _currentOffice = new Offices();
        private Users _currentUser = new Users();
        public AddEditWindow()
        {
            InitializeComponent();
            OfficeBox.ItemsSource = Session1_XXEntities.GetContext().Offices.ToList();
            //OfficeBox.ItemsSource = Session1_XXEntities1.GetContext().Users.ToList();
            DataContext = _currentUser;
        
        }
        // DisplayMemberPath = "Title"
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Page mainpage = new Page();
            mainpage.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentUser.Email))
                errors.AppendLine("Укажите email адрес");

            if (string.IsNullOrWhiteSpace(_currentUser.FirstName))
                errors.AppendLine("Укажите имя");

            if (string.IsNullOrWhiteSpace(_currentUser.LastName))
                errors.AppendLine("Укажите фамилию");

           // if (OfficeBox.Text == null)
          //      errors.AppendLine("Укажите офис");

            if (_currentUser.Birthdate == null)
                errors.AppendLine("Укажите дату рождения");

            if (OfficeBox.Text == null)
                errors.AppendLine("Выберите офис");

            if (string.IsNullOrWhiteSpace(_currentUser.Password))
                errors.AppendLine("Укажите пароль");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentUser.ID == 0)
                Session1_XXEntities.GetContext().Users.Add(_currentUser);


            try
            {
                Session1_XXEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Page mainwin = new Page();
                mainwin.Show();
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OfficeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
