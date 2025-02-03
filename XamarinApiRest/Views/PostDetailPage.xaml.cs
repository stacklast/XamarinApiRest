using MediatR;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApiRest.Features.Commands;
using XamarinApiRest.Models;

namespace XamarinApiRest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        private readonly IMediator _mediator;
        private Post _post;
        public PostDetailPage(Post post, IMediator mediator)
        {
            InitializeComponent();
            _post = post;
            _mediator = mediator;
            BindingContext = _post;
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var post = button?.CommandParameter as Post;

            var postUpdate = new Post { Title = post.Title, Body = post.Body, Id = post.Id, UserId = post.UserId };
            var success = await _mediator.Send(new UpdatePostCommand(post));

            if (success)
            {
                mensaje.Text = "Post Actualizado con Exito";
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var post = button?.CommandParameter as Post;

            var success = await _mediator.Send(new DeletePostCommand(post.Id));

            if (success)
            {
                mensaje.Text = "Post Eliminado con Exito";
            }
        }
    }
}