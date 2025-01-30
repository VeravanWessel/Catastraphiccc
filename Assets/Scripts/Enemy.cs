using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float moveDistance = 5f;
    private Vector3 startPosition;
    private int direction = 1;
    private bool doodgaan = false;
    public GameObject ratdood;
   private BoxCollider2D boxCollider;

    public List<GameObject> objectenOmTeDeactiveren; // Lijst met objecten om te deactiveren

    private void Start()
    {
        startPosition = transform.position;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!doodgaan)
        {
            transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

            if (Mathf.Abs(transform.position.x - startPosition.x) >= moveDistance)
            {
                direction *= -1;
                Flip();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box")) // Controleert of het object een "Box" is
        {
            float boxY = collision.transform.position.y;
            float enemyY = transform.position.y;

            if (boxY > enemyY) // Alleen doden als de doos van boven komt
            {
                doodgaan = true;
                boxCollider.enabled = false;
                ratdood.SetActive(true);
               
                DeactiveerObjecten(); // Roep de functie aan om de lijst te deactiveren
                Debug.Log("Enemy is geraakt van boven en is nu dood.");
            }
        }
    }

    private void DeactiveerObjecten()
    {
        foreach (GameObject obj in objectenOmTeDeactiveren)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    private void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
