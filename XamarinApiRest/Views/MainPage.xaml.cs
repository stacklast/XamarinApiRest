using MediatR;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XamarinApiRest.Features.Queries;
using XamarinApiRest.Models;
using XamarinApiRest.Services;
using XamarinApiRest.Views;

namespace XamarinApiRest
{
    public partial class MainPage : ContentPage
    {
        private readonly IMediator _mediator;
        public ObservableCollection<User> Users { get; set; }

        public MainPage(IMediator mediator)
        {
            InitializeComponent();
            _mediator = mediator;
            Users = new ObservableCollection<User>();
            BindingContext = this;
            LoadUsers();
        }

        private async void LoadUsers()
        {
            try
            {
                var users = await _mediator.Send(new GetUsersQuery());
                foreach (var user in users)
                {
                    Users.Add(user);
                }
                UsersListView.ItemsSource = Users;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }


        private async void ViewPostsButton_Clicked(object sender, EventArgs e)
        {

            var button = sender as Button;
            if (button?.CommandParameter is int userId)
            {
                var currentPage = Navigation.NavigationStack.LastOrDefault();
                if (currentPage != null)
                {
                    await NavigationService.NavigateWithAnimation(currentPage, new UserPostsPage(userId, _mediator));
                }
            }
        }

        private async void ViewDetailsButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var user = button?.CommandParameter as User;
            if (user != null)
            {
                var currentPage = Navigation.NavigationStack.LastOrDefault();
                if (currentPage != null)
                {
                    await NavigationService.NavigateWithAnimation(currentPage, new UserDetailsPage(user));
                }
            }
        }

        private async void UsersListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var button = sender as Button;
            var user = button?.CommandParameter as User;
            if (user != null)
            {
                var currentPage = Navigation.NavigationStack.LastOrDefault();
                if (currentPage != null)
                {
                    await NavigationService.NavigateWithAnimation(currentPage, new UserDetailsPage(user));
                }
            }
        }
    }
}
