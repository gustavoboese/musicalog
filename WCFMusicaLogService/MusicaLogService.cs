using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MusicaLogMDL;

namespace WCFMusicaLogService
{
    public class MusicaLogService : IMusicaLogService
    {
        MusicaLogBL.AlbumBL albumBL;
        public MusicaLogService()
        {
            albumBL = new MusicaLogBL.AlbumBL();
        }

        public void CreateAlbum(Album newAlbum)
        {
            albumBL.CreateAlbum(newAlbum);
        }

        public void DeleteAlbum(long deleteAlbumId)
        {
            albumBL.DeleteAlbum(deleteAlbumId);
        }

        public Album GetAlbum(long Id)
        {
            return albumBL.GetAlbum(Id);
        }

        public IList<Album> GetAlbums(string albumTitle, string artistName)
        {
            return albumBL.GetAlbums(albumTitle, artistName);
        }

        public void UpdateAlbum(Album updateAlbum)
        {
            albumBL.UpdateAlbum(updateAlbum);
        }
    }
}
