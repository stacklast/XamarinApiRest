using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApiRest.Models;

namespace XamarinApiRest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsPage : ContentPage
    {
        public UserDetailsPage(User user)
        {
            InitializeComponent();
            BindingContext = user;
        }
    }
}