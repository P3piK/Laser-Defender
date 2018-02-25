using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width, height;
	public float speed = 5f;

	private bool movingRight = true;
	private float xMin, xMax;

	// Use this for initialization
	void Start () {
		SetBorders ();

		SpawnEnemies ();
	}

	// Update is called once per frame
	void Update () {
		MoveLeftOrRight ();

	}

	void SetBorders()
	{
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		xMin = Camera.main.ViewportToWorldPoint (new Vector3(0f, 0f, distanceToCamera)).x;
		xMax = Camera.main.ViewportToWorldPoint (new Vector3(1f, 0f, distanceToCamera)).x;
	}

	void SpawnEnemies()
	{
		foreach (Transform child in transform) {
			GameObject enemy = (GameObject)Instantiate (enemyPrefab, child.position, Quaternion.identity);
			enemy.transform.parent = child.transform;
		}
	}

	void MoveLeftOrRight()
	{
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if (transform.position.x > (xMax - width / 2))
			movingRight = false;
		else if (transform.position.x < (xMin + width / 2))
			movingRight = true;
	}

	public void OnDrawGizmos()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}
}
