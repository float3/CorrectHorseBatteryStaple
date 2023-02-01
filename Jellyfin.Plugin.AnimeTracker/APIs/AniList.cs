using System;
using System.Threading.Tasks;
using MediaBrowser.Model.Dto;
using GraphQL.Builders;

namespace Jellyfin.Plugin.AnimeTracker.APIs;

/// <summary>
/// Playback stop notifier.
/// </summary>
public class AniList
{
    // https://github.com/Alkouille/douki/blob/master/src/ani_api/queries.rs



    const string QL_URL = "https://graphql.anilist.co";
    const string TOKEN_URL = "https://anilist.co/api/v2/oauth/authorize";
    const string CLIENT_ID = "5253";
    const string SCHEMA_FILE = "schema.graphql";


    enum MediaListStatus
    {
        Current,
        Planning,
        Completed,
        Dropped,
        Paused,
        Repeating,
    }

    struct MutateEntryArguments
    {
        int? id;
        int mediaId;
        MediaListStatus? mediaStatus;
        string? notes;
        int? priority;
        int? progress;
        int? progress_volumes;
        DateOnly? startedAt;
    }



    ///
    public static Task Update(BaseItemDto mediaInfo, Configuration.PluginConfiguration config)
    {
        throw new NotImplementedException();
    }
}