using System.Linq;
using System.Windows;
using Artikelverwaltungssystem.Data;

namespace Artikelverwaltungssystem
{
    public partial class HistorieWindow : Window
    {
        private ArtikelDbContext _context;

        public HistorieWindow()
        {
            InitializeComponent();

            _context = new ArtikelDbContext();

            LadeHistorie();
        }

        private void LadeHistorie()
        {
            dgHistorie.ItemsSource =
                _context.Historien
                        .OrderByDescending(h => h.GeaendertAm)
                        .ToList();
        }
    }
}