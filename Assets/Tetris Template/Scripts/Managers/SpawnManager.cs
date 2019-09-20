using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject[] shapeTypes;
    public GameObject temp;
    public GameObject next;
    public bool isFirst = true;
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
        //next = Instantiate(shapeTypes[i], new Vector3(0, 100, 0), Quaternion.identity);

    }
}
