using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Key : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		Hero h = other.gameObject.GetComponent<Hero>();

		h.AddKey();

		Destroy(this.gameObject);
	}	
}
