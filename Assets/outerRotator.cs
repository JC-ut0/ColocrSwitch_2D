using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outerRotator : MonoBehaviour
{
	public float speed = 100f;
	public GameObject outterCicle;
	private void Start()
	{
		speed = Random.Range(-200, 200);
		if (speed == 0)
		{
			speed = 100f;
		}
		else if (Mathf.Abs(speed) < 100)
		{
			speed = 100f;
		}
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(0f, 0f, speed * Time.deltaTime);
	}
}
