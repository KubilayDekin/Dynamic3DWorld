using _Project.Scripts.Settings;
using UnityEngine;

namespace _Project.Scripts.PlayerMovement
{
	public class MouseLook : MonoBehaviour
	{
		[Header("References")]
		public Transform playerBody;

		[Header("Rotation Settings")]
		public GameSettings gameSettings;

		private float lookRotationSpeed;
		private float xRotation = 0f;

		void Start()
		{
			lookRotationSpeed = gameSettings.lookRotationSpeed;

			// Hiding and locking the cursor, these below can be changed due to preferences.
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		private void Update()
		{
			float MouseX = Input.GetAxis("Mouse X") * lookRotationSpeed * Time.deltaTime;
			float MouseY = Input.GetAxis("Mouse Y") * lookRotationSpeed * Time.deltaTime;

			// Adjust vertical rotation and clamp it to avoid flipping
			xRotation -= MouseY;
			xRotation = Mathf.Clamp(xRotation, -90f, 90f);

			transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
			playerBody.Rotate(Vector3.up * MouseX);
		}
	}

}