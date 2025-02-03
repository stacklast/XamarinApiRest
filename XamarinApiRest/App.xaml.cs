using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;
using XamarinApiRest.Features.Commands;
using XamarinApiRest.Features.Queries;
using XamarinApiRest.Interfaces;
using XamarinApiRest.Services;

namespace XamarinApiRest
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        private IMediator _mediator;
        protected IMediator Mediator
        {
            get
            {
                if (_mediator == null)
                {
                    _mediator = ServiceProvider.GetRequiredService<IMediator>();
                }
                return _mediator;
            }
        }
        public App()
        {
            InitializeComponent();

            ConfigureServices();

            MainPage = new NavigationPage(new MainPage(Mediator));
        }

        private void ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            // Register HttpClient
            //serviceCollection.AddHttpClient();

            // Registro de MediatR y Handlers
            serviceCollection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AddPostCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeletePostCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdatePostCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetPostsQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetUsersQueryHandler).Assembly);
            });

            // Registro de servicios
            serviceCollection.AddSingleton<IApiService, ApiService>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
