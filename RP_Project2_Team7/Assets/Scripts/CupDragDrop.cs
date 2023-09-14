using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CupDragDrop : MonoBehaviour
{ 
    public GameObject quest1;
    public List<GameObject> listTargets = new List<GameObject>();

    Vector3 starPos;
    private void Start()
    {
        starPos = transform.localPosition;
    }

    public void OnMouseDrag()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);
        transform.position = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        //Debug.Log("OnMouseDrag");
    }

    public void OnMouseUp()
    {

            bool isTarget = false;
            foreach (GameObject item in listTargets)
            {
                if (GetOverGameObject(Camera.main.gameObject).Contains(item))
                {
                    isTarget = true;
                    transform.position = item.transform.position;
                    quest1.GetComponent<Quest1>().organizedCup += 1;
                    break;
                }
            }
            if (isTarget == false)
            {
                transform.position = starPos;
            }

        
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    public List<GameObject> GetOverGameObject(GameObject raycaster)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        PhysicsRaycaster pr = raycaster.GetComponent<PhysicsRaycaster>();
        List<RaycastResult> results = new List<RaycastResult>();
        pr.Raycast(pointerEventData, results);
        List<GameObject> listObjs = new List<GameObject>();
        if (results.Count != 0)
        {
            foreach (RaycastResult item in results)
            {

                listObjs.Add(item.gameObject);
            }
            //return listObjs;
        }
        return listObjs;
    }

}

