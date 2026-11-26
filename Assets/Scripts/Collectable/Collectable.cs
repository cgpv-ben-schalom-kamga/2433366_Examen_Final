using UnityEngine;


public abstract class Collectable : MonoBehaviour
{
    /// <summary>
    /// Collecter le collectable 
    /// lors d'une collision entre le joueur et le collectable
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Joueur"))
        {
            Collecter();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Chque type de collectable definira son comportement relatif
    /// </summary>
    public abstract void Collecter();
}
