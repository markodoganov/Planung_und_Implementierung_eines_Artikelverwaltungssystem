using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Artikelverwaltungssystem.Data;
using Artikelverwaltungssystem.Models;

namespace Artikelverwaltungssystem
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ArtikelDbContext _context;

        private Artikel ausgewaehlterArtikel;

        private int alteAbteilungsID;

        private ObservableCollection<Artikel> _artikelListe;

        public ObservableCollection<Artikel> ArtikelListe
        {
            get { return _artikelListe; }
            set
            {
                _artikelListe = value;
                OnPropertyChanged(nameof(ArtikelListe));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            _context = new ArtikelDbContext();

            DataContext = this;

            LadeAbteilungen();
            LadeArtikel();
        }

        private void LadeAbteilungen()
        {
            cmbAbteilung.ItemsSource =
                _context.Abteilungen.ToList();

            cmbAbteilung.SelectedIndex = 0;
        }

        private void LadeArtikel()
        {
            ArtikelListe = new ObservableCollection<Artikel>(
                _context.Artikel.ToList());
        }

        private void TxtSuche_TextChanged(object sender, TextChangedEventArgs e)
        {
            string suche = txtSuche.Text.ToLower();

            ArtikelListe = new ObservableCollection<Artikel>(
                _context.Artikel
                    .Where(a =>
                        a.Bezeichnung.ToLower().Contains(suche) ||
                        a.Kategorie.ToLower().Contains(suche) ||
                        a.Inventarnummer.ToLower().Contains(suche))
                    .ToList());
        }

        private void dgArtikel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ausgewaehlterArtikel = dgArtikel.SelectedItem as Artikel;
            alteAbteilungsID = ausgewaehlterArtikel.AbteilungsID;

            if (ausgewaehlterArtikel == null)
                return;

            txtBezeichnung.Text = ausgewaehlterArtikel.Bezeichnung;
            txtKategorie.Text = ausgewaehlterArtikel.Kategorie;
            txtInventarnummer.Text = ausgewaehlterArtikel.Inventarnummer;
            txtSeriennummer.Text = ausgewaehlterArtikel.Seriennummer;
            txtStatus.Text = ausgewaehlterArtikel.Status;

            cmbAbteilung.SelectedValue =
                ausgewaehlterArtikel.AbteilungsID;
        }

        private void BtnArtikelSpeichern_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAbteilung.SelectedItem == null)
            {
                MessageBox.Show("Bitte eine Abteilung auswählen.");
                return;
            }

            Artikel neuerArtikel = new Artikel
            {
                Bezeichnung = txtBezeichnung.Text,
                Kategorie = txtKategorie.Text,
                Inventarnummer = txtInventarnummer.Text,
                Seriennummer = txtSeriennummer.Text,
                Status = txtStatus.Text,
                AbteilungsID =
                    (int)cmbAbteilung.SelectedValue
            };

            _context.Artikel.Add(neuerArtikel);

            _context.SaveChanges();

            LadeArtikel();

            LeereFelder();

            MessageBox.Show("Artikel erfolgreich gespeichert.");
        }

        private void BtnArtikelAktualisieren_Click(object sender, RoutedEventArgs e)
        {
            if (ausgewaehlterArtikel == null)
            {
                MessageBox.Show("Bitte zuerst einen Artikel auswählen.");
                return;
            }

            int neueAbteilungsID =
                (int)cmbAbteilung.SelectedValue;

            if (alteAbteilungsID != neueAbteilungsID)
            {
                string alteAbteilung =
                    _context.Abteilungen
                        .First(a => a.AbteilungsID == alteAbteilungsID)
                        .Name;

                string neueAbteilung =
                    _context.Abteilungen
                        .First(a => a.AbteilungsID == neueAbteilungsID)
                        .Name;

                Historie historie = new Historie
                {
                    ArtikelID = ausgewaehlterArtikel.ArtikelID,
                    AlteAbteilung = alteAbteilung,
                    NeueAbteilung = neueAbteilung,
                    GeaendertAm = DateTime.Now
                };

                _context.Historien.Add(historie);
            }

            ausgewaehlterArtikel.Bezeichnung =
                txtBezeichnung.Text;

            ausgewaehlterArtikel.Kategorie =
                txtKategorie.Text;

            ausgewaehlterArtikel.Inventarnummer =
                txtInventarnummer.Text;

            ausgewaehlterArtikel.Seriennummer =
                txtSeriennummer.Text;

            ausgewaehlterArtikel.Status =
                txtStatus.Text;

            ausgewaehlterArtikel.AbteilungsID =
                neueAbteilungsID;

            _context.SaveChanges();

            LadeArtikel();

            MessageBox.Show("Artikel wurde aktualisiert.");
        }

        private void BtnLoeschen_Click(object sender, RoutedEventArgs e)
        {
            Artikel artikel =
                dgArtikel.SelectedItem as Artikel;

            if (artikel == null)
            {
                MessageBox.Show(
                    "Bitte zuerst einen Artikel auswählen.");
                return;
            }

            MessageBoxResult result =
                MessageBox.Show(
                    "Möchten Sie den Artikel wirklich löschen?",
                    "Bestätigung",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _context.Artikel.Remove(artikel);

                _context.SaveChanges();

                LadeArtikel();

                LeereFelder();

                MessageBox.Show("Artikel wurde gelöscht.");
            }
        }

        private void BtnHistorie_Click(object sender, RoutedEventArgs e)
        {
            HistorieWindow historieWindow =
                new HistorieWindow();

            historieWindow.ShowDialog();
        }

        private void BtnVerbrauch_Click(object sender, RoutedEventArgs e)
        {
            VerbrauchWindow verbrauchWindow =
                new VerbrauchWindow();

            verbrauchWindow.ShowDialog();
        }

        private void LeereFelder()
        {
            txtBezeichnung.Clear();
            txtKategorie.Clear();
            txtInventarnummer.Clear();
            txtSeriennummer.Clear();
            txtStatus.Clear();

            cmbAbteilung.SelectedIndex = 0;

            ausgewaehlterArtikel = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}