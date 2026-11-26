using UnityEngine;

public class Cle : Collectable
{
    /// <summary>
    /// Implementation de la methode collecter
    /// des objets collectable
    /// </summary>
    public override void Collecter()
    {
        GestionParcours.Instance.CleRamassee();
    }
}

