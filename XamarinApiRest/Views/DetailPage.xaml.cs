using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApiRest.Models;

namespace XamarinApiRest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage // Change this line
    {
        public DetailPage(Post post)
        {
            InitializeComponent();
            BindingContext = post;
        }
    }
}