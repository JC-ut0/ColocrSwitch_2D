using UnityEngine;

public class Rotator : MonoBehaviour {

	public float speed = 100f;
	public GameObject outterCicle;
	private void Start()
	{
		speed = Random.Range(-200, 200);

		if (speed == 0 || Mathf.Abs(speed) <= 50)
		{
			speed = 100f;
		}
		else if(Mathf.Abs(speed) < 100) {
			Instantiate(outterCicle, new Vector2(0, transform.position.y), Quaternion.identity).GetComponent<Collider2D>().enabled = true;
		}
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(0f, 0f, speed * Time.deltaTime);
	}
}
