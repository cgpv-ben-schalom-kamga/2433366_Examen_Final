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
    private float forceSaut = 5f;
    private Rigidbody rigidbody;
    private Vector2 deplacement;
    private bool sprintActif;
    private bool sautDemande;
    private bool enCoursDeSaut;


    /// <summary>
    /// Recuperer les composants du GameObject.
    /// </summary>
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Abonne aux controles du joueur
    /// </summary>
    private void Start()
    {
        InputAction actionDeplacement = gestionnaireDeControle.actions.FindAction("Player/Move");
        actionDeplacement.performed += CommencerDeplacement;
        actionDeplacement.canceled += TerminerDeplacement;

        InputAction actionSaut = gestionnaireDeControle.actions.FindAction("Player/Jump");
        actionSaut.performed += DemanderSaut;

        InputAction actionSprint = gestionnaireDeControle.actions.FindAction("Player/Sprint");
        actionSprint.performed += CommencerSprint;
        actionSprint.canceled += TerminerSprint;
    }

    
    /// <summary>
    /// Desabonne au controle du joueur
    /// lors de la destruction du gameobject
    /// </summary>
    private void OnDestroy()
    {
        if (gestionnaireDeControle == null || gestionnaireDeControle.actions == null) { return; }

        InputAction actionDeplacement = gestionnaireDeControle.actions.FindAction("Player/Move");
        actionDeplacement.performed -= CommencerDeplacement;
        actionDeplacement.canceled -= TerminerDeplacement;

        InputAction actionSaut = gestionnaireDeControle.actions.FindAction("Player/Jump");
        actionSaut.performed -= DemanderSaut;

        InputAction actionSprint = gestionnaireDeControle.actions.FindAction("Player/Sprint");
        actionSprint.performed -= CommencerSprint;
        actionSprint.canceled -= TerminerSprint;
    }

    /// <summary>
    /// Applique les forces physiques.
    /// </summary>
    private void FixedUpdate()
    {
        Deplacer();
        Sauter();
    }

    /// <summary>
    /// Commencer le deplacement du joueur
    /// </summary>
    /// <param name="context">Information du callback de l'action</param>
    private void CommencerDeplacement(InputAction.CallbackContext context)
    {
        deplacement = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Terminer le deplacement du joueur
    /// </summary>
    /// <param name="context">Information du callback de l'action</param>
    private void TerminerDeplacement(InputAction.CallbackContext context)
    {
        deplacement = Vector2.zero;
    }

    /// <summary>
    /// Gerer le deplacement du joueur en fonction de l'input du joueur
    /// </summary>
    private void Deplacer()
    {
        Vector3 devantCamera = camera.forward;
        devantCamera.y = 0;
        devantCamera = devantCamera.normalized;
        Vector3 droiteCamera = camera.right;
        droiteCamera.y = 0;
        droiteCamera = droiteCamera.normalized;

       Vector3 direction = ((devantCamera * deplacement.y) + (droiteCamera * deplacement.x)).normalized;

        if (sprintActif)
        {
            rigidbody.AddForce(direction * vitesseSprint, ForceMode.Acceleration);
        }
        else
        {
            // Marche : vitesse constante, conserve la velocite verticale (saut/gravite)
            // Source Claude IA : utilisation de linearVelocity pour un deplacement constant
            Vector3 velociteActuelle = rigidbody.linearVelocity;
            rigidbody.linearVelocity = new Vector3(direction.x * vitesseMarche, velociteActuelle.y, direction.z * vitesseMarche);
        }

        if (direction != Vector3.zero)
        {
            // Orienter le joueur vers la direction de deplacement
            //https://learn.unity.com/course/intermediate-gameplay-scripting/tutorial/quaternions
            Quaternion rotationCible = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationCible, 10f * Time.fixedDeltaTime);
        }


    }

    /// <summary>
    /// Memorise la demande de saut du joueur
    /// </summary>
    /// <param name="context"></param>
    private void DemanderSaut(InputAction.CallbackContext context)
    {
        sautDemande = true;
    }

    /// <summary>
    /// Applique  un changement de velocite vertical au joueur 
    /// afin de le faire sauter
    /// </summary>
    private void Sauter()
    {
        if (sautDemande && !enCoursDeSaut)
        {
            rigidbody.AddForce(Vector3.up * forceSaut, ForceMode.VelocityChange);
            enCoursDeSaut = true;
        }
        sautDemande = false;
    }

    /// <summary>
    /// Detecte une collision entre le sol et le joueur
    /// afin de mettre a jour la valeur de l'etat
    /// enCoursDeSaut
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Sol"))
        {
            enCoursDeSaut = false;
        }
    }

    /// <summary>
    /// Terminer le sprint du joueur
    /// </summary>
    /// <param name="context"></param>
    private void TerminerSprint(InputAction.CallbackContext context)
    {
        sprintActif = false;
    }

    /// <summary>
    /// Commencer le sprint du joueur
    /// </summary>
    /// <param name="context"></param>
    private void CommencerSprint(InputAction.CallbackContext context)
    {
        sprintActif = true;
    }

}
