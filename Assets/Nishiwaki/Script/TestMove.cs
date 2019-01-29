using UnityEngine;

public class TestMove : MonoBehaviour
{
	private float x;

	private void Update()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
			x = -2.0f;
		else if (Input.GetKey(KeyCode.RightArrow))
			x = 2.0f;
		else
			x = 0.0f;

		transform.Rotate(0.0f, x, 0.0f);
	}
}