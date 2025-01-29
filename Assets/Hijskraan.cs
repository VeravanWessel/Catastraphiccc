using UnityEngine;

public class Hijskraan : MonoBehaviour
{
    [SerializeField] private Animator objectAnimator; // Sleep hier de Animator van het object in
    [SerializeField] private string playerTag = "Player"; // De tag van de speler (zorg dat je speler deze tag heeft)
    private Vector3 originalScale;


    private void Start()
    {
        originalScale = transform.localScale; // Bewaar de originele schaal van dit object
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag)) // Controleer of de speler de knop aanraakt
        {
            objectAnimator.SetBool("Lower", true); // Zet de animatie bool op true
            transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.5f, originalScale.z);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag)) // Controleert of de speler de knop verlaat
        {
            

            transform.localScale = originalScale; // Zet de y-scale terug naar normaal
           
        }
    }
}
