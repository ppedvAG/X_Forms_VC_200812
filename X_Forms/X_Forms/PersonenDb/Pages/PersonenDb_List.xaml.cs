using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X_Forms.PersonenDb.Model;
using X_Forms.PersonenDb.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.PersonenDb.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonenDb_List : ContentPage
    {
        public PersonenDb_List()
        {
            //GUI-Initialisierung
            InitializeComponent();

            //Zuweisung der lokalen Liste mit den Datenbank-Inhalten
            StaticObjects.PersonenListe = StaticObjects.PersonenDb.GetPeople();

            //Aktualisieren der GUI
            RefreshPage();
        }

        //EventHandler zum Löschen einer Person
        private async void CaMenu_Delete_Clicked(object sender, EventArgs e)
        {
            //Cast des Inhalts der CommandParameter-Property des Sender-Objekts (das ausgewählte ListView-Item) in Person-Objekt
            Model.Person p = (sender as MenuItem).CommandParameter as Model.Person;

            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Löschen", $"Soll {p.Vorname} {p.Nachname} wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                //Löschen aus lokaler Liste
                StaticObjects.PersonenListe.Remove(p);
                //Löschen aus Datenbank
                StaticObjects.PersonenDb.DeletePerson(p);
            }

            //Ausgabe eines Toasts
            ToastController.ShowToastMessage($"{p.Vorname} {p.Nachname} wurde gelöscht.", ToastDuration.Long);

            //Aktualisieren der GUI
            RefreshPage();

        }

        //Methode zum Aktualisieren der GUI
        private void RefreshPage()
        {
            //Setzen der veränderten Property auf null
            LstV_Liste.ItemsSource = null;
            //Neuzuweisung der veränderten Property
            LstV_Liste.ItemsSource = StaticObjects.PersonenListe;
        }

        //EventHandler zum Speichern der Liste (mittels Json)
        private void ToolbarItem_Save(object sender, EventArgs e)
        {
            //Aufruf der Save-Methode des JsonControllers
            JsonController.Save(StaticObjects.PersonenListe);
            //Ausgabe eines Toasts
            ToastController.ShowToastMessage($"Liste gespeichert", ToastDuration.Long);
        }

        //EventHandler zum Laden der Liste (mittels Json)
        private void ToolbarItem_Load(object sender, EventArgs e)
        {
            //Neuzuweisung der lokalen Liste mit durch JsonController geladenen Datei
            StaticObjects.PersonenListe = JsonController.Load<List<Person>>();
            //Ausgabe eines Toasts
            ToastController.ShowToastMessage($"Liste geladen", ToastDuration.Long);
            //Aktualisierung der GUI
            RefreshPage();
        }
    }
}