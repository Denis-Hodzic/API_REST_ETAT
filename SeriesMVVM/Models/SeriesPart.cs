using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesMVVM.Models.EntityFramework;

public partial class Serie
{
    public Serie()
    {
    }

    public override bool Equals(object? obj)
    {
        return obj is Serie serie &&
               Serieid == serie.Serieid &&
               Titre == serie.Titre &&
               Resume == serie.Resume &&
               Nbsaisons == serie.Nbsaisons &&
               Nbepisodes == serie.Nbepisodes &&
               Anneecreation == serie.Anneecreation &&
               Network == serie.Network;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Serieid, Titre, Resume, Nbsaisons, Nbepisodes, Anneecreation, Network);
    }
}
