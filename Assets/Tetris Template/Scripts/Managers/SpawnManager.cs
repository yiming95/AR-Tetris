using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject[] shapeTypes;

    public void Spawn()
	{
        // Random Shape
        int i = Random.Range(0, 7);
        if (GameManager.difficulty == 1)
        {
   		 i = Random.Range(0, shapeTypes.Length);
            if (i >= 7)
            {
                i = Random.Range(0, shapeTypes.Length);
            }
        }

		// Spawn Group at current Position
		GameObject temp =Instantiate(shapeTypes[i]) ;
        Managers.Game.currentShape = temp.GetComponent<TetrisShape>();
        temp.transform.parent = Managers.Game.blockHolder;
        Managers.Input.isActive = true;
    }
}
