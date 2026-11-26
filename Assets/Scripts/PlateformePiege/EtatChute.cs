using UnityEngine;

public class EtatChute : EtatPlateforme
{
    private float timer = 0f;

    public override EtatPlateforme OnExecuter(PlateformePiege plateforme)
    {
        timer += Time.deltaTime;
        plateforme.Chuter();

        if (timer >= plateforme.DureeChute)
        {
            return new EtatReinitialisation();
        }
        return this;
    }
}
