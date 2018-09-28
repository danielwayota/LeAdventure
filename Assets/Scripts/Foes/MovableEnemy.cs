using UnityEngine;

public class MovableEnemy : MovableTrap
{
	protected override void PlayerCollision(Hero h)
	{
		if (h.UseSword())
		{
			Destroy(this.gameObject);
		}
		else
		{
			h.Die();
		}
	}
}
