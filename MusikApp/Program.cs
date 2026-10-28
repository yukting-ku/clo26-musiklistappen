using Microsoft.Extensions.Configuration;
using MusikApp;

// Läser inställningar från appsettings.json (samma sätt som i hero_databas).
// Databasens sökväg ligger där, så du slipper skriva den i koden.
var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var connectionString = config.GetConnectionString("Default")
    ?? throw new InvalidOperationException("Hittar ingen connection string 'Default' i appsettings.json.");

// Börja här. Den här raden visar att inställningarna lästes in, ta bort den när du vill.
var db = new DbHandler(connectionString);
bool running = true;
while (running)
{
    Console.WriteLine("\n=== Musiklistappen ===");
    Console.WriteLine("1. Visa alla låtar");
    Console.WriteLine("2. Sök låt");
    Console.WriteLine("3. Lägg till låt");
    Console.WriteLine("4. Ta bort låt");
    Console.WriteLine("0. Avsluta");
    Console.Write("Välj: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            var songs = db.GetAllSongs();

            foreach (var song in songs)
            {
                Console.WriteLine(
                    $"{song.Id}. {song.Title} ({song.DurationSeconds} sekunder)");
            }
            break;

        case "2":
            Console.Write("Please write the song name: ");
            var searchText = Console.ReadLine() ?? "";
            var results = db.SearchSongs(searchText);

            foreach (var song in results)
            {
                Console.WriteLine(
                    $"{song.Id}. {song.Title} ({song.DurationSeconds} sekunder)");
            }

            if (results.Count == 0)
            {
                Console.WriteLine("Inga låtar hittades.");
            }
            break;

        case "3":
            Console.Write("Album ID: ");
            if (!int.TryParse(Console.ReadLine(), out int albumId))
            {
                Console.WriteLine("Ogiltigt album ID.");
                break;
            }

            Console.Write("Song title: ");
            var title = Console.ReadLine() ?? "";

            Console.Write("Duration in seconds: ");
            if (!int.TryParse(Console.ReadLine(), out int duration))
            {
                Console.WriteLine("Ogiltig längd.");
                break;
            }

            var newSong = new Song
            {
                AlbumId = albumId,
                Title = title,
                DurationSeconds = duration
            };

            db.AddSong(newSong);
            Console.WriteLine("Låten har lagts till!");
            break;

        case "4":
            Console.Write("Enter the song ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int songId))
            {
                Console.WriteLine("Invalid song ID.");
                break;
            }

            var songToDelete = db.GetSongById(songId);

            if (songToDelete == null)
            {
                Console.WriteLine("Song not found.");
                break;
            }

            Console.Write($"Delete '{songToDelete.Title}'? (y/n): ");
            var confirm = Console.ReadLine();

            if (confirm?.ToLower() == "y")
            {
                if (db.DeleteSong(songId))
                {
                    Console.WriteLine("Song deleted.");
                }
                else
                {
                    Console.WriteLine("Song could not be deleted.");
                }
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
            break;

        case "0":
            running = false;
            Console.WriteLine("Hej då!");
            break;

        default:
            Console.WriteLine("Ogiltigt val. Försök igen.");
            break;
    }
}
// Tips på ordning (se UPPGIFT.md):
//   1. Skriv ut huvudmenyn (alternativ numrerade 1-N) och läs in ett val med Console.ReadLine().
//      Skriv ut "Här kommer en lista senare" tills databasen är kopplad.
//   2. Skapa ett DbHandler-objekt: new DbHandler(connectionString)
//   3. Anropa DbHandlers metoder från menyn. Här ska ALDRIG SQL stå.
//   4. Avsluta snyggt när användaren väljer "Avsluta".
