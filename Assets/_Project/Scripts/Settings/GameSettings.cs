using System.Collections;
using UnityEngine;

namespace _Project.Scripts.Settings
{
	[CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/Settings", order = 0)]
	public class GameSettings : ScriptableObject
	{
		[Header("Visibility Settings")]
		public float visibilityRange;
		public float fogStartValue;
		public float fogEndValue;

		[Header("Movement Settings")]
		public float movementSpeed;
		public float lookRotationSpeed;
		public float gravity;
	}
}