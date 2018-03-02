using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStopper : MonoBehaviour 
{
	public ParallaxHandler ennemiParalax;
	public float displacedLock;

	void Update()
	{
		if(ennemiParalax.displaced > displacedLock)
		{
			ennemiParalax.speed = 0f;
		}
	}
}
