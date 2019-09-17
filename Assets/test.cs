using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public List<string> a;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(a.Count);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hello");
    }
}
