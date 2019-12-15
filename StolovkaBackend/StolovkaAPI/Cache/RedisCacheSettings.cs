namespace StolovkaWebAPI.Cache
{
    /// <summary>
    /// Defines cache settings for Redis.
    /// </summary>
    public class RedisCacheSettings
    {
        public bool Enabled { get; set; }

        public string ConnectionString { get; set; }
    }
}