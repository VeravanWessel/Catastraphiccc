using UnityEngine;

public class Hijskraan : MonoBehaviour
{
    [SerializeField] private Animator objectAnimator; // Sleep hier de Animator van het object in
    [SerializeField] private string playerTag = "Player"; // De tag van de speler (zorg dat je speler deze tag heeft)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag)) // Controleer of de speler de knop aanraakt
        {
            objectAnimator.SetBool("Lower", true); // Zet de animatie bool op true
           
        }
    }
}
