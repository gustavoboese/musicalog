using MusicaLogMDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFMusicaLogService
{
    [ServiceContract]
    public interface IMusicaLogService
    {
        [OperationContract]
        Album GetAlbum(long Id);

        [OperationContract]
        IList<Album> GetAlbums(string albumTitle, string artistName);

        [OperationContract]
        void CreateAlbum(Album newAlbum);

        [OperationContract]
        void UpdateAlbum(Album updateAlbum);

        [OperationContract]
        void DeleteAlbum(long deleteAlbumId);

    }
}
