using UnityEngine;


public class Enemy : Trap
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
