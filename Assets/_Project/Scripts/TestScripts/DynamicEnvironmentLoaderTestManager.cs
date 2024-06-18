using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace _Project.Scripts.TestScripts
{
	public class DynamicEnvironmentLoaderTestManager : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private TextMeshProUGUI currentModeText;

		private bool isDynamicLoaderEnabled = true;

		private void Start()
		{
			SetCurrentModeText();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.T))
			{
				ArrangeDynamicLoader();
				SetCurrentModeText();
			}
		}

		private void ArrangeDynamicLoader()
		{
			if (isDynamicLoaderEnabled)
			{
				TestBusSystem.OnDisableDynamicLoad();
			}
			else
			{
				TestBusSystem.CallEnableDynamicLoad();
			}

			isDynamicLoaderEnabled = !isDynamicLoaderEnabled;
		}
			
		private void SetCurrentModeText()
		{
			if (isDynamicLoaderEnabled)
			{
				currentModeText.text = "Dynamic Loader Is <color=green>ON</color>";
			}
			else
			{
				currentModeText.text = "Dynamic Loader Is <color=red>OFF</color>";
			}
		}
	}
}