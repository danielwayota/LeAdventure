using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Hero h = other.gameObject.GetComponent<Hero>();

        if (h.UseKey())
        {
            Destroy(this.gameObject);
        }
    }
}
