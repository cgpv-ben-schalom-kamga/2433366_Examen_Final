using UnityEngine;

public class EtatTremble : EtatPlateforme
{
    private float timer = 0f;

    public override EtatPlateforme OnExecuter(PlateformePiege plateforme)
    {
        timer += Time.deltaTime;
        plateforme.Trembler();

        if (timer >= plateforme.DureeTremblement)
        {
            return new EtatChute();
        }
        return this;
    }
}
