using _Project.Scripts.TestScripts;
using System;
using System.Collections;
using UnityEngine;

namespace _Project.Scripts.DynamicEnvironmentLoader
{
	public class DynamicEnvironmentObject : MonoBehaviour
	{
		public GameObject modelToRender;

		#region Test Code
#if UNITY_EDITOR
		private void OnEnable()
		{
			TestBusSystem.OnEnableDynamicLoad += HandleDynamicLoadEnabled;
			TestBusSystem.OnDisableDynamicLoad += HandleDynamicLoadDisabled;
		}

		private void OnDisable()
		{
			TestBusSystem.OnEnableDynamicLoad -= HandleDynamicLoadEnabled;
			TestBusSystem.OnDisableDynamicLoad -= HandleDynamicLoadDisabled;
		}

		private void HandleDynamicLoadEnabled()
		{
			modelToRender.SetActive(false);
		}

		private void HandleDynamicLoadDisabled()
		{
			modelToRender.SetActive(true);
		}
#endif
		#endregion
	}
}