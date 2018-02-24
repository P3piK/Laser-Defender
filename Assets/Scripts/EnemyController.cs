using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			GameObject enemy = (GameObject)Instantiate (enemyPrefab, child.position, Quaternion.identity);
			enemy.transform.parent = child.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
