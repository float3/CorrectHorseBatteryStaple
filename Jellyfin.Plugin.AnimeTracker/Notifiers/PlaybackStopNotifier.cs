using System.Threading.Tasks;
using MediaBrowser.Controller.Events;
using MediaBrowser.Controller.Library;

namespace Jellyfin.Plugin.AnimeTracker.Notifiers;

/// <summary>
/// Playback stop notifier.
/// </summary>
public class PlaybackStopNotifier : IEventConsumer<PlaybackStopEventArgs>
{
    ///
    public PlaybackStopNotifier(){}

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
        
        if(eventArgs.PlayedToCompletion)
        {
            foreach (var user in eventArgs.Users)
            {
               await Tracker.MarkCompleted(eventArgs.MediaInfo);
            }
        }
    }
}