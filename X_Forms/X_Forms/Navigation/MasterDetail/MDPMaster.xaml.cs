using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.Navigation.MasterDetail
{
    //Dieser CodeBehind wird automatisch durch das MasterDetailPage-Template generiert
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPMaster : ContentPage
    {
        public ListView ListView;

        public MDPMaster()
        {
            InitializeComponent();

            BindingContext = new MDPMasterViewModel();
            ListView = MenuItemsListView;
        }

        //Im ViewModel der MasterPage werden die Menüitems defefiniert
        class MDPMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MDPMasterMenuItem> MenuItems { get; set; }

            public MDPMasterViewModel()
            {
                MenuItems = new ObservableCollection<MDPMasterMenuItem>(new[]
                {
                    //Die Elemente vom Typ MasterMenuItem repräsentieren die einzelnen Menüeinträge. Der TargetType definiert die
                    //Page-Klasse.
                    new MDPMasterMenuItem(){Id=0, Title="Startseite", TargetType=typeof(MainPage)},
                    new MDPMasterMenuItem(){Id=1, Title="AbsoluteLayout", TargetType=typeof(Layouts.AbsoluteLay)},
                    new MDPMasterMenuItem(){Id=2, Title="RelativeLayout", TargetType=typeof(Layouts.RelativeLay)},
                    new MDPMasterMenuItem(){Id=3, Title="PersonenDb", TargetType=typeof(PersonenDb.Navigation.MDP)},
                    new MDPMasterMenuItem(){Id=4, Title="MVVM_Bsp", TargetType=typeof(BspMVVM.View.MainView)},
                    new MDPMasterMenuItem(){Id=5, Title="GoogleBooks", TargetType=typeof(Uebungen.GoogleBooks.View.MainView)}
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}