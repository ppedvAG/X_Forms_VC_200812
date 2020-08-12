using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace X_Forms
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> NamenListe { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Ent_Vorname.Completed += (s, e) => Ent_Nachname.Focus();
            Ent_Nachname.Completed += Btn_Show_Clicked;

            NamenListe = new ObservableCollection<string>()
            {
                "Anna Nass",
                "Rainer Zufall"
            };

            this.BindingContext = this;
        }

        private async void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Hallo Welt", "Geht es dir gut?", "Ja", "Nein"))
                Lbl_Output.Text = "Das ist schön";
            else
                Lbl_Output.Text = "Schade aber auch";


        }

        private async void Btn_Show_Clicked(object sender, EventArgs e)
        {
            if (Ent_Vorname.Text != String.Empty && Ent_Nachname.Text != String.Empty)
            {
                await DisplayAlert("Begrüßung", $"Hallo {Ent_Vorname.Text} {Ent_Nachname.Text}", "OK");

                NamenListe.Add(Ent_Vorname.Text + " " + Ent_Nachname.Text);
            }
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Löschung", "Soll diese Person wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                string person = (sender as MenuItem).CommandParameter.ToString();
                NamenListe.Remove(person);
            }
        }
    }
}
