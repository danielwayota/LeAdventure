using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Hero : MonoBehaviour
{
    public float speed = 1;

    private bool hasSword = false;
    private int keys = 0;

    private Rigidbody2D body;
    private Animator animator;

    private UIPanel ui;
    // ==============================
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

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
        bool moving = move.sqrMagnitude != 0;

        this.animator.SetBool("Moving", moving);

        if (moving)
        {

            float angle = Mathf.Atan2(move.y, move.x);

            if (angle < 0)
            {
                angle += Mathf.PI * 2;
            }

            int facing = 0;
            if (angle < Mathf.PI / 2)
            {
                facing = 3;
            }
            else if (angle < Mathf.PI)
            {
                facing = 2;
            }
            else if (angle < (3 * Mathf.PI / 2))
            {
                facing = 1;
            }

            this.animator.SetInteger("FacingDirection", facing);
        }

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

    // =================================
    public void Die()
    {
        GameManager.instance.ShowDeathScreen();

        this.gameObject.SetActive(false);
    }
}
