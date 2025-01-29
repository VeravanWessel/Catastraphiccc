using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knopwordtingedrukt : MonoBehaviour
{
    [SerializeField] private Transform objectToMove; // Het object dat omhoog moet gaan
    [SerializeField] private float moveSpeed = 2f; // Hoe snel het object omhoog beweegt
    [SerializeField] private float maxHeight = 5f; // Maximale hoogte vanaf de startpositie

    private bool shouldMove = false;
    private float startY;

    private void Start()
    {
        if (objectToMove != null)
        {
            startY = objectToMove.position.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (objectToMove != null && other.CompareTag("Player")) // Vervang "Player" met je eigen tag
        {
            shouldMove = true;
            
        }
    }

    private void Update()
    {
        if (shouldMove && objectToMove.position.y < startY + maxHeight)
        {
            objectToMove.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }
}
