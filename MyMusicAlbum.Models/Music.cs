using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusicAlbum.Models
{
    public class Music : Entity
    {
        public string Name { get; set; }

        public string Singer { get; set; }

        public MusicalGenre Genre { get; set; }

        public DateTime Release { get; set; }

        public int likes { get; set; }
    }
}
