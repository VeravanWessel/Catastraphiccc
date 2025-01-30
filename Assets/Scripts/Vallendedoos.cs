using UnityEngine;
using System.Collections;

public class Vallendedoos : MonoBehaviour
{
    [SerializeField] private Animator objectAnimator; // Sleep hier de Animator van het object in
    [SerializeField] private string playerTag = "Player"; // De tag van de speler (zorg dat je speler deze tag heeft)
    [SerializeField] private GameObject prefabToInstantiate; // De prefab die je wilt instantiëren
    [SerializeField] private Transform targetLocation; // De locatie van het object waar de prefab moet komen

    private Vector3 originalScale;
    private bool isBoxSpawned = false; // Houd bij of er al een doos is gespawned

    private void Start()
    {
        originalScale = transform.localScale; // Bewaar de originele schaal van dit object
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag)) // Controleer of de speler de knop aanraakt
        {
            // Zet de animatie bool op true (als dat gewenst is)
            if (objectAnimator != null)
            {
                objectAnimator.SetBool("Pressed", true);
            }

            // Verander de schaal van de knop
            transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.5f, originalScale.z);

            // Spawnt de prefab als er nog geen doos is gespawned
            if (!isBoxSpawned)
            {
                StartCoroutine(SpawnBoxWithDelay());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag)) // Controleert of de speler de knop verlaat
        {
            // Zet de animatie bool op false (als dat gewenst is)
            if (objectAnimator != null)
            {
                objectAnimator.SetBool("Pressed", false);
            }

            // Zet de y-scale terug naar normaal
            transform.localScale = originalScale;
        }
    }

    private IEnumerator SpawnBoxWithDelay()
    {
        isBoxSpawned = true; // Markeer dat er een doos is gespawned

        // Instantieer de prefab meteen op de juiste locatie
        Instantiate(prefabToInstantiate, targetLocation.position, Quaternion.identity);

        // Wacht 3 seconden voordat je de mogelijkheid hebt om een nieuwe doos te spawnen
        yield return new WaitForSeconds(3f);

        // Na de wachttijd, zet isBoxSpawned terug naar false zodat een nieuwe doos kan worden gespawned
        isBoxSpawned = false;
    }
}
