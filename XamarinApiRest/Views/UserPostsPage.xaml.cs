using MediatR;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApiRest.Features.Queries;
using XamarinApiRest.Models;

namespace XamarinApiRest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPostsPage : ContentPage
    {
        private readonly IMediator _mediator;
        private int _userId;
        public ObservableCollection<Post> Posts { get; set; }
        public ObservableCollection<Post> FilteredPosts { get; set; }
        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged();
                    OnSearch();
                }
            }
        }

        public ICommand SearchCommand { get; set; }
        public UserPostsPage(int userId, IMediator mediator)
        {
            _mediator = mediator;
            InitializeComponent();
            Posts = new ObservableCollection<Post>();
            FilteredPosts = new ObservableCollection<Post>();
            SearchCommand = new Command(OnSearch);
            _userId = userId;
            LoadPosts();
            BindingContext = this;
        }

        private async void LoadPosts()
        {
            try
            {
                var posts = await _mediator.Send(new GetPostsQuery());
                foreach (var post in posts)
                {
                    Posts.Add(post);
                    FilteredPosts.Add(post);
                }

                PostsListView.ItemsSource = FilteredPosts.Where(t => t.UserId == _userId);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void OnSearch()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredPosts.Clear();
                foreach (var post in Posts)
                {
                    FilteredPosts.Add(post);
                }
            }
            else
            {
                FilteredPosts.Clear();
                foreach (var post in Posts.Where(p => p.Title.Contains(SearchQuery)))
                {
                    FilteredPosts.Add(post);
                }
            }
            PostsListView.ItemsSource = FilteredPosts;
        }


        private async void PostsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var post = e.Item as Post;
            if (post != null)
            {
                PostDetailPage detailPage = new PostDetailPage(post, _mediator);
                await Navigation.PushAsync(detailPage);
            }
        }

    }
}