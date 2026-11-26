using UnityEngine;

public abstract class EtatPlateforme
{
    public virtual void OnEntrer(PlateformePiege plateforme) { }

    public abstract EtatPlateforme OnExecuter(PlateformePiege plateforme);

    public virtual void OnSortir(PlateformePiege plateforme) { }
}
