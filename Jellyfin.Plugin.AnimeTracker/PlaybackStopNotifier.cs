using System.Threading.Tasks;
using MediaBrowser.Controller.Events;
using MediaBrowser.Controller.Library;
using Jellyfin.Plugin.AnimeTracker.APIs;

namespace Jellyfin.Plugin.AnimeTracker;

// https://github.com/float3/CorrectHorseBatteryStaple/blob/master/Jellyfin.Plugin.AnimeTracker/Notifiers/PlaybackStopNotifier.cs

/// <summary>
/// Playback stop notifier.
/// </summary>
public class PlaybackStopNotifier : IEventConsumer<PlaybackStopEventArgs>
{
    ///
    Jellyfin.Plugin.AnimeTracker.Configuration.PluginConfiguration Config;

    ///
    public PlaybackStopNotifier(Jellyfin.Plugin.AnimeTracker.Configuration.PluginConfiguration configuration)
    {
        Config = configuration;
    }

    ///
    public async Task OnEvent(PlaybackStopEventArgs eventArgs)
    {
        if (eventArgs.Item is null)
        {
            return;
        }

        if (eventArgs.Item.IsThemeMedia)
        {
            // Don't report theme song or local trailer playback.
            return;
        }

        if (eventArgs.Users.Count == 0)
        {
            // No users in playback session.
            return;
        }

        if (eventArgs.PlayedToCompletion)
        {
            foreach (var user in eventArgs.Users)
            {
                if (Config.Tracker == Configuration.Trackers.Both || Config.Tracker == Configuration.Trackers.MyAnimeList)
                {
                    await MAL.Update(eventArgs.MediaInfo, Config);
                }
                if (Config.Tracker == Configuration.Trackers.Both || Config.Tracker == Configuration.Trackers.AniList)
                {
                    await AniList.Update(eventArgs.MediaInfo, Config);
                }
            }
        }
    }
}