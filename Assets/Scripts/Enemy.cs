using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Enemy : MonoBehaviour
{

    // ============================
    void Start()
    {

    }

    // ============================
    void Update()
    {

    }

	// ============================
	private void OnTriggerEnter2D(Collider2D other)
	{
		Hero h = other.gameObject.GetComponent<Hero>();

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
