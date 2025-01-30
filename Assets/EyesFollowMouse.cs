using UnityEngine;

public class EyesFollowMouse : MonoBehaviour
{
    public Transform leftEye;  // Sleep het linkeroog object hier in
    public Transform rightEye; // Sleep het rechteroog object hier in

    private void Update()
    {
        // Verkrijg de muispositie in wereldcoördinaten
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;  // Zorg ervoor dat de Z-as niet wordt beïnvloed (voor 2D)

        // Draai de ogen naar de muispositie
        Vector3 directionToMouse = (mousePosition - leftEye.position).normalized;
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        leftEye.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


       // Vector3 directionToMouse = (mousePosition - leftEye.position).normalized;
      //  float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        rightEye.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


    }
}
