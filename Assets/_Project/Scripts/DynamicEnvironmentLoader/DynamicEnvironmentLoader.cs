using _Project.Scripts.TestScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.DynamicEnvironmentLoader
{
	[RequireComponent(typeof(SphereCollider))]
	public class DynamicEnvironmentLoader : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField] private float visibleObjectRadius;
		[SerializeField] private LayerMask environmentObjectsLayerMask;

		private SphereCollider detectionCollider;

		private bool isDynamicLoadDisabled;

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
			isDynamicLoadDisabled = false;

			StartCoroutine(CO_HandleDynamicLoadEnabled());

			IEnumerator CO_HandleDynamicLoadEnabled()
			{
				yield return null;

				Collider[] colliders = Physics.OverlapSphere(transform.position, visibleObjectRadius);

				foreach (Collider col in colliders)
				{
					if (environmentObjectsLayerMask == (environmentObjectsLayerMask | (1 << col.gameObject.layer)))
					{
						if(col.TryGetComponent(out DynamicEnvironmentObject model))
						{
							model.modelToRender.SetActive(true);
						}
					}
				}
			}
		}

		private void HandleDynamicLoadDisabled() => isDynamicLoadDisabled = true;
#endif
		#endregion

		private void Start()
		{
			detectionCollider = GetComponent<SphereCollider>();

			detectionCollider.radius = visibleObjectRadius;
		}


		/// Makes objects visible if they have colliders entering the transform
		/// and their layers match the <param name="environmentObjectsLayerMask">. 
		/// Applies to objects with the
		/// <seealso cref="DynamicEnvironmentObject"> script attached.
		private void OnTriggerEnter(Collider other)
		{
#if UNITY_EDITOR
			if (isDynamicLoadDisabled)
				return;
#endif

			if ((environmentObjectsLayerMask.value & (1 << other.gameObject.layer)) != 0
				&& other.TryGetComponent(out DynamicEnvironmentObject model))
			{
				model.modelToRender.SetActive(true);
			}
		}

		/// Makes objects invisible if they have colliders entering the transform
		/// and their layers match the <param name="environmentObjectsLayerMask">. 
		/// Applies to objects with the
		/// <seealso cref="DynamicEnvironmentObject"> script attached.
		private void OnTriggerExit(Collider other)
		{
#if UNITY_EDITOR
			if (isDynamicLoadDisabled)
				return;
#endif

			if ((environmentObjectsLayerMask.value & (1 << other.gameObject.layer)) != 0
				&& other.TryGetComponent(out DynamicEnvironmentObject model))
			{
				model.modelToRender.SetActive(false);	
			}
		}
	}
}