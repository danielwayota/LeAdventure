using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Hero : MonoBehaviour
{
    public float speed = 1;

    private bool hasSword = false;
    private int keys = 0;

    Rigidbody2D body;

    UIPanel ui;
    // ==============================
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();

        this.ui = GameObject.FindObjectOfType<UIPanel>();

        this.ui.UpdateKeys(this.keys);
        this.ui.UpdateSword(this.hasSword);
    }

    // ==============================
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 move = (new Vector2(horizontal, vertical)).normalized;

        this.body.velocity = move * speed;
    }

    // ================================
    public bool PickSword()
    {
		if (this.hasSword)
		{
			return false;
		}

        this.hasSword = true;
        this.ui.UpdateSword(this.hasSword);
		return true;
    }

	// ================================
	public bool UseSword()
	{
		bool used = false;
		if (this.hasSword)
		{
			this.hasSword = false;
			used = true;
		}

		this.ui.UpdateSword(this.hasSword);
		return used;
	}

    // ================================
    public void AddKey()
    {
        this.keys++;
        this.ui.UpdateKeys(this.keys);
    }

    // =================================
    public bool UseKey()
    {
        if (this.keys > 0)
        {
            this.keys--;
            this.ui.UpdateKeys(this.keys);
            return true;
        }
        return false;
    }
}
