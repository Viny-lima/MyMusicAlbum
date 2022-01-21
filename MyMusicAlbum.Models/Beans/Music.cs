using MyMusicAlbum.Models.Entities;
using MyMusicAlbum.Models.Enums;
using System;

namespace MyMusicAlbum.Models.Beans
{
    public class Music : Entity
    {
        public string Name { get; private set; }

        public string Singer { get; private set; }

        public Genre Genre { get; private set; }

        public int ReleaseYear { get; private set; }

        public bool Actived { get; private set; }

        public Music(int id, Genre genre, string name, string singer, int releaseYear)
        {
            this.Id = id;
            this.Genre = genre;
            this.Name = name;
            this.Singer = singer;
            this.ReleaseYear = releaseYear;
            this.Actived = true;
        }

        public override string ToString()
        {
            string musicString = "";
            musicString += $"|{Name} - {Singer}|" + Environment.NewLine;
            musicString += $"|{Genre} - {ReleaseYear}|" + Environment.NewLine;

            return musicString;
        }

        public void Disable()
        {
            Actived = false;
        }

    }
}
