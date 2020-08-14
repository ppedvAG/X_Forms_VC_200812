using System;
using System.Collections.Generic;
using System.Text;
using X_Forms.PersonenDb.Model;
using X_Forms.PersonenDb.Service;

namespace X_Forms.PersonenDb
{
    //Statische Klasse mit globalen Objekten (kann auch Service- und Controllerobjekte beinhalten)
    public static class StaticObjects
    {
        private static List<Person> personenListe;
        public static List<Person> PersonenListe
        {
            get
            {
                if (personenListe == null)
                {
                    personenListe = new List<Person>()
                    {
                        new Model.Person() { Vorname = "Rainer", Nachname = "Zufall" }
                    };
                }
                return personenListe;
            }
            set { personenListe = value; }
        }

        public static PersonenDbController PersonenDb { get; set; } = new PersonenDbController();
    }
}
