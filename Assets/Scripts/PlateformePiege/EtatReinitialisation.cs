using UnityEngine;

public class EtatReinitialisation : EtatPlateforme
{
    public override void OnEntrer(PlateformePiege plateforme)
    {
        plateforme.Reinitialiser();
    }

    public override EtatPlateforme OnExecuter(PlateformePiege plateforme)
    {
        return new EtatStable();
    }
}
