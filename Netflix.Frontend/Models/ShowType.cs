using System.ComponentModel;

namespace Netflix.Frontend.Models;

public enum ShowType
{
    [Description("Movie")]
    Movie,
    [Description("Tv Show")]
    TVShow
}