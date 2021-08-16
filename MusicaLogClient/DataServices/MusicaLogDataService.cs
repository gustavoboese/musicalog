using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicaLogClient.DataServices
{
    using MusicaLogClient.WCFMusicaLogService;
    using MusicaLogMDL;

    class MusicaLogDataService
    {
        private MusicaLogServiceClient _client;

        public MusicaLogDataService()
        {
            _client = new MusicaLogServiceClient();
        }

        public IList<Album> GetAlbums(string albumTitle, string artistName)
        {
            return _client.GetAlbums(albumTitle, artistName);
        }

        public Album GetAlbum(long Id)
        {
            return _client.GetAlbum(Id);
        }

        public void CreateAlbum(Album newAlbum)
        {
            _client.CreateAlbum(newAlbum);
        }

        public void UpdateAlbum(Album updateAlbum)
        {
            _client.UpdateAlbum(updateAlbum);
        }

        public void DeleteAlbum(long deleteAlbumId)
        {
            _client.DeleteAlbum(deleteAlbumId);
        }
    }
}
