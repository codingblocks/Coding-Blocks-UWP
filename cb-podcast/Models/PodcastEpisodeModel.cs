using System;
using Windows.Media.Core;
using Windows.UI.Xaml.Controls;

namespace cb_podcast.Models
{
    public class PodcastEpisodeModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string MediaFileUrl { get; set; }
        public MediaSource MediaFile {
            get
            {
                var uri = new Uri(MediaFileUrl);
                return MediaSource.CreateFromUri(uri);
            }
        }
        public Symbol Symbol { get; set; }

        public char SymbolAsChar
        {
            get { return (char)Symbol; }
        }
    }
}
