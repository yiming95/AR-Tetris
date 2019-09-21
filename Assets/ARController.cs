using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
//using UnityEngine.Rendering.PostProcessing;


public class ARController : MonoBehaviour
{
    [Header("Script Component")]
    public ARSessionOrigin ARSessionOrigin;
    public ARRaycastManager ARRaycastManager;
    public ARPlaneManager ARPlaneManager;
    public ARSession ARSession;
    public GroundDetector GroundDetector;

    [Header("Config")]
    public LayerMask FloorLayer;
    public Text DebugMassage;

    [Header("Objects")]
    public Transform AROrigin;
    public Transform AROriginCamera;
    public Camera ARCamera;
    public GameObject[] ARObjectPrefab;
    public GameObject PlacementIndictor;
    public GameObject ARObject;
    public GameObject ARFloorPlane;
    public GameObject[] ARObjectLayers;

    [Header("Raycasting Objects")]
    public LayerMask DetectionLayer;
    public int DetectionDistance;
    public Transform InitialPosition;
    public Transform DetectedObject;
    public Transform LastDetectedObject;
    public string DetectionTag;

    // Fields
    private Pose placementPose;
    private bool ifPlacementValid = false;
    private bool isFloorValid = false;
    private int TimeLerp;
    private Vector3 screenCenter;
    private int ARObjectIndex = 0;
    private int MarkerIndex = 0;
    private float Distance = 0;

    private Vector3 ARCameraForward;
    private Vector3 ARCameraBearing;
    private Vector3 AROrigainStartPosition;
    private string DebugMessage;

    private ARPlane lowestPlane;
    private float initHeight = 0;    // height between AR camera and lowest ARPlane
    private float baseHeight = 0;    // height of base floor (eg, ground, and belcony)
    private float lowestHeight = 0;
    private float liftHeight = 0;   // height between AROrigin and lowest ARPlane


    private float MovementSpeed = 2f;
    private bool ifVREnabled = false;
    private bool ifSkyWatch = false;
    private bool ifRoadOn = true;
    private bool ifAnchorOn = true;
    private int ARLayerIndex = 0;

    private Ray CameraRay;
    private RaycastHit CameraRayHits;
    private float TransicationTime = 1.5f;
    private float TransicationCounter = 1.5f;
    private Vector3 TransicationTarget;
    private Vector3 LastPosition;

    private string HitName = "";

    void Awake()
    {
        Application.targetFrameRate = 30;
    }


    // Start is called before the first frame update
    void Start()
    {
        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        AROrigainStartPosition = AROrigin.transform.position;
        ARObjectPrefab[0].SetActive(false);


        if (ARCamera == null)
        {
            ARCamera = Camera.main;
        }

        lowestHeight = ARCamera.transform.position.y;
    }



    // Update is called once per frame
    void Update()
    {
        if (ARObject == null)
        {
            UpdatePlacementPose();
        }
        else
        {
            DebugMassage.text = AROrigin.position.ToString() + "| " + ARCamera.transform.position.ToString();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (ARObject == null)
            {

                if (ARObject == null)
                {
                    ARObject = ARObjectPrefab[0];
                    ARObject.SetActive(true);
                    initHeight = AROriginCamera.position.y;
                    AROrigin.position = new Vector3(AROrigin.position.x, initHeight + GroundDetector.GetGroundHeight(), AROrigin.position.z);
                }


            }
            else
            {
                TransicationTarget = LastPosition;
                TransicationCounter = 0;
            }
        }

        if (TransicationCounter < TransicationTime)
        {
            AROrigin.position = Vector3.Lerp(AROrigin.position, TransicationTarget, Time.deltaTime * 7f);
            TransicationCounter = TransicationCounter + Time.deltaTime;
        }
        else
        {
            if (ARObject != null)
            {
                //set Camera ground
                AROrigin.position = new Vector3(AROrigin.position.x, initHeight + GroundDetector.GetGroundHeight(), AROrigin.position.z);
            }
        }
    }


    //=================================================

    private void UpdatePlacementPose()
    {
        // Update the plane detection using pose
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        ARRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinBounds);

        ifPlacementValid = hits.Count > 0;

        if (ifPlacementValid)
        {
            TrackableId id = hits[0].trackableId;
            placementPose = hits[0].pose;


            PlacementIndictor.transform.position = hits[0].pose.position;
            PlacementIndictor.SetActive(true);

            // find the most lowerset plan (assume the floor is alway on the lowerest plan)
            if (placementPose.position.y < lowestHeight)
            {
                ARPlaneManager.trackables.TryGetTrackable(id, out lowestPlane);
                lowestHeight = placementPose.position.y;
            }

            ARCameraForward = ARCamera.transform.forward;
            ARCameraBearing = new Vector3(ARCameraForward.x, 0, ARCameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(ARCameraBearing);
            PlacementIndictor.transform.rotation = placementPose.rotation;


        }
        else
        {
            PlacementIndictor.SetActive(false);
        }


        // Set the height 
        ARFloorPlane.transform.position = new Vector3(AROrigin.position.x, lowestHeight, AROrigin.position.y);
        if (lowestPlane != null)
        {
            initHeight = ARCamera.transform.position.y - lowestPlane.transform.position.y;
            liftHeight = AROrigin.position.y - lowestPlane.transform.position.y;
        }
    }

    /* ============================================================== */
    /* ====================   ON CLICK BUTTON   ===================== */
    /* ============================================================== */

    public void OnClick_PlaceObject()
    {
        if (ARObject == null)
        {
            if (ifPlacementValid)
            {
                if (ARObject == null)
                {
                    ARObject = ARObjectPrefab[0];
                    ARObject.SetActive(true);

                    AROrigin.position = new Vector3(AROrigin.position.x, 0 + liftHeight, AROrigin.position.z);
                }


            }
        }
    }
}
