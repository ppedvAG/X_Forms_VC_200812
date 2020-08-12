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
        //Property zum Zwischenspeichern der Personenliste (ObservableCollection ist eine generische Liste, welche die GUI
        //automatisch über Veränderungen informiert
        public ObservableCollection<string> NamenListe { get; set; }

        //Konstruktor
        public MainPage()
        {
            //Initialisierung der UI (Xaml-Datei). Sollte immer erste Aktion des Konstruktors sein
            InitializeComponent();

            //Zuweisung von EventHandlern zu den Completed-Events, damit ein besserer Bedienfluss gegeben ist
            Ent_Vorname.Completed += (s, e) => Ent_Nachname.Focus();
            Ent_Nachname.Completed += Btn_Show_Clicked;

            //Initialisierung der Namesliste
            NamenListe = new ObservableCollection<string>()
            {
                "Anna Nass",
                "Rainer Zufall"
            };

            //Durch Setzen des BindingContextes nehmen Kurzbindungen aus dem XAML-Code automatisch Bezug auf die Properties
            //des im BindingContext gesetzten Objekts
            this.BindingContext = this;
        }

        //EventHandler
        private async void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            if (await DisplayAlert("Hallo Welt", "Geht es dir gut?", "Ja", "Nein"))
                //Neuzuweisung einer UI-Property über die x:Name-Property des Steuerelements
                Lbl_Output.Text = "Das ist schön";
            else
                Lbl_Output.Text = "Schade aber auch";


        }

        private async void Btn_Show_Clicked(object sender, EventArgs e)
        {
            if (Ent_Vorname.Text != String.Empty && Ent_Nachname.Text != String.Empty)
            {
                await DisplayAlert("Begrüßung", $"Hallo {Ent_Vorname.Text} {Ent_Nachname.Text}", "OK");

                //Erstellen eines neuen Listenelements (aus UI-Properties)
                NamenListe.Add(Ent_Vorname.Text + " " + Ent_Nachname.Text);
            }
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Löschung", "Soll diese Person wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                //Löschen eines Listeneintrags
                string person = (sender as MenuItem).CommandParameter.ToString();
                NamenListe.Remove(person);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Layouts.AbsoluteLay());

            //Navigation.PushModalAsync(new Layouts.RelativeLay());
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //Löschen der Liste
            NamenListe.Clear();
        }

        //Push-Navigation
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage 
            Navigation.PushAsync(new Navigation.TabbedBsp());

            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage, welche aber keinen 'Zurück'-Button anzeigt
            //Navigation.PushModalAsync(new Navigation.TabbedBsp());

        }
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Navigation.CarouselBsp());
        }
    }
}
