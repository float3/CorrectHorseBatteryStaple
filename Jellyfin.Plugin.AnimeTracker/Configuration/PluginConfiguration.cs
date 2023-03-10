using MediaBrowser.Model.Plugins;
using System.Security;

namespace Jellyfin.Plugin.AnimeTracker.Configuration;

/// <summary>
/// choice of Tracker.
/// </summary>
public enum Trackers
{
    /// <summary>
    /// None.
    /// </summary>
    None = 0x00,

    /// <summary>
    /// AniList.
    /// </summary>
    AniList = 0x01,

    /// <summary>
    /// MyAnimeList.
    /// </summary>
    MyAnimeList = 0x10,

    /// <summary>
    /// Both.
    /// </summary>
    Both = 0x11,
}

/// <summary>
/// Plugin configuration.
/// </summary>
public class PluginConfiguration : BasePluginConfiguration
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PluginConfiguration"/> class.
    /// </summary>
    public PluginConfiguration()
    {
        Tracker = Trackers.AniList;
        MALUsername = new();
        MALPassword = new();
        AniListUsername = new();
        AniListPassword = new();
    }

    /// <summary>
    /// Gets or sets the Tracker.
    /// </summary>
    public Trackers Tracker { get; set; }

    /// <summary>
    /// MAL Username.
    /// </summary>
    public SecureString MALUsername;


    /// <summary>
    /// MALPassword.
    /// </summary>
    public SecureString MALPassword;

    /// <summary>
    /// Anilist Username.
    /// </summary>
    public SecureString AniListUsername;

    /// <summary>
    /// AniList Password.
    /// </summary>
    public SecureString AniListPassword;
}
