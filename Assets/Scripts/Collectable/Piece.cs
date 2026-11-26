using UnityEngine;

public class Piece : Collectable
{
    /// <summary>
    /// Implementation de la methode collecter
    /// des objets collectable
    /// </summary>
    public override void Collecter()
    {
        GestionParcours.Instance.PieceRamassee();
    }

}
