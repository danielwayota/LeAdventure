using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : Trap
{
	public float speed = 8;

	// ============================
	void Start()
	{
		Destroy(this.gameObject, 5);
		var body = GetComponent<Rigidbody2D>();
		body.velocity = this.transform.up * speed;
	}

	// ============================
	protected override void PlayerCollision(Hero h)
	{
		base.PlayerCollision(h);
		Destroy(this.gameObject);
	}
}
