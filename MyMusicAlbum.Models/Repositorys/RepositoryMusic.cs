using MyMusicAlbum.Models.Beans;
using MyMusicAlbum.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusicAlbum.Models.Repositorys
{
    public class RepositoryMusic : IRepository<Music>
    {
        private List<Music> musicList = new List<Music>();

        public void Create(Music item)
        {
            musicList.Add(item);
        }

        public void Delete(int id)
        {
            musicList[id].Disable();
        }

        public int NextId()
        {
            return musicList.Count;
        }

        public Music Read(int id)
        {
            return musicList[id];
        }

        public List<Music> ReadAll()
        {
            return musicList;
        }

        public void Update(Music item)
        {
            musicList[item.Id] = item;
        }
    }
}
