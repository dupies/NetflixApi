using System.ComponentModel;

namespace NetflixApi.Domain.WatchHistories;

public enum ShowType
{
    [Description("Movie")]
    Movie,
    [Description("Tv Show")]
    TVShow
}