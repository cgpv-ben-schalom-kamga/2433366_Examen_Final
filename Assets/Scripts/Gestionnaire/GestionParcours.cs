using UnityEngine;
using UnityEngine.Events;

public class GestionParcours : MonoBehaviour
{
    [SerializeField, Tooltip("Nombre de pieces à ramasser avant de faire apparaitre la clé dans la scène")]
    int NbrePiecesPourAfficherLaCle;
    [SerializeField, Tooltip("Référence vers le gameobject clé")]
    GameObject cle;

    /// <summary>
    /// Evenement qui sera lancer lorsque on aurra
    /// collecter le nombre de pièce necessaire pour
    /// faire apparaitre la clé
    /// </summary>
    [SerializeField]
    UnityEvent fragmentRamasse;

    /// <summary>
    /// Compteur de piece collecter 
    /// </summary>
    private int compteur = 0;

    private void Awake()
    {
        Instance = this;
        cle.SetActive(false);
    }

    /// <summary>
    /// Marque une pièce comme ramassée.
    /// </summary>
    public void PieceRamassee()
    {
        compteur++;
        if (compteur >= NbrePiecesPourAfficherLaCle) { 
            fragmentRamasse.Invoke();
            cle.SetActive(true);
        }
    }

    /// <summary>
    /// Donne la clé au joueur
    /// </summary>
    public void CleRamassee()
    {
        PossedeCle = true;
    }


    /// <summary>
    /// Singleton de controle d'instance dans le programme
    /// </summary>
    public static GestionParcours Instance { get; private set; }

    /// <summary>
    /// Accesseur sur l'attribut possedeCle
    /// </summary>
    public bool PossedeCle { get; private set; } = false;
}
