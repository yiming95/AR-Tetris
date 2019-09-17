using UnityEngine;
using System.Collections;

public class ShapeMovementController : MonoBehaviour {

    public Transform rotationPivot;
    public float transitionInterval = 0.8f;
    public float fastTransitionInterval ;
    private float lastFall = 0;

    public void ShapeUpdate()
    {
        FreeFall();
    }

    public void RotateClockWise(bool isCw)
    {
        float rotationDegree = (isCw) ? 90.0f : -90.0f;

        transform.RotateAround(rotationPivot.position, Vector3.forward, rotationDegree);

        // Check if it's valid          
        if (Managers.Grid.IsValidGridPosition(this.transform)) // It's valid. Update grid.
        {
            Managers.Grid.UpdateGrid(this.transform);
        }
        else // It's not valid. revert rotation operation.
        {
            transform.RotateAround(rotationPivot.position, Vector3.forward, -rotationDegree);
        }
    }

    public void MoveHorizontal(Vector2 direction)
    {
        float deltaMovement = (direction.Equals(Vector2.right)) ? 1.0f : -1.0f;

        // Modify position
        transform.position += new Vector3(deltaMovement, 0, 0);

        // Check if it's valid
        if (Managers.Grid.IsValidGridPosition(this.transform))// It's valid. Update grid.
        {
            Managers.Grid.UpdateGrid(this.transform);
        }
        else // It's not valid. revert movement operation.
        {
            transform.position += new Vector3(-deltaMovement, 0, 0);
        }
    }

    public void FreeFall()
    {
        if (Time.time - lastFall >= transitionInterval)
        {
            // Modify position
            transform.position += Vector3.down;

            Managers.Audio.PlayDropSound();

            // See if valid
            if (Managers.Grid.IsValidGridPosition(this.transform))
            {
                // It's valid. Update grid.
                Managers.Grid.UpdateGrid(this.transform);
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                GetComponent<ShapeMovementController>().enabled = false;
                GetComponent<TetrisShape>().enabled = false;
                Managers.Game.currentShape = null;

                // Clear filled horizontal lines
                Managers.Grid.PlaceShape();
            }

            lastFall = Time.time;
        }
    }
    
    public void InstantFall()
    {
        transitionInterval = fastTransitionInterval;
    }
}
