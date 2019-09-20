
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int difficulty = 0; // 0 for easy, 1 for hard
    public static int difficultyTemp = 0;
    public bool isGameActive;
    public TetrisShape currentShape;
    public Transform blockHolder;
    public PlayerStats stats;

    void Awake()
	{
		isGameActive = false;
	}

	private _StatesBase currentState;
	public _StatesBase State
	{
		get { return currentState; }
	}

	//Changes the current game state
	public void SetState(System.Type newStateType)
	{
		if (currentState != null)
		{
			currentState.OnDeactivate();
		}

		currentState = GetComponentInChildren(newStateType) as _StatesBase;
		if (currentState != null)
		{
			currentState.OnActivate();
		}
	}

    void Update()
	{
        if (difficulty == 1)
        {
            Time.timeScale = 2;
        } else
        {
            Time.timeScale = 1;
        }
		if (currentState != null)
		{
			currentState.OnUpdate();
		}
	}

	void Start()
	{
		SetState(typeof(MenuState));
	}


}