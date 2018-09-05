/**
 * OuOSword means One Use Only Sword.
 * By some Nestor.
 */

using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class OuOSword : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Hero h = other.gameObject.GetComponent<Hero>();

        h.PickSword();

        Destroy(this.gameObject);
    }
}
