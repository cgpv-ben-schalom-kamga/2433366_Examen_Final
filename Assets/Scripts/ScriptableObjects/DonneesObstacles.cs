using UnityEngine;

[CreateAssetMenu(fileName = "DonneesObstacles", menuName = "Scriptable Objects/DonneesObstacles")]
public class DonneesObstacles : ScriptableObject
{
    [SerializeField]
    private float vitesse;
    public float Vitesse => vitesse;
    [SerializeField]
    private float amplitude;
    public float Amplitude => amplitude;
}
