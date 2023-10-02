using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float deviation = 1e-4f;
    [SerializeField]
    private float speed = 0.4f;
    [SerializeField] private Transform initialPostion;
    [SerializeField] private Transform coffeeMakingPosition;
    [SerializeField] private GameObject maincamera;
    [SerializeField] private GameObject followCamera;
    [SerializeField] private GameObject toInitialSpotButton;
    [SerializeField] private GameObject toCoffeeSpotButton;
    [SerializeField] private GameObject orderManager;
    [SerializeField] private GameObject MakeCoffeeUI;
    [SerializeField] private GameObject CoffeeStrengthUI;
    //MakeCoffeeUI
    [SerializeField] private GameObject Button1;
    [SerializeField] private GameObject Button2;
    [SerializeField] private GameObject Button3;
    [SerializeField] private GameObject Button4;
    [SerializeField] private GameObject Button5;
    [SerializeField] private GameObject Button6;

    private int positionIndex;
    private bool isInPosition;

    private void Start()
    {
        positionIndex = 0;
        isInPosition = true;
        maincamera.transform.position = initialPostion.position;
        maincamera.transform.rotation = initialPostion.rotation;
        followCamera.transform.position = maincamera.transform.position;
        followCamera.transform.rotation = maincamera.transform.rotation;
        toInitialSpotButton.SetActive(false);
        toCoffeeSpotButton.SetActive(false);
        MakeCoffeeUI.SetActive(false);
    }
    private void Update()
    {
        if (!isInPosition)
        {
            switch (positionIndex)
            {
                case 0://Position 0: Initial position
                    maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, initialPostion.position, speed * Time.deltaTime); ;
                    maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, initialPostion.rotation, speed * Time.deltaTime);
                    followCamera.transform.position = maincamera.transform.position;
                    followCamera.transform.rotation = maincamera.transform.rotation;
                    if (Distance(maincamera.transform, initialPostion) < deviation)
                    {
                        ResetMakeCoffeeUI();
                        MakeCoffeeUI.SetActive(false);
                        //Debug.Log("in initial position");
                        isInPosition = true;
                        
                    }
                    break;

                case 1://Position 1: Coffee making position
                    maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, coffeeMakingPosition.position, speed * Time.deltaTime);
                    maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, coffeeMakingPosition.rotation, speed * Time.deltaTime);
                    followCamera.transform.position = maincamera.transform.position;
                    followCamera.transform.rotation = maincamera.transform.rotation;
                    if (Distance(maincamera.transform, coffeeMakingPosition) < deviation)
                    {
                        ResetMakeCoffeeUI();
                        toCoffeeSpotButton.SetActive(false);
                        MakeCoffeeUI.SetActive(true);
                        CoffeeStrengthUI.SetActive(true);
                        //Debug.Log("in coffee making position");
                        isInPosition = true;
                        
                    }
                    
                    break;

            }
        }
        
    }
    public void SetPosition(int currentPositionIndex)
    {
        isInPosition = false;
        positionIndex =currentPositionIndex;
        
    }
    private void ResetMakeCoffeeUI()
    {
        Button1.GetComponent<ButtonSpriteSwitch>().ResetSprite();
        Button2.GetComponent<ButtonSpriteSwitch>().ResetSprite();
        Button3.GetComponent<ButtonSpriteSwitch>().ResetSprite();
        Button1.SetActive(true);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Button4.SetActive(false);
        Button5.SetActive(false);
        Button6.SetActive(false);
    }
    private float Distance(Transform transform1, Transform transform2)
    {
        Vector3 t=transform1.position - transform2.position;
        float distance = 
            (transform1.rotation.x - transform2.rotation.x)* (transform1.rotation.x - transform2.rotation.x)
            + (transform1.rotation.y - transform2.rotation.y) * (transform1.rotation.y - transform2.rotation.y)
            + (transform1.rotation.z - transform2.rotation.z) * (transform1.rotation.z - transform2.rotation.z)
            +t.x*t.x+t.y*t.y+t.z*t.z;
        return distance;
    }


}
