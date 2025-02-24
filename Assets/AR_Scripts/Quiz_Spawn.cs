using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class Quiz_Spawn : MonoBehaviour
{
    private bool isClick = false;
    private GameObject questionObject; // ��J�]�t�D�ػP�ﶵ������
    private ARRaycastManager raycastManager; // AR�����˴�
    [SerializeField]
    private GameObject placablePrefab;
    private static List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (!tryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (raycastManager.Raycast(touchPosition, raycastHits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = raycastHits[0].pose;
            if (questionObject == null)
            {

            }
            else
            {
                questionObject.transform.position = hitPose.position;
                questionObject.transform.rotation = hitPose.rotation;


            }
        }
    }
    bool tryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("Input.touchCount :" + Input.touchCount.ToString());
            touchPosition = Input.GetTouch(0).position;
            return true;



        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                isClick = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isClick = false;

            }
        }
        if (isClick)
        {
            touchPosition = Input.mousePosition;
            return true;
        }
        touchPosition = default;
        return false;
    }
}
