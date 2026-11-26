using UnityEngine;

public class EtatStable : EtatPlateforme
{
    public override EtatPlateforme OnExecuter(PlateformePiege plateforme)
    {
        if (plateforme.JoueurDessus)
        {
            return new EtatTremble();
        }
        return this;
    }
}
