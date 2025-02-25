namespace MusicHub
{
    using System;
    using System.Text;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            const int minDuration = 4;
            string soungsInfo = ExportSongsAboveDuration(context, minDuration);
            Console.WriteLine(soungsInfo);
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();
            TimeSpan durationSpan = TimeSpan.FromSeconds(duration);

            var songs = context.Songs
                .Where(s => s.Duration > durationSpan)
                .Select(s => new
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    AlbumProducer = (s.Album != null) ? (s.Album.Producer != null ? s.Album.Producer.Name : null) : (null),
                    SongDuration = s.Duration.ToString("c"),
                    SongPerformers = s.SongPerformers
                        .Select(sp => new
                        {
                            PerformerFirstName = sp.Performer.FirstName,
                            PerformerLastName = sp.Performer.LastName,
                        })
                        .OrderBy(p => p.PerformerFirstName)
                        .ThenBy(p => p.PerformerLastName)
                        .ToArray()
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToArray();

            int index = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{index++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");

                foreach (var performer in song.SongPerformers)
                {
                    sb.AppendLine($"---Performer: {performer.PerformerFirstName} {performer.PerformerLastName}");
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.SongDuration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
