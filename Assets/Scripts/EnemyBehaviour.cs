using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public int health;
	public GameObject laser;
	public float speed, projectileSpeed, firingRate;



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
