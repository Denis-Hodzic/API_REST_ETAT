using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeriesMVVM.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesMVVM.ViewModels
{
    public class SeriePageMVVM:ObservableObject
    {
        public event EventHandler<string>? MessageRequested;
        public IRelayCommand BtnSetAjout { get; }

        public SeriePageMVVM()
        {
            BtnSetAjout = new RelayCommand(ActionSetAjout);
            GetDataOnloadAsync();
        }

        public void ActionSetAjout()
        {
            //if (SerieSelected != null)
            //{
            //    Euro = Montant / SerieSelected.Taux;
            //}
            //else
            //{
            //    MessageRequested?.Invoke(this, "Veuillez sélectionner une Serie");
            //}
        }



        private string? titre;
        public string? Titre
        {
            get => titre;
            set
            {
                titre = value;
                OnPropertyChanged();
            }
        }

        private string? resume;
        public string? Resume
        {
            get => resume;
            set
            {
                resume = value;
                OnPropertyChanged();
            }
        }

        private int nbsaisons;

        public int Nbsaisons
        {
            get { return nbsaisons; }
            set { nbsaisons = value; OnPropertyChanged(); }
        }

        private int nbepisodes;

        public int Nbepisodes
        {
            get { return nbepisodes; }
            set { nbepisodes = value; OnPropertyChanged(); }
        }

        private int anneecreation;

        public int Anneecreation
        {
            get { return anneecreation; }
            set { anneecreation = value; OnPropertyChanged(); }
        }

        private string? network;

        public string? Network
        {
            get { return network; }
            set { network = value; OnPropertyChanged(); }
        }



        public async void GetDataOnloadAsync()
        {
            WSService ws = new WSService("https://localhost:7073/api/");
            List<Serie>? result = await ws.GetSerieAsync("Series");

            //if (result == null)
            //    MessageRequested?.Invoke(this, "Erreur de connexion au service Web");
            //else
            //    Series = new ObservableCollection<Serie>(result);
        }
    }
}
