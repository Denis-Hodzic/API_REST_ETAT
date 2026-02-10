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
    public partial class SeriePageMVVM:ObservableObject
    {
        public event EventHandler<string>? MessageRequested;

        private readonly IService service;

        [ObservableProperty]
        private Serie serieToAdd;

        public IRelayCommand BtnSetAjout { get; }

        public SeriePageMVVM()
        {
            this.service = new WSService("https://apiseriesv10-d6hndsd5fnc6drgt.switzerlandnorth-01.azurewebsites.net/api/");

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


        public async Task GetDataOnloadAsync()
        {
            List<Serie>? result = await service.GetAllSeriesAsync("series");

            //if (result == null)
            //    MessageRequested?.Invoke(this, "Erreur de connexion au service Web");
            //else
            //    Series = new ObservableCollection<Serie>(result);
        }
    }
}
