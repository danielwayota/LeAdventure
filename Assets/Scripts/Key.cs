using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Key : MonoBehaviour
{
    public AudioClip keyClip;

    private void OnTriggerEnter2D(Collider2D other)
	{
		Hero h = other.gameObject.GetComponent<Hero>();

		h.AddKey();

        AudioSource.PlayClipAtPoint(this.keyClip, this.transform.position);

		Destroy(this.gameObject);
	}
}
