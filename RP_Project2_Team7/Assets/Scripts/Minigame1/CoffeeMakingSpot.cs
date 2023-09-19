using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMakingSpot : MonoBehaviour
{
    [SerializeField] private GameObject maincamera;
    [SerializeField] private GameObject coffeeMakingSpot;
    [SerializeField] private GameObject initialSpot;
    [SerializeField] private GameObject CoffeeCanvas;

    void Update()
    {
        if (maincamera.GetComponent<CameraMovement>().isCoffeeSpot)
        {
            maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, coffeeMakingSpot.transform.position, 0.02f);
            maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, coffeeMakingSpot.transform.rotation, 0.02f);
            CoffeeCanvas.SetActive(true);

        }
        else if (!maincamera.GetComponent<CameraMovement>().isCoffeeSpot)
        {
            maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, initialSpot.transform.position, 0.02f);
            maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, initialSpot.transform.rotation, 0.02f);
            CoffeeCanvas.SetActive(false);

        }

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            maincamera.GetComponent<CameraMovement>().isCoffeeSpot = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            maincamera.GetComponent<CameraMovement>().isCoffeeSpot = false;
        }
    }
}
