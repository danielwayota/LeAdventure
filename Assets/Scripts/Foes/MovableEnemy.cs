using UnityEngine;

public class MovableEnemy : MovableTrap
{
    public AudioClip enemyClip;

	protected override void PlayerCollision(Hero h)
	{
		if (h.UseSword())
		{
            AudioSource.PlayClipAtPoint(this.enemyClip, this.transform.position);
			Destroy(this.gameObject);
		}
		else
		{
			h.Die();
		}
	}
}
