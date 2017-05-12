using System.Collections.Generic;
using System.Threading.Tasks;

using cb_podcast.Models;

using iPodcastSearch;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace cb_podcast.Services
{
    public class PodcastEpisodeService
    {
        public async Task<IEnumerable<PodcastEpisodeModel>> GetDataAsync()
        {
            var feedUrl = "https://www.codingblocks.net/podcast-feed.xml";
            var podcast = await PodcastFeedParser.LoadFeedAsync(feedUrl);
            
            var data = podcast.Episodes.Select(x => new PodcastEpisodeModel
            {
                Title = x.Title,
                Description = x.PubDate.ToString(),
                Summary = x.Summary,
                Symbol = Symbol.Globe,
                MediaFileUrl = x.AudioFileUrl
            });

            return data;
        }
    }
}
