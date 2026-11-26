using UnityEngine;

public class Obstacle_Rotation : MonoBehaviour
{
    [SerializeField]
    DonneesObstacles donnees;

    [SerializeField]
    Vector3 axe = Vector3.forward;

    Rigidbody rb;
    Quaternion rotationInitiale;

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rotationInitiale = transform.rotation;
    }

    /// <summary>
    /// 
    /// </summary>
    void FixedUpdate()
    {
        float angle = Mathf.Sin(Time.time * donnees.vitesse) * donnees.amplitude;
        rb.MoveRotation(rotationInitiale * Quaternion.Euler(axe * angle));
    }
}
