using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject[] shapeTypes;
    public GameObject temp;
    public static GameObject next;
    public static bool isFirst = true;
    public int i;

    public void Spawn()
	{
        if (isFirst)
        {
            showNext();
            isFirst = false;
        }
        // Spawn Group at current Position
        temp = Instantiate(shapeTypes[i]);
        Managers.Game.currentShape = temp.GetComponent<TetrisShape>();
        temp.transform.parent = Managers.Game.blockHolder;
        Managers.Input.isActive = true;
        showNext();
    }

    public void showNext()
    {
        // Random Shape
        i = Random.Range(0, 7);
        if (GameManager.difficulty == 1)
        {
            i = Random.Range(0, shapeTypes.Length);
            if (i >= 7)
            {
                i = Random.Range(0, shapeTypes.Length);
            }
        }
        Destroy(next);
        Debug.Log("next destroyed");
        next = Instantiate(shapeTypes[i]);
        Debug.Log("next instantiated");
        next.tag = "next";
        Debug.Log("tag changed");
        next.transform.localPosition = new Vector2(4.5f, 18f);
        next.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

    }
}
