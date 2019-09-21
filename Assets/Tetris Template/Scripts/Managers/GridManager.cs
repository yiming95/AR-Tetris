//  /*********************************************************************************
//   *********************************************************************************
//   *********************************************************************************
//   * Produced by Skard Games										                  *
//   * Facebook: https://goo.gl/5YSrKw											      *
//   * Contact me: https://goo.gl/y5awt4								              *											
//   * Developed by Cavit Baturalp Gürdin: https://tr.linkedin.com/in/baturalpgurdin *
//   *********************************************************************************
//   *********************************************************************************
//   *********************************************************************************/

using UnityEngine;
using System.Collections;


[System.Serializable]
public class Column
{
    public Transform[] row = new Transform[20];
}

public class GridManager : MonoBehaviour
{
    public Column[] gameGridcol = new Column[10];

    public bool InsideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < 10 && (int)pos.y >= 0);
    }

    public void PlaceShape()
    {
        int y = 0;

        StartCoroutine(DeleteRows(y));

    }

    IEnumerator DeleteRows(int k)
    {
        for (int y = k; y < 20; ++y)
        {
            if (IsRowFull(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y + 1);
                --y;
                Managers.Audio.PlayLineClearSound();
                yield return new WaitForSeconds(0.8f);
            }
        }     
        
        foreach (Transform t in Managers.Game.blockHolder)
            if (t.childCount <= 1)
            {
                Destroy(t.gameObject);
            }

        //New shape will be spawned
        Managers.Spawner.Spawn();

        yield break;
    }

    public bool IsRowFull(int y)
    {
        for (int x = 0; x < 10; ++x)
            if (gameGridcol[x].row[y] == null)
                return false;
        return true;
    }

    public void DeleteRow(int y)
    {
        Managers.Score.OnScore(100);
        for (int x = 0; x < 10; ++x)
        {
            Destroy(gameGridcol[x].row[y].gameObject);
            gameGridcol[x].row[y] = null;
        }
    }

    public void DecreaseRowsAbove(int y)
    {
        for (int i = y; i < 20; ++i)
            DecreaseRow(i);
    }

    public void DecreaseRow(int y)
    {
        for (int x = 0; x < 10; ++x)
        {
            if (gameGridcol[x].row[y] != null)
            {
                // Move one towards bottom
                gameGridcol[x].row[y - 1] = gameGridcol[x].row[y];
                gameGridcol[x].row[y] = null;

                // Update Block position
                gameGridcol[x].row[y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public bool IsValidGridPosition(Transform obj)
    {
        foreach (Transform child in obj)
        {
            if (child.gameObject.tag.Equals("Block"))
            {
                Vector2 v = Vector2Extension.roundVec2(child.position);

                if (!InsideBorder(v))
                {
                    return false;
                }

                // Block in grid cell (and not part of same group)?
                if (gameGridcol[(int)v.x].row[(int)v.y] != null &&
                    gameGridcol[(int)v.x].row[(int)v.y].parent != obj)
                    return false;
            }
        }
        return true;
    }

    public void UpdateGrid(Transform obj)
    {
        for (int y = 0; y < 20; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                if (gameGridcol[x].row[y] != null)
                {
                    if (gameGridcol[x].row[y].parent == obj)
                        gameGridcol[x].row[y] = null;
                }
            }
        }

        foreach (Transform child in obj)
        {
            if (child.gameObject.tag.Equals("Block"))
            {
                Vector2 v = Vector2Extension.roundVec2(child.position);
                gameGridcol[(int)v.x].row[(int)v.y] = child;
            }
        }
    }

    public void ClearBoard()
    {
        for (int y = 0; y < 20; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                if (gameGridcol[x].row[y] != null)
                {
                    Destroy(gameGridcol[x].row[y].gameObject);
                    gameGridcol[x].row[y] = null;
                }
            }
        }

        foreach (Transform t in Managers.Game.blockHolder)
            Destroy(t.gameObject);
    }

}
