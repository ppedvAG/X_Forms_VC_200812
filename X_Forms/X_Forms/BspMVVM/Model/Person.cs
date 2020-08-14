using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace X_Forms.BspMVVM.Model
{
    //Die Model-Klassen defnieren die Business-Objekte der App
    //In MVVM beinhalten die Model-Klassen keine Referenzen außerhalb anderer Modelklassen.
    public class Person
    {
        //SQLlite-Property-Attribute(vgl. PersonenDb/Model)
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int Alter { get; set; }

        [Ignore]
        public static ObservableCollection<Person> PersonenListe { get; set; } = new ObservableCollection<Person>();
    }
}
