using MauiAVDApp2.Pages.Views;

namespace MauiAVDApp2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            Routing.RegisterRoute("MapPage", typeof(MapPage));
            Routing.RegisterRoute("BoatDetail", typeof(BoatDetail));
        }
    }
}
