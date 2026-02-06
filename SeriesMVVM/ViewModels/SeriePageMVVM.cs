using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeriesMVVM.Models.EntityFramework;
using SeriesMVVM.Services;
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

        private readonly IService service;

        [ObservableProperty]
        private Serie serieToAdd;

        public IRelayCommand BtnSetAjout { get; }

        public SeriePageMVVM()
        {
            this.service = service;
            BtnSetAjout = new AsyncRelayCommand(ActionSetAjout);

            serieToAdd = new Serie
            {
                Titre = "",
                Resume = "",
                Nbsaisons = 0,
                Nbepisodes = 0,
                Anneecreation = 0,
                Network = ""
            };
        }

        public async Task ActionSetAjout()
        {
            if (string.IsNullOrWhiteSpace(SerieToAdd.Titre))
            {
                MessageRequested?.Invoke(this, "Titre obligatoire.");
                return;
            }

            bool ok = await service.PostSerieAsync("series", SerieToAdd);

            if (ok)
            {
                MessageRequested?.Invoke(this, "Série ajoutée");
                // reset
                SerieToAdd = new Serie
                {
                    Titre = "",
                    Resume = "",
                    Nbsaisons = 0,
                    Nbepisodes = 0,
                    Anneecreation = 0,
                    Network = ""
                };
            }
            else
            {
                MessageRequested?.Invoke(this, "Erreur lors de l'ajout .");
            }

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
