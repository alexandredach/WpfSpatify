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
            DisplayListByGenre(Genre.Pop);
        }

        private void buttonRock_Click(object sender, RoutedEventArgs e)
        {
            DisplayListByGenre(Genre.Rock);
        }

        private void buttonDance_Click(object sender, RoutedEventArgs e)
        {
            DisplayListByGenre(Genre.Dance);
        }

        private void buttonTrance_Click(object sender, RoutedEventArgs e)
        {
            DisplayListByGenre(Genre.Trance);
        }

        private void buttonRnb_Click(object sender, RoutedEventArgs e)
        {
            DisplayListByGenre(Genre.RnB);
        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            ClearSingleImages();
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

        private void ClearSingleImages()
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

        private void DisplayListByGenre(Genre genre)
        {
            ClearSingleImages();
            ClearSongList();

            List<Music> listOfSongs = Database.Search(genre);

            for (int i = 0; i < Database.Search(genre).Count; i++)
            {
                int rowIndex = i + 1; // l'index des lignes commence à 1

                string rowName = "titleRow" + rowIndex.ToString(); // je concatène le nom des lignes avec l'index converti en string : titleRow1

                // je recherche le textBlock contenant le rowName précédent pour le modifier
                TextBlock textBlockToFill = FindName(rowName) as TextBlock;
                if (textBlockToFill != null)
                {
                    textBlockToFill.Text = $"{listOfSongs[i]}";
                    LoadAndResizeImage(listOfSongs[i].ImageUrl, rowIndex, 45, 45);
                }
            }
        }

    }
}