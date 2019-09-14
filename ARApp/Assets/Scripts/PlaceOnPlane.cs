using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
 
public class PlaceOnPlane : MonoBehaviour
{
    public GameObject prefabToPlace;
    public ARSessionOrigin aRSessionOrigin;
    public List<ARRaycastHit> hits;
 
    void Start()
    {
        hits = new List<ARRaycastHit>();
        aRSessionOrigin = GetComponent<ARSessionOrigin>();
    }
 
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i=0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {

                    if (aRSessionOrigin.GetComponent<ARRaycastManager>().Raycast(touch.position, hits))
                    {
                        Pose hitPose = hits[0].pose;
                        Instantiate(prefabToPlace, 
                               hitPose.position, hitPose.rotation);
                    }
                }
            }
        }
    }
}