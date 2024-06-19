using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Settings
{
	public class FogInitializer : MonoBehaviour
	{
		[SerializeField] private GameSettings gameSettings;	

		private void Start()
		{
			RenderSettings.fogStartDistance = gameSettings.fogStartValue;
			RenderSettings.fogEndDistance = gameSettings.fogEndValue;
			RenderSettings.fogColor = gameSettings.fogColor;
		}
	}
}

