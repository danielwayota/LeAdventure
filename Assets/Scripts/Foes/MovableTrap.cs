using UnityEngine;

public class MovableTrap : Trap
{
	public Vector2 offset;
	public float moveSpeed = 1;

	private Vector3 startPosition;
	private Vector3 currentOffset;

	private float theta;

	// ============================
	void Start()
	{
		this.startPosition = this.transform.position;
		this.theta = 0;
	}

	// ============================
    void Update()
    {
		this.theta += Time.deltaTime * this.moveSpeed;

		this.currentOffset.Set(
			this.offset.x * Mathf.Cos(theta),
			this.offset.y * Mathf.Sin(theta),
			0
		);

		this.transform.position = this.startPosition + this.currentOffset;
    }
}
