using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Trap : MonoBehaviour
{
	// ============================
	private void OnTriggerEnter2D(Collider2D other)
	{
		Hero h = other.gameObject.GetComponent<Hero>();

		if (h != null)
		{
			this.PlayerCollision(h);
		}
	}

	// ============================
	protected virtual void PlayerCollision(Hero h)
	{
		h.Die();
	}
}
