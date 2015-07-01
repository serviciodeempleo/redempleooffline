using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
using System.Data.SQLite;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using PropertyChanged;


namespace RedEmpleoOffLine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

                 String connectionString;
                 SQLiteConnection connection;

                 String SQLInsert = "INSERT INTO User(Name, Surname) VALUES(?, ?)";
                 String SQLUpdate = "UPDATE User SET Name = ?, Surname = ? where UserId = ?";
                 String SQLSelect = "SELECT * FROM User";
                 String SQLDelete = "DELETE FROM User WHERE UserId = ?";
            
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);

            connection.Open();
            SQLiteCommand cmd2 = new SQLiteCommand("SELECT [IdCodigo],[nombre] FROM [Departamento]", connection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
                {
                    ComboBoxItem var2 = new ComboBoxItem();
                    var2.Tag =  dr[0].ToString();
                    var2.Content =  dr[1].ToString();
                    listDepartamentos.Items.Add(var2);
                }
            listDepartamentos.SelectedItem = listDepartamentos.Items.GetItemAt(0);
            cargarmun();
            connection.Close();
        }
        
       
        public void cargarmun(){
            listMunicipios.Items.Clear();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand cmdMUN = new SQLiteCommand("SELECT [IdCodigo],[nombre] FROM [Municipio] WHERE [department_id] ='" + ((ComboBoxItem)listDepartamentos.SelectedItem).Tag.ToString() + "'", connection);
            SQLiteDataAdapter dAMUN = new SQLiteDataAdapter(cmdMUN);
            DataTable dtMUN = new DataTable();
            dAMUN.Fill(dtMUN);
            foreach (DataRow dr in dtMUN.Rows)
            {
                ComboBoxItem var2 = new ComboBoxItem();
                var2.Tag = dr[0].ToString();
                var2.Content = dr[1].ToString();
                listMunicipios.Items.Add(var2);
            }
            listMunicipios.SelectedItem = listMunicipios.Items.GetItemAt(0);
            connection.Close();
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;
            if (date == null)
            {
                // ... A null object.
                //this.Title = "No date";
            }
            else
            {
                // ... No need to display the time.
                //this.Title = date.Value.ToShortDateString();
            }
        }


        private void Grid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void listDepartamentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBoxResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //if (result == MessageBoxResult.Yes)
            //{
            //    Application.Current.Shutdown();
            //}
            cargarmun();
        }
    }
}
