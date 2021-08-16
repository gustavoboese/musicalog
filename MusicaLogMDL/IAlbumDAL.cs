using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicaLogMDL
{
    public interface IAlbumDAL
    {
        void CreateAlbum(Album newAlbum);
        void UpdateAlbum(Album updateAlbum);
        void DeleteAlbum(long deleteAlbumId);
        Album GetAlbum(long Id);
        List<Album> GetAlbums(string albumTitle, string artistName);
    }
}
