
namespace MusicaLogBL
{
    using MusicaLogDAL;
    using MusicaLogMDL;
    using System.Collections.Generic;

    public class AlbumBL
    {
        private IAlbumDAL _albumDAL;

        public AlbumBL()
        {
            _albumDAL = new AlbumDAL();
        }

        public Album GetAlbum(long Id)
        {
            try
            {
                return _albumDAL.GetAlbum(Id);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            
        }

        public IList<Album> GetAlbums(string albumTitle, string artistName)
        {
            try
            {
                return _albumDAL.GetAlbums(albumTitle, artistName);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            
        }

        public void UpdateAlbum(Album updateAlbum)
        {
            try
            {
                _albumDAL.UpdateAlbum(updateAlbum);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
           
        }

        public void CreateAlbum(Album newAlbum)
        {
            try
            {
                _albumDAL.CreateAlbum(newAlbum);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAlbum(long deleteAlbumId)
        {
            try
            {
                _albumDAL.DeleteAlbum(deleteAlbumId);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
