using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Transform GroundMarker;
    public LayerMask GroundLayer;


    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(this.transform.position, Vector3.down,  out hit,100f, GroundLayer))
        {
            GroundMarker.position = hit.point;
            Debug.Log(GroundMarker.position);
        }

    }


    public float GetGroundHeight()
    {
        return GroundMarker.position.y;
    }
}
