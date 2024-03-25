using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSpatify
{
    internal class Music
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public Genre Genre { get; set; }
        public ulong Duration { get; set; } // in seconds
        // un TimeSpan pourrait être plus approprié
        public ulong NumberOfStreams { get; set; }
        // unsigned integer long : unsigned n'ira pas dans le négatif
        public string ImageUrl { get; set; }

        public Music(string title, string artist, Genre genre, ulong duration, ulong numberOfStreams, string imageUrl)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            Duration = duration;
            NumberOfStreams = numberOfStreams;
            ImageUrl = imageUrl;
            Database.MusicList.Add(this);
        }

        public override string ToString()
        {
            return $"{Artist} - {Title} [{Duration / 60}:{Duration % 60}] {Genre}, {NumberOfStreams} streams\n";
        }
    }
}
