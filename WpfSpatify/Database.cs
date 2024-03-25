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

        public static string Search(Genre genre)
        {
            string listByGenre = null!;
            List<Music> result = MusicList
                .Where(m => m.Genre == genre)
                .OrderByDescending(m => m.NumberOfStreams)
                .ToList();
            foreach (Music music in result)
                listByGenre += music ;
            return listByGenre;
        }

        public static void Search(string titleChars)
        {
            List<Music> result = MusicList.Where(m => m.Title.Contains(titleChars)).ToList();

            result.Sort((i, j) => j.NumberOfStreams.CompareTo(i.NumberOfStreams));

            foreach (Music music in result)
            {
                Console.WriteLine(music);
            }
        }

        public static void InitDatabase()
        {
            MusicList = new List<Music>();

            new Music("Love Is Gonna Save Us", "Benny Benassi", Genre.Dance, 210, 3579362);

            new Music("Barbichette Song", "Afida TURNER", Genre.Rock, 135, 751330);

            new Music("Don't Shut Me Down", "ABBA", Genre.Pop, 192, 2530118);

            new Music("Love Is Gone", "David Guetta", Genre.Dance, 198, 876532025);

            new Music("Love Lalala", "Armin Van Bourré", Genre.Trance, 123, 1521);

            new Music("Where Is The Love", "Black Eyed Peas", Genre.RnB, 201, 3502464);
        }
    }
}
