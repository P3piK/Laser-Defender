using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public int health;
	public GameObject laser;
	public float speed, projectileSpeed, firingRate;


	void Start()
	{
		InvokeRepeating("Fire", 0.000001f, Mathf.Clamp (Random.value * 5, 0.4f, 1.2f));
	}
	
	void Fire()
	{
		Vector3 pos = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
		GameObject beam = (GameObject) Instantiate(laser, pos, Quaternion.identity);
		beam.rigidbody2D.velocity = new Vector2(0f,-projectileSpeed);
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Projectile missle = col.gameObject.GetComponent<Projectile> ();
		if(missle)
		{
			missle.Hit();
			health -= missle.GetDamage();
			if(health <= 0)
				Destroy(gameObject);
		}
	}
}
