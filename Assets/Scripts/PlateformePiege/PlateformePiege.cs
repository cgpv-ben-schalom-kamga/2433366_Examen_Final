using UnityEngine;

public class PlateformePiege : MonoBehaviour
{
    private EtatPlateforme etatActuel;
    private EtatPlateforme prochainEtat;

    [SerializeField]
    private float dureeTremblement = 1f;
    [SerializeField]
    private float dureeChute = 2f;

    private Rigidbody rb;
    private Vector3 positionInitiale;

    public bool JoueurDessus { get; private set; }
    public float DureeTremblement => dureeTremblement;
    public float DureeChute => dureeChute;
    public Rigidbody Rb => rb;
    public Vector3 PositionInitiale => positionInitiale;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        positionInitiale = transform.position;
        prochainEtat = new EtatStable();
        etatActuel = null;
    }

    private void Update()
    {
        if (prochainEtat != etatActuel)
            prochainEtat.OnEntrer(this);

        etatActuel = prochainEtat;
        prochainEtat = etatActuel.OnExecuter(this);

        if (etatActuel != prochainEtat)
            etatActuel.OnSortir(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Joueur"))
            JoueurDessus = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Joueur"))
            JoueurDessus = false;
    }

    public void Trembler()
    {
        float decalage = Mathf.Sin(Time.time * 50f) * 0.05f;
        rb.MovePosition(positionInitiale + Vector3.up * decalage);
    }

    public void Chuter()
    {
        rb.MovePosition(rb.position + Vector3.down * 3f * Time.deltaTime);
    }

    public void Reinitialiser()
    {
        rb.MovePosition(positionInitiale);
    }
}
