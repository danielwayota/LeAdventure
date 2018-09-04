using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Hero : MonoBehaviour
{
	public float speed = 1;

	public bool hasSword = false;
	private int keys = 0;

	Rigidbody2D body;

	UIPanel ui;
	// ==============================
	void Start ()
	{
		this.body = GetComponent<Rigidbody2D>();

		this.ui = GameObject.FindObjectOfType<UIPanel>();
	}
	
	// ==============================
	void Update ()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		Vector2 move = (new Vector2(horizontal, vertical)).normalized;

		this.body.velocity = move * speed;
	}

	// ================================
	public void AddKey() {
		this.keys ++;
		this.ui.UpdateKeys(this.keys);
	}

	// =================================
	public bool UseKey() {
		if (this.keys > 0) {
			this.keys --;
			this.ui.UpdateKeys(this.keys);
			return true;
		}
		return false;
	}
}
