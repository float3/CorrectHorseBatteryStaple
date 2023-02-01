using System;
using System.Threading.Tasks;
using MediaBrowser.Model.Dto;

namespace Jellyfin.Plugin.AnimeTracker.APIs;

/// <summary>
/// Playback stop notifier.
/// </summary>
public class MAL
{
    // https://github.com/SuperMarcus/myanimelist-api-specification#update-entries
    internal static Task Update(BaseItemDto mediaInfo)
    {
        throw new NotImplementedException();
    }
}