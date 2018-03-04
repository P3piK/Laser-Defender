using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width, height;
	public float speed;

	private float spawnDelay = 0.5f;
	private bool movingRight = true;
	private float xMin, xMax;

	// Use this for initialization
	void Start () {
		SetBorders ();

	}

	// Update is called once per frame
	void Update () {
		if (AllEnemiesDead()) {
			SpawnUntilFull();
		}

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

	void SpawnUntilFull()
	{
		Transform freePosition = NextFreePosition ();
		if (freePosition != null) {
			GameObject enemy = (GameObject)Instantiate (enemyPrefab, freePosition.position, Quaternion.identity);
			enemy.transform.parent = freePosition;
		}
		if (NextFreePosition ()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}

	Transform NextFreePosition()
	{
		foreach (Transform child in transform) {
			if(child.childCount == 0)
				return child;
		}
		return null;
	}

	bool AllEnemiesDead()
	{
		foreach (Transform child in transform) {
			if(child.childCount > 0)
			{
				return false;
			}
		}
		return true;
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
