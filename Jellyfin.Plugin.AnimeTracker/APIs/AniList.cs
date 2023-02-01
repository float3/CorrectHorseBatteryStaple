using System;
using System.Threading.Tasks;
using MediaBrowser.Model.Dto;

namespace Jellyfin.Plugin.AnimeTracker.APIs;

/// <summary>
/// Playback stop notifier.
/// </summary>
public class AniList
{
    // https://github.com/Alkouille/douki/blob/master/src/ani_api/queries.rs
    internal static Task Update(BaseItemDto mediaInfo)
    {
        throw new NotImplementedException();
    }
}