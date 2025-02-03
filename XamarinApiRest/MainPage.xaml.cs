using MediatR;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApiRest.Features.Queries;
using XamarinApiRest.Models;
using XamarinApiRest.Views;

namespace XamarinApiRest
{
    public partial class MainPage : ContentPage
    {
        private readonly IMediator _mediator;
        public ObservableCollection<Post> Posts { get; set; }
        public ObservableCollection<Post> FilteredPosts { get; set; }
        public string SearchQuery { get; set; }
        public ICommand SearchCommand { get; set; }
        public MainPage(IMediator mediator)
        {
            InitializeComponent();
            _mediator = mediator;
            BindingContext = this;
            Posts = new ObservableCollection<Post>();
            FilteredPosts = new ObservableCollection<Post>();
            SearchCommand = new Command(OnSearch);
            LoadPosts();
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
        }

        private async void PostsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var post = e.Item as Post;
            if (post != null)
            {
                DetailPage detailPage = new DetailPage(post);
                await Navigation.PushAsync(detailPage);
            }
        }
    }
}
