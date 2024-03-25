using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSpatify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Database.InitDatabase();
        }

        private void buttonPop_Click(object sender, RoutedEventArgs e)
        {
            string listByGenre = Database.Search(Genre.Pop);
            dbSearchList.Text = listByGenre;
        }

        private void buttonRock_Click(object sender, RoutedEventArgs e)
        {
            string listByGenre = Database.Search(Genre.Rock);
            dbSearchList.Text = listByGenre;
        }

        private void buttonDance_Click(object sender, RoutedEventArgs e)
        {
            string listByGenre = Database.Search(Genre.Dance);
            dbSearchList.Text = listByGenre;
        }

        private void buttonTrance_Click(object sender, RoutedEventArgs e)
        {
            string listByGenre = Database.Search(Genre.Trance);
            dbSearchList.Text = listByGenre;
        }

        private void buttonRnb_Click(object sender, RoutedEventArgs e)
        {
            string listByGenre = Database.Search(Genre.RnB);
            dbSearchList.Text = listByGenre;
        }
    }
}