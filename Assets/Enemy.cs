using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    [SerializeField] private float moveSpeed = 3f; // Snelheid van de vijand
    [SerializeField] private float moveDistance = 5f; // Hoe ver de vijand beweegt voordat hij omkeert
    private Vector3 startPosition;
    private int direction = 1; // 1 = rechts, -1 = links
    private bool doodgaan = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (!doodgaan) // Alleen bewegen als doodgaan niet geactiveerd is
        {
            transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

            // Keer om als de vijand de maximale afstand bereikt
            if (Mathf.Abs(transform.position.x - startPosition.x) >= moveDistance)
            {
                direction *= -1;
                Flip();
            }
        }
    }

    private void OnCollisionEnter2D(Collider2D Collision2D)
    {
        if (Collision2D.CompareTag("Box")) // Controleert of de vijand een object met de tag "Box" raakt
        {
            doodgaan = true;
            Debug.Log("Enemy geraakt door Box! Doodgaan is nu: " + doodgaan);
        }
    }

    private void Flip()
    {
        // Draai het object horizontaal om
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
