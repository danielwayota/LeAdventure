/**
 * OuOSword means One Use Only Sword.
 * By some Nestor.
 */

using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class OuOSword : MonoBehaviour
{
    public AudioClip swordClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Hero h = other.gameObject.GetComponent<Hero>();

        h.PickSword();

        AudioSource.PlayClipAtPoint(this.swordClip, this.transform.position);
        Destroy(this.gameObject);
    }
}
