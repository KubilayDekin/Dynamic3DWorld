using System.Collections;
using UnityEngine;

namespace _Project.Scripts.PlayerMovement
{
	[RequireComponent(typeof(CharacterController))]
	public class PlayerController : MonoBehaviour
	{
		[Header("References")]
		public Transform groundCheckObject;
		public LayerMask groundMask;

		[Header("Movement Settings")]
		[SerializeField]
		private float movementSpeed;
		[SerializeField]
		private float gravity = -9.81f;
		[SerializeField]
		private float groundDistace = 0.4f;

		private CharacterController characterController;
		private Vector3 velocity;
		private bool isGrounded;

		private void Start()
		{
			characterController = GetComponent<CharacterController>(); // Cache the CharacterController component
		}

		private void Update()
		{
			// Check if the player is grounded by casting a sphere at the groundCheckObject's position
			isGrounded = Physics.CheckSphere(groundCheckObject.position, groundDistace, groundMask);

			if (isGrounded && velocity.y < 0)
			{
				velocity.y = -2f; // Ensure a small downward force to keep the player grounded
			}
			else
			{
				// Apply gravity to the player's velocity
				velocity.y += gravity * Time.deltaTime;
			}

			// Get the movement direction based on player input
			Vector3 movementDirection = GetMovementDirection();

			// Move the player in the specified direction
			characterController.Move(movementDirection * movementSpeed * Time.deltaTime);

			// Move the player according to gravity
			characterController.Move(velocity * Time.deltaTime);
		}

		// Determine the movement direction based on player input
		private Vector3 GetMovementDirection()
		{
			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");

			return transform.right * x + transform.forward * z;
		}
	}
}