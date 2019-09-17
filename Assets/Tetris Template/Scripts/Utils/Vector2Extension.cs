using UnityEngine;
using System.Collections;

public class Vector2Extension : MonoBehaviour {

    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }
}
