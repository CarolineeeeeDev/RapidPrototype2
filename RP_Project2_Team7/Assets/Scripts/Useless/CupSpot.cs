using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CupSpot : MonoBehaviour
{
    [SerializeField] private GameObject maincamera;
    [SerializeField] private GameObject cupSpot;
    [SerializeField] private GameObject initialSpot;

    void Update()
    {
        if (maincamera.GetComponent<CameraSpot>().isCupSpot)
        {
            maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, cupSpot.transform.position, 0.02f);
            maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, cupSpot.transform.rotation, 0.02f);
        }
        else if (!maincamera.GetComponent<CameraSpot>().isPhoneSpot)
        {
            maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, initialSpot.transform.position, 0.02f);
            maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, initialSpot.transform.rotation, 0.02f);
        }
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            maincamera.GetComponent<CameraSpot>().isCupSpot = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            maincamera.GetComponent<CameraSpot>().isCupSpot = false;
        }
    }


}
