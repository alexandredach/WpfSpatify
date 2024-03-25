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
using static System.Net.Mime.MediaTypeNames;

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
            ClearSIngleImages();
            ClearSongList();

            List<Music> listOfPopSongs = Database.Search(Genre.Pop);

            for (int  i = 0; i < Database.Search(Genre.Pop).Count; i++)
            {
                int rowIndex = i + 1; // l'index des lignes commence à 1

                string rowName = "titleRow" + rowIndex.ToString(); // je concatène le nom des lignes avec l'index converti en string : titleRow1

                // je recherche le textBlock contenant le rowName précédent pour le modifier
                TextBlock textBlockToFill = FindName(rowName) as TextBlock;
                if (textBlockToFill != null)
                {
                    textBlockToFill.Text = $"{listOfPopSongs[i]}";
                    LoadAndResizeImage(listOfPopSongs[i].ImageUrl, rowIndex, 45, 45);
                }
            }
        }

        private void buttonRock_Click(object sender, RoutedEventArgs e)
        {
            ClearSIngleImages();
            ClearSongList();

            List<Music> listOfRockSongs = Database.Search(Genre.Rock);

            for (int i = 0; i < Database.Search(Genre.Rock).Count; i++)
            {
                int rowIndex = i + 1;

                string rowName = "titleRow" + rowIndex.ToString();

                TextBlock textBlockToFill = FindName(rowName) as TextBlock;
                if (textBlockToFill != null)
                {
                    textBlockToFill.Text = $"{listOfRockSongs[i]}";
                    LoadAndResizeImage(listOfRockSongs[i].ImageUrl, rowIndex, 45, 45);
                }
            }
        }

        private void buttonDance_Click(object sender, RoutedEventArgs e)
        {
            ClearSIngleImages();
            ClearSongList();

            List<Music> listOfDanceSongs = Database.Search(Genre.Dance);

            for (int i = 0; i < Database.Search(Genre.Dance).Count; i++)
            {
                int rowIndex = i + 1;

                string rowName = "titleRow" + rowIndex.ToString();

                TextBlock textBlockToFill = FindName(rowName) as TextBlock;
                if (textBlockToFill != null)
                {
                    textBlockToFill.Text = $"{listOfDanceSongs[i]}";
                    LoadAndResizeImage(listOfDanceSongs[i].ImageUrl, rowIndex, 45, 45);
                }
            }
        }

        private void buttonTrance_Click(object sender, RoutedEventArgs e)
        {
            ClearSIngleImages();
            ClearSongList();

            List<Music> listOfTranceSongs = Database.Search(Genre.Trance);

            for (int i = 0; i < Database.Search(Genre.Trance).Count; i++)
            {
                int rowIndex = i + 1;

                string rowName = "titleRow" + rowIndex.ToString();

                TextBlock textBlockToFill = FindName(rowName) as TextBlock;
                if (textBlockToFill != null)
                {
                    textBlockToFill.Text = $"{listOfTranceSongs[i]}";
                    LoadAndResizeImage(listOfTranceSongs[i].ImageUrl, rowIndex, 45, 45);
                }
            }
        }

        private void buttonRnb_Click(object sender, RoutedEventArgs e)
        {
            ClearSIngleImages();
            ClearSongList();

            List<Music> listOfRnbSongs = Database.Search(Genre.RnB);

            for (int i = 0; i < Database.Search(Genre.RnB).Count; i++)
            {
                int rowIndex = i + 1;

                string rowName = "titleRow" + rowIndex.ToString();

                TextBlock textBlockToFill = FindName(rowName) as TextBlock;
                if (textBlockToFill != null)
                {
                    textBlockToFill.Text = $"{listOfRnbSongs[i]}";
                    LoadAndResizeImage(listOfRnbSongs[i].ImageUrl, rowIndex, 45, 45);
                }
            }
        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            ClearSIngleImages();
            ClearSongList();

            List<Music> searchResult = Database.Search(searchBox.Text);

            for (int i = 0; i < searchResult.Count; i++)
            {
                int rowIndex = i + 1;

                string rowName = "titleRow" + rowIndex.ToString();

                TextBlock textBlockToFill = FindName(rowName) as TextBlock;
                if (textBlockToFill != null)
                {
                    textBlockToFill.Text = $"{searchResult[i]}";
                    LoadAndResizeImage(searchResult[i].ImageUrl, rowIndex, 45, 45);
                }
            }
        }

        private void FindAndCompareTextBlocks(DependencyObject parent, string searchString)
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is TextBlock textBlock)
                {
                    if (textBlock.Name == searchString)
                    {
                        MessageBox.Show("TextBlock trouvé avec le texte : " + searchString);
                    }
                }
                else
                {
                    // Si l'élément n'est pas un TextBlock, récursion pour parcourir ses enfants
                    FindAndCompareTextBlocks(child, searchString);
                }
            }
        }

        private void ClearSongList()
        {
            for (int i = 0; i < 7; i++)
            {
                int rowIndex = i + 1;
                string rowName = "titleRow" + rowIndex.ToString();
                TextBlock textBlockToEmpty = FindName(rowName) as TextBlock;
                if (textBlockToEmpty != null)
                {
                    textBlockToEmpty.Text = string.Empty;
                }
            }
        }

        private void ClearSIngleImages()
        {
            try
            {
                for (int i = 0; i < 7; i++)
                {
                    int rowIndex = i + 1;
                    string singleImgName = "singleImg" + rowIndex.ToString();
                    System.Windows.Controls.Image imageToFill = FindName(singleImgName) as System.Windows.Controls.Image;
                    imageToFill.Source = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors du chargement de la page : " + ex.Message);
            }
        }

        private void LoadAndResizeImage(string imageUrl, int index, int width, int height)
        {
            try
            {
                string singleImgName = "singleImg" + index.ToString();
                BitmapImage bitmapImage = new BitmapImage(new Uri(imageUrl));
                bitmapImage.DecodePixelWidth = width; // Redimensionner en largeur
                bitmapImage.DecodePixelHeight = height; // Redimensionner en hauteur
                System.Windows.Controls.Image imageToFill = FindName(singleImgName) as System.Windows.Controls.Image;
                if (imageToFill != null)
                {
                    imageToFill.Source = bitmapImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors du chargement de l'image : " + ex.Message);
            }
        }

    }
}