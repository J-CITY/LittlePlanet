using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10f;
	public float rotationSpeed = 100f;

	private float horizontal;
	private Rigidbody rb;

	public FloatingJoystick joystick;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Config.isPause) {
			return;
		}
		if (PlayerCollision.isDie) {
			return;
		}

		horizontal = joystick.Direction.x;
	}

	void FixedUpdate ()
	{
		if (Config.isPause) {
			return;
		}
		if (PlayerCollision.isDie) {
			return;
		}
		rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
		Vector3 yRotation = Vector3.up * horizontal * rotationSpeed * Time.fixedDeltaTime;
		Quaternion deltaRotation = Quaternion.Euler(yRotation);
		Quaternion targetRotation = rb.rotation * deltaRotation;
		rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
		//transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
	}

}
