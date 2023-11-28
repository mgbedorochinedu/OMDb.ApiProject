namespace OMDb.API.Options
{
    public class AppSettingsConfig
    {
        public Omdb Omdb { get; set; }

    }

    public class Omdb
    {
        public string OmdbURL { get; set; }
    }
}
