using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	public bool CanMove { get; set; }

	public Rigidbody Rigidbody { get; private set; }

	[SerializeField] private float moveSpeed = 500;
	[SerializeField] private float moveSpeedMultiplier = 1;

	private Vector3 velocity;

	private void Awake()
	{
		Rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		if (!CanMove) return;
		velocity = Rigidbody.velocity;
		velocity.z = moveSpeed * moveSpeedMultiplier * Time.fixedDeltaTime;
		Rigidbody.velocity = velocity;
	}
}