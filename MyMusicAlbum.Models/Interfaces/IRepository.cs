using System.Collections.Generic;

namespace MyMusicAlbum.Models.Interfaces
{
    public interface IRepository<T> where T : class
    {             

        void Create(T item);

        T Read(int id);

        List<T> ReadAll();

        void Update(T item);

        void Delete(int id);

        int NextId();
    }
}
