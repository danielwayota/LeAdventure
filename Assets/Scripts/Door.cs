using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite closed;
    public Sprite opened;

    public AudioClip doorSound;

    private SpriteRenderer leRenderer;

    private BoxCollider2D[] colliders;

    // ================================
    void Start()
    {
        this.leRenderer = GetComponent<SpriteRenderer>();

        this.leRenderer.sprite = closed;

        this.colliders = GetComponents<BoxCollider2D>();
    }

    // ================================
    private void OnTriggerEnter2D(Collider2D other)
    {
        Hero h = other.gameObject.GetComponent<Hero>();

        if (h.UseKey())
        {
            this.leRenderer.sprite = opened;
            AudioSource.PlayClipAtPoint(this.doorSound, this.transform.position);
            foreach (BoxCollider2D col in this.colliders)
            {
                col.enabled = false;
            }
        }
    }
}
