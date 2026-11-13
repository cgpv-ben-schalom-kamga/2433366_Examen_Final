using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Gerer le deplacement physique du joueur
/// </summary>
public class DeplacementJoueur : MonoBehaviour
{
    [SerializeField]
    private PlayerInput gestionnaireDeControle;
    [SerializeField]
    private Transform camera;
    [SerializeField]
    private float vitesseMarche= 4f;
    [SerializeField]
    private float vitesseSprint = 7f;
    [SerializeField]
    private float acceleration = 10f;
    [SerializeField]
    private float forceSaut = 5f;
    private Rigidbody rigidbody;
    private Vector2 deplacement;
    private bool sprintActif;
    private bool sautDemande;

    
    /// <summary>
    /// Recuperer les composants du GameObject.
    /// </summary>
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
}
