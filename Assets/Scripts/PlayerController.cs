using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	float xMin, xMax, yMin, yMax;

	// Use this for initialization
	void Start () {
		SetScreenplayBorders ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove ();
	}

	void SetScreenplayBorders()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		xMin = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 0f, distance)).x + 0.5f;
		xMax = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0f, distance)).x - 0.5f;
		yMin = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 0f, distance)).y + 0.4f;
		yMax = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 1f, distance)).y - 0.4f;
	}

	void PlayerMove()
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += Vector3.down * speed * Time.deltaTime;
		} 
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} 
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		float newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		float newY = Mathf.Clamp (transform.position.y, yMin, yMax);
		transform.position = new Vector3(newX, newY, transform.position.z);
	}
}

