using System.Windows;
using Artikelverwaltungssystem.Data;

namespace Artikelverwaltungssystem
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new ArtikelDbContext())
            {
                DbInitializer.Initialize(context);
            }
        }
    }
}