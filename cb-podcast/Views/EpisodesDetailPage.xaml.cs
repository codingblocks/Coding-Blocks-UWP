using System.ComponentModel;
using System.Runtime.CompilerServices;

using cb_podcast.Models;
using cb_podcast.Services;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace cb_podcast.Views
{
    public sealed partial class EpisodesDetailPage : Page, INotifyPropertyChanged
    {
        private PodcastEpisodeModel _item;
        public PodcastEpisodeModel Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public EpisodesDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Item = e.Parameter as PodcastEpisodeModel;
        }

        private void WindowStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            if (e.OldState == NarrowState && e.NewState == WideState)
            {
                NavigationService.GoBack();
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
