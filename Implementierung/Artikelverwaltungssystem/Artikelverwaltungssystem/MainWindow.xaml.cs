using System.Linq;
using System.Windows;
using Artikelverwaltungssystem.Data;
using Artikelverwaltungssystem.Models;

namespace Artikelverwaltungssystem
{
    public partial class MainWindow : Window
    {
        private ArtikelDbContext _context;

        public MainWindow()
        {
            InitializeComponent();

            _context = new ArtikelDbContext();

            LadeArtikel();
        }

        private void LadeArtikel()
        {
            var artikelListe = _context.Artikel.ToList();

            dgArtikel.ItemsSource = artikelListe;
        }

        private void BtnSuchen_Click(object sender, RoutedEventArgs e)
        {
            string suche = txtSuche.Text;

            var artikel = _context.Artikel.ToList();

            var ergebnis = artikel.Where(a =>
                a.Bezeichnung.Contains(suche) ||
                a.Kategorie.Contains(suche) ||
                a.Inventarnummer.Contains(suche))
                .ToList();

            dgArtikel.ItemsSource = ergebnis;
        }

        private void BtnArtikelSpeichern_Click(object sender, RoutedEventArgs e)
        {
            Artikel neuerArtikel = new Artikel
            {
                Bezeichnung = txtBezeichnung.Text,
                Kategorie = txtKategorie.Text,
                Inventarnummer = txtInventarnummer.Text,
                Seriennummer = txtSeriennummer.Text,
                Status = txtStatus.Text,
                AbteilungsID = 1
            };

            _context.Artikel.Add(neuerArtikel);

            _context.SaveChanges();

            LadeArtikel();

            txtBezeichnung.Clear();
            txtKategorie.Clear();
            txtInventarnummer.Clear();
            txtSeriennummer.Clear();
            txtStatus.Clear();
        }
    }
}