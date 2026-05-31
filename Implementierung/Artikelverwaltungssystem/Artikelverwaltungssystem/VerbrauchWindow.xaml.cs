using System;
using System.Linq;
using System.Windows;
using Artikelverwaltungssystem.Data;
using Artikelverwaltungssystem.Models;

namespace Artikelverwaltungssystem
{
    public partial class VerbrauchWindow : Window
    {
        private ArtikelDbContext _context;

        public VerbrauchWindow()
        {
            InitializeComponent();

            _context = new ArtikelDbContext();

            LadeDaten();
        }

        private void LadeDaten()
        {
            cmbVerbrauchsart.ItemsSource =
                _context.Verbrauchsarten.ToList();

            cmbAbteilung.ItemsSource =
                _context.Abteilungen.ToList();

            LadeVerbrauch();
        }

        private void LadeVerbrauch()
        {
            dgVerbrauch.ItemsSource =
                _context.Verbrauchsbuchungen
                    .OrderByDescending(v => v.VerwendetAm)
                    .ToList();
        }

        private void BtnBuchen_Click(object sender, RoutedEventArgs e)
        {
            if (cmbVerbrauchsart.SelectedItem == null ||
                cmbAbteilung.SelectedItem == null)
            {
                MessageBox.Show("Bitte alle Felder ausfüllen.");
                return;
            }

            int menge;

            if (!int.TryParse(txtMenge.Text, out menge))
            {
                MessageBox.Show("Bitte eine gültige Menge eingeben.");
                return;
            }

            Verbrauchsbuchung buchung =
                new Verbrauchsbuchung
                {
                    VerbrauchsartID =
                        (int)cmbVerbrauchsart.SelectedValue,

                    AbteilungsID =
                        (int)cmbAbteilung.SelectedValue,

                    Menge = menge,

                    VerwendetAm = DateTime.Now
                };

            _context.Verbrauchsbuchungen.Add(buchung);

            _context.SaveChanges();

            LadeVerbrauch();

            txtMenge.Clear();

            MessageBox.Show("Verbrauch wurde gebucht.");
        }
    }
}