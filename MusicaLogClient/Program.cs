
namespace MusicaLogClient
{
    using MusicaLogClient.DataServices;
    using MusicaLogMDL;
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static MusicaLogDataService _service;

        // Constants
        private const string Quit = "Q";
        private const string Edit = "E";
        private const string Delete = "D";
        private const string New = "N";
        private const string SearchAlbums = "S";

        static void Main(string[] args)
        {
            _service = new MusicaLogDataService();

            // Space so that ToUpper Doesnt Crashes!
            string userInput = "";

            while (userInput.ToUpper() != Quit)
            {
                Console.WriteLine("---------------");
                Console.WriteLine("N) Enter a new Album");
                Console.WriteLine("S) Search Albums");
                Console.WriteLine("E) Edit Album");
                Console.WriteLine("D) Delete Album");
                Console.WriteLine("Q) Quit");
                Console.Write("Please enter a command: ");

                userInput = Console.ReadLine().ToUpper();

                if (userInput == SearchAlbums)
                {
                    ListAlbums();
                }
                else if (userInput == New)
                {
                    EnterAlbum();
                }
                else if (userInput == Edit)
                {
                    Album album = FindAlbum();
                    EditAlbum(album);
                }
                else if (userInput == Delete)
                {
                    Album album = FindAlbum();
                    DeleteAlbum(album);
                }
            }
        }

        private static Album FindAlbum()
        {
            try
            {
                Console.WriteLine("---------------");
                Console.Write("Album Id? ");
                var albumId = Console.ReadLine();

                Int64.TryParse(albumId, out long parsedAlbumId);
                var album = _service.GetAlbum(parsedAlbumId);
                DisplayAlbum(album);
                return album;
            }
            catch (Exception ex)
            {
                Console.Write($"Error: {ex.ToString()}");
            }

            return null;
        }

        private static void EditAlbum(Album album)
        {
            try
            {
                Console.WriteLine("---------------");
                Console.WriteLine("New Data");
                Console.WriteLine("---------------");

                Console.WriteLine($"Album Title? Actual: {album.Title}");
                var albumTitle = Console.ReadLine();

                Console.WriteLine($"Artist Name? Actual: {album.ArtistName}");
                var artistName = Console.ReadLine();

                Console.WriteLine($"Type? Actual: {album.Type}");
                var type = Console.ReadLine();

                Console.WriteLine($"Stock? Actual: {album.Stock}");
                var stock = Console.ReadLine();

                album.ArtistName = artistName;
                album.Stock = Convert.ToInt32(stock);
                album.Title = albumTitle;
                album.Type = type;

                _service.UpdateAlbum(album);

                Console.Clear();
                Console.WriteLine("---------------");
                Console.WriteLine("Album Updated!");
                Console.WriteLine("---------------");
                album = _service.GetAlbum(album.Id);
                DisplayAlbum(album);
            }
            catch (Exception ex)
            {
                Console.Write($"Error: {ex.ToString()}");
            }
            
        }

        private static void EnterAlbum()
        {
            try
            {
                Console.WriteLine("---------------");
                Console.Write("Album Title? ");
                var albumTitle = Console.ReadLine();

                Console.Write("Artist Name? ");
                var artistName = Console.ReadLine();

                Console.Write("Type? ");
                var type = Console.ReadLine();

                Console.Write("Stock? ");
                var stock = Console.ReadLine();

                Album album = new Album
                {
                    ArtistName = artistName,
                    Stock = Convert.ToInt32(stock),
                    Title = albumTitle,
                    Type = type
                };

                _service.CreateAlbum(album);

                Console.Clear();
                Console.WriteLine("---------------");
                Console.WriteLine("Album Inserted!");
                Console.WriteLine("---------------");

                SearchAndList(string.Empty, string.Empty);
            }
            catch (Exception ex)
            {
                Console.Write($"Error: {ex.ToString()}");
            }
            
        }

        static void ListAlbums()
        {
            try
            {
                string response = String.Empty, albumTitle = String.Empty, artistName = String.Empty;
                Console.WriteLine("---------------");

                while (response.ToUpper() != "Y" && response.ToUpper() != "N")
                {
                    Console.WriteLine("Do you want to filter? (Y/N)");
                    response = Console.ReadLine();
                }

                if (response.ToUpper() == "Y")
                {
                    Console.Write("Album Title? ");
                    albumTitle = Console.ReadLine();

                    Console.Write("Artist Name? ");
                    artistName = Console.ReadLine();
                }

                SearchAndList(albumTitle, artistName);
            }
            catch (Exception ex)
            {
                Console.Write($"Error: {ex.ToString()}");
            }
        }

        private static void SearchAndList(string albumTitle, string artistName)
        {
            IList<Album> albums = _service.GetAlbums(albumTitle, artistName);

            foreach (Album album in albums)
            {
                DisplayAlbum(album);
            }
        }

        private static void DisplayAlbum(Album album)
        {
            Console.WriteLine("---------------");
            Console.WriteLine($"Album Id: {album.Id} - Title {album.Title}");
            Console.WriteLine($"Artist: {album.ArtistName}, Type: {album.Type}, Stock: {album.Stock}");
            Console.WriteLine("---------------");
        }

        private static void DeleteAlbum(Album album)
        {
            try
            {
                string response = String.Empty;
                Console.WriteLine("---------------");

                while (response.ToUpper() != "Y" && response.ToUpper() != "N")
                {
                    Console.WriteLine("Do you want to delete? (Y/N)");
                    response = Console.ReadLine();
                }

                if (response.ToUpper() == "Y")
                {
                    _service.DeleteAlbum(album.Id);

                    Console.Clear();
                    Console.WriteLine("---------------");
                    Console.WriteLine("Album Deleted!");
                    Console.WriteLine("---------------");
                }
            }
            catch (Exception ex)
            {
                Console.Write($"Error: {ex.ToString()}");
            }

        }
    }
}
