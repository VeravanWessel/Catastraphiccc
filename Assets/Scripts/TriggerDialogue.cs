using UnityEngine;
using UnityEngine.Events;

public class TriggerDialogue : MonoBehaviour
{
    // Events die worden geactiveerd wanneer de speler het triggergebied binnenkomt of verlaat
    public UnityEvent onTriggerEnter = new UnityEvent();
    public UnityEvent onTriggerExit = new UnityEvent();

    // Wanneer de speler het triggergebied binnenkomt
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTriggerEnter.Invoke();  // Activeer het event bij binnenkomst
            Debug.Log("Enter");
        }
    }

    // Wanneer de speler het triggergebied verlaat
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTriggerExit.Invoke();  // Activeer het event bij verlaten
            Debug.Log("Exit");
        }
    }
}
