using UnityEngine;

public class Porte : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Joueur"))
        {
            if (GestionParcours.Instance.PossedeCle)
            {
                animator.SetTrigger("Ouvrir");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Joueur"))
        {
            animator.SetTrigger("Fermer");   
        }
    }
}
