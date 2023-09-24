using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float deviation = 1e-4f;
    [SerializeField] private Transform initialPostion;
    [SerializeField] private Transform coffeeMakingPosition;
    [SerializeField] private GameObject maincamera;
    [SerializeField] private Button toInitialSpotButton;
    [SerializeField] private Button toCoffeeSpotButton;
    [SerializeField] private GameObject orderManager;
    [SerializeField] private GameObject pillButton;
    private GameObject orderManagerInGame;

    private int positionIndex;
    private bool isInPosition;

    //[SerializeField] private GameObject CoffeeCanvas;
    private void Start()
    {
        positionIndex = 0;
        isInPosition = true;
        pillButton.SetActive(false);
        maincamera.transform.position = initialPostion.position;
        maincamera.transform.rotation = initialPostion.rotation;
        toInitialSpotButton.gameObject.SetActive(false);
        toCoffeeSpotButton.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (!isInPosition)
        {
            switch (positionIndex)
            {
                case 0://Position 0: Initial position
                    maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, initialPostion.position, 0.02f);
                    maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, initialPostion.rotation, 0.02f);
                    if (Distance(maincamera.transform, initialPostion) < deviation)
                    {
                        toInitialSpotButton.gameObject.SetActive(false);
                        toCoffeeSpotButton.gameObject.SetActive(true);
                        Debug.Log("in initial position");
                        pillButton.SetActive(false);
                        if (orderManagerInGame != null)
                        {
                            Destroy(orderManagerInGame);//delete order manager
                        }
                        isInPosition = true;
                        
                    }
                    
                    break;
                case 1://Position 1: Coffee making position
                    maincamera.transform.position = Vector3.Lerp(maincamera.transform.position, coffeeMakingPosition.position, 0.02f);
                    maincamera.transform.rotation = Quaternion.Slerp(maincamera.transform.rotation, coffeeMakingPosition.rotation, 0.02f);
                    if (Distance(maincamera.transform, coffeeMakingPosition) < deviation)
                    {
                        toInitialSpotButton.gameObject.SetActive(true);
                        toCoffeeSpotButton.gameObject.SetActive(false);
                        Debug.Log("in coffee making position");
                        pillButton.SetActive(true);
                        orderManagerInGame = Instantiate(orderManager);//create order manager
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
