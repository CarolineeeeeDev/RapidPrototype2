using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSpot : MonoBehaviour
{
    [SerializeField] private GameObject maincamera;
    [SerializeField] private GameObject phoneSpot;
    [SerializeField] private GameObject initialSpot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (maincamera.GetComponent<CameraSpot>().isPhoneSpot)
        {
            maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, phoneSpot.transform.position, 0.02f);
            //maincamera.transform.position=Vector3.MoveTowards(maincamera.transform.position, phoneSpot.transform.position, 0.05f);
            maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, phoneSpot.transform.rotation, 0.01f);
        }
        else if (!maincamera.GetComponent<CameraSpot>().isCupSpot)
        {
            //maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, initialSpot.transform.position, 0.02f);
            maincamera.transform.position = Vector3.MoveTowards(maincamera.transform.position, initialSpot.transform.position, 0.02f);
            maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, initialSpot.transform.rotation, 0.02f);
        }

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            maincamera.GetComponent<CameraSpot>().isPhoneSpot = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            maincamera.GetComponent<CameraSpot>().isPhoneSpot = false;
        }
    }
}
