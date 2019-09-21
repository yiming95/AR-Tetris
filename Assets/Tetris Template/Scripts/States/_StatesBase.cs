using UnityEngine;
using System.Collections;

public abstract class _StatesBase : MonoBehaviour
{
	public abstract void OnActivate();
	public abstract void OnDeactivate();
	public abstract void OnUpdate();

	public override string ToString()
	{
		return this.GetType().ToString();
	}
}
