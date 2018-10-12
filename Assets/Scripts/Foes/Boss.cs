using System.Collections;
using UnityEngine;

public class Boss : MovableEnemy
{
	public GameObject attackPrefab;

	public Transform shootPoint;

	public AudioClip attackSound;
	public float attackTime = 1.0f;
	public float dettectionRadius = 5f;

	private bool isActive = true;

	private Hero hero;

	// ===================================
	protected override void Start()
	{
		base.Start();
		this.hero = FindObjectOfType<Hero>();

		StartCoroutine(this.ShootCicle());
	}

	// ===================================
	IEnumerator ShootCicle ()
	{
		while (this.isActive)
		{
			if (Vector3.Distance(this.transform.position, this.hero.transform.position) < this.dettectionRadius)
			{
				Instantiate(this.attackPrefab, this.shootPoint.position, this.shootPoint.rotation);
				AudioSource.PlayClipAtPoint(this.attackSound, this.transform.position);
			}

			yield return new WaitForSeconds(this.attackTime);
		}
	}

	// ===================================
	void OnDestroy()
	{
		this.isActive = false;
	}

	// ===================================
	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(this.transform.position, this.dettectionRadius);
	}
}
