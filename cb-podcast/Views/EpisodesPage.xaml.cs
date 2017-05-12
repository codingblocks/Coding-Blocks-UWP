using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using cb_podcast.Models;
using cb_podcast.Services;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace cb_podcast.Views
{
    public sealed partial class EpisodesPage : Page, INotifyPropertyChanged
    {
        private PodcastEpisodeModel _selected;
        public PodcastEpisodeModel Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<PodcastEpisodeModel> SampleItems { get; private set; } = new ObservableCollection<PodcastEpisodeModel>();

        public EpisodesPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync() 
        {
            SampleItems.Clear(); 

            var service = new PodcastEpisodeService(); 
            var data = await service.GetDataAsync(); 

            foreach (var item in data) 
            {
                SampleItems.Add(item); 
            }
            Selected = SampleItems.First(); 
        }

        private void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e?.ClickedItem as PodcastEpisodeModel;
            if (item != null)
            {
                if (WindowStates.CurrentState == NarrowState)
                {
                    NavigationService.Navigate<Views.EpisodesDetailPage>(item);
                }
                else
                {
                    Selected = item;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
