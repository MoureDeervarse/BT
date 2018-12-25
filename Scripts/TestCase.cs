using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeInstance : MonoBehaviour
{
	private BehaviorTree bt;

	public void Start ()
    {
		bt = new BehaviorTree();
	}
	
	public void Update ()
    {
		bt.Update(Time.deltaTime);
	}
}
