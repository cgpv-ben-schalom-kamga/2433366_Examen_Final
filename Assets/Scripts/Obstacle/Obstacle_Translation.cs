using UnityEngine;

public class Obstacle_Translation : MonoBehaviour
{

    [SerializeField]
    DonneesObstacles donnees;

    [SerializeField]
    Vector3 axe = Vector3.up;

    Rigidbody rb;
    Vector3 positionInitiale;

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        positionInitiale = transform.position;
    }

    /// <summary>
    /// 
    /// </summary>
    void FixedUpdate()
    {
        float decalage = Mathf.Sin(Time.time * donnees.Vitesse) * donnees.Amplitude;
        rb.MovePosition(positionInitiale + axe * decalage);
    }
}
