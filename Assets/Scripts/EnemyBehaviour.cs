using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public int health;
	public GameObject laser;
	public float speed, projectileSpeed;
	
	private int scoreValue = 10;
	private float firingRate = 0.5f;
	private ScoreKeeper scoreKeeper;

	void Start()
	{
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void Update()
	{
		float probability = Time.deltaTime * firingRate;
		if (Random.value < probability) {
			Fire ();
		}
	}
	
	void Fire()
	{
		GameObject beam = (GameObject) Instantiate(laser, transform.position, Quaternion.identity);
		beam.rigidbody2D.velocity = new Vector2(0f,-projectileSpeed);
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Projectile missle = col.gameObject.GetComponent<Projectile> ();
		if(missle)
		{
			missle.Hit();
			health -= missle.GetDamage();
			if(health <= 0){
				Destroy(gameObject);
				scoreKeeper.Score(scoreValue);
			}
		}
	}
}
