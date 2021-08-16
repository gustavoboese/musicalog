using MusicaLogMDL;
using System.Collections.Generic;
using System.Linq;

namespace MusicaLogDAL
{
    public class AlbumDAL : IAlbumDAL
    {
        MusicaLogEntities context;

        public AlbumDAL()
        {
            context = new MusicaLogEntities();
        }

        public void CreateAlbum(Album newAlbum)
        {
            context.Album.Add(newAlbum);
            context.SaveChanges();
        }

        public void UpdateAlbum(Album updateAlbum)
        {

            Album albumToUpdate = context.Album.Where(e => e.Id == updateAlbum.Id).FirstOrDefault();

            albumToUpdate.ArtistName = updateAlbum.ArtistName;
            albumToUpdate.Stock = updateAlbum.Stock;
            albumToUpdate.Title = updateAlbum.Title;
            albumToUpdate.Type = updateAlbum.Type;

            context.SaveChanges();
        }

        public void DeleteAlbum(long deleteAlbumId)
        {
            Album albumToDelete = context.Album.Where(e => e.Id == deleteAlbumId).FirstOrDefault();

            context.Album.Remove(albumToDelete);
            context.SaveChanges();
        }

        public Album GetAlbum(long Id)
        {
            return context.Album.Where(e => e.Id == Id).FirstOrDefault(); ;
        }

        public List<Album> GetAlbums(string albumTitle, string artistName)
        {
            var retorno = context.ReturnAlbums(albumTitle, artistName);

            return retorno.ToList();
        }
    }
}
