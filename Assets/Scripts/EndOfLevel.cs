using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EndOfLevel : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		GameManager.instance.LoadNextLevel();
	}
}
