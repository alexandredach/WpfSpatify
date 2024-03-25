using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfSpatify
{
    internal class Database
    {
        public static List<Music> MusicList { get; set; }

        public static List<Music> Search(Genre genre)
        {
            List<Music> result = MusicList
                .Where(m => m.Genre == genre)
                .OrderByDescending(m => m.NumberOfStreams)
                .ToList();

            List<Music> listByGenre = new List<Music>();

            foreach (Music music in result)
            {
                listByGenre.Add(music);
            }
            return listByGenre;
        }

        public static List<Music> Search(string titleChars)
        {
            List<Music> result = MusicList.Where(m => m.Title.Contains(titleChars)).ToList();

            result.Sort((i, j) => j.NumberOfStreams.CompareTo(i.NumberOfStreams));

            return result;
        }

        public static void InitDatabase()
        {
            MusicList = new List<Music>();

            // Musiques Pop
            new Music("Shape of You", "Ed Sheeran", Genre.Pop, 233, 10000000, "https://cdns-images.dzcdn.net/images/cover/107c2b43f10c249077c1f7618563bb63/500x500.jpg");
            new Music("Uptown Funk", "Mark Ronson ft. Bruno Mars", Genre.Pop, 270, 9500000, "https://cdns-images.dzcdn.net/images/cover/3734366a73152d0367a83a4b09fd163f/500x500.jpg");
            new Music("Moi... Lolita", "Alizée", Genre.Pop, 241, 3656021, "https://m.media-amazon.com/images/I/719su8WQWTL._UF1000,1000_QL80_.jpg");
            new Music("Don't Shut Me Down", "ABBA", Genre.Pop, 192, 2530118, "https://www.gaydial.com/wp-content/uploads/2021/09/abba.jpg");

            // Musiques Rock
            new Music("Barbichette Song", "Afida Turner", Genre.Rock, 135, 751330, "https://i.scdn.co/image/ab67616d00001e02f5f51c019a7891c0ceb26fed");
            new Music("Sweet Child o' Mine", "Guns N' Roses", Genre.Rock, 356, 8000000, "https://i.discogs.com/XCXiemMRkFL2oLIAXcs8cqg8SBH-qevIrflVPm5N7KQ/rs:fit/g:sm/q:90/h:600/w:600/czM6Ly9kaXNjb2dz/LWRhdGFiYXNlLWlt/YWdlcy9SLTY4MDg5/MDctMTQ2NjcyNTA0/My02MDE2LmpwZWc.jpeg");
            new Music("Bohemian Rhapsody", "Queen", Genre.Rock, 355, 8500000, "https://m.media-amazon.com/images/I/61VWSXTDFfL._UF1000,1000_QL80_.jpg");

            // Musiques RnB
            new Music("Billie Jean", "Michael Jackson", Genre.RnB, 293, 9000000, "https://i.discogs.com/eQp1ptetDZBYuDxswI1icwXMWXk7PDU_IAJiOKJ-fm8/rs:fit/g:sm/q:40/h:300/w:300/czM6Ly9kaXNjb2dz/LWRhdGFiYXNlLWlt/YWdlcy9SLTE1Mjk5/Ni0xNDI3MTM5NDcx/LTE0MDkuanBlZw.jpeg");
            new Music("No Diggity", "Blackstreet ft. Dr. Dre", Genre.RnB, 286, 8500000, "https://upload.wikimedia.org/wikipedia/en/b/bc/No_Diggity.jpg");
            new Music("Where Is The Love", "Black Eyed Peas", Genre.RnB, 201, 3502464, "https://upload.wikimedia.org/wikipedia/en/a/a1/Whereisthelove_cover.jpg");

            // Musiques Trance
            new Music("Adagio for Strings", "Tiësto", Genre.Trance, 421, 7500000, "https://upload.wikimedia.org/wikipedia/en/9/9f/Adagio_for_strings_cover.jpg");
            new Music("Strobe", "Deadmau5", Genre.Trance, 579, 7200000, "https://i1.sndcdn.com/artworks-000463815333-nz78gb-t500x500.jpg");
            new Music("Blah Blah Blah", "Armin Van Buuren", Genre.Trance, 123, 1521, "https://m.media-amazon.com/images/I/61l6MNxB4mL._UF1000,1000_QL80_.jpg");

            // Musiques Dance
            new Music("Levels", "Avicii", Genre.Dance, 210, 9200000, "https://upload.wikimedia.org/wikipedia/en/2/2c/Levelssong.jpg");
            new Music("Titanium", "David Guetta ft. Sia", Genre.Dance, 245, 8900000, "https://cdns-images.dzcdn.net/images/cover/ecee8d1bd17c9b22857db1cdb9f5f5b8/500x500.jpg");
            new Music("Love Is Gone", "David Guetta", Genre.Dance, 198, 876532025, "https://upload.wikimedia.org/wikipedia/en/5/5b/David_Guetta-Love_Is_Gone.jpeg");
            new Music("On & On", "Armin Van Buuren", Genre.Dance, 153, 2566923, "https://upload.wikimedia.org/wikipedia/en/thumb/5/5a/Armin_van_Buuren_%26_Punctual_feat._Alika_-_On_%26_On.jpg/220px-Armin_van_Buuren_%26_Punctual_feat._Alika_-_On_%26_On.jpg");
            new Music("Cantatrice", "Xelakad feat. Brenda Lavodka", Genre.Dance, 185, 1243, "https://i1.sndcdn.com/artworks-000161246557-v91ew5-t500x500.jpg");
            new Music("Il Est Interdit", "Shanna", Genre.Dance, 180, 2454787, "https://m.media-amazon.com/images/I/51Ekhwys43L._UF1000,1000_QL80_.jpg");
            new Music("No Milk Today", "Royal Gigolos", Genre.Dance, 182, 15798332, "https://m.media-amazon.com/images/I/41S1FTE13XL._SR600%2C315_PIWhiteStrip%2CBottomLeft%2C0%2C35_SCLZZZZZZZ_FMpng_BG255%2C255%2C255.jpg");
        }
    }
}
