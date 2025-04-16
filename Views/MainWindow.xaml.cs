using guessing_app.Data;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace guessing_app.Views

{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private string SelectImagePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (openFileDialog.ShowDialog() == true) //law el user ekhtar file
            {
                return openFileDialog.FileName;
            }
            return string.Empty;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    DbContext context = new DbContext();
            //    context.TestConnection();
            //    MessageBox.Show("Connection successful!");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Connection failed: " + ex.Message);

            //}

        }

        
    }
}