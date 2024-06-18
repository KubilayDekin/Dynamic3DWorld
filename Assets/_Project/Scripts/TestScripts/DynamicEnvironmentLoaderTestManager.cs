using TMPro;
using UnityEngine;

namespace _Project.Scripts.TestScripts
{
	public class DynamicEnvironmentLoaderTestManager : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private TextMeshProUGUI currentModeText;
		[SerializeField] private TextMeshProUGUI currentFogText;

		private bool isDynamicLoaderEnabled = true;
		private bool isFogEnabled = true;

		private void Start()
		{
			SetCurrentModeText();
			SetCurrentFogText();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.T))
			{
				ArrangeDynamicLoader();
				SetCurrentModeText();
			}

			if (Input.GetKeyDown(KeyCode.F))
			{
				RenderSettings.fog = !RenderSettings.fog;
				isFogEnabled = RenderSettings.fog;

				SetCurrentFogText();
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

		private void SetCurrentFogText()
		{
			if (isFogEnabled)
			{
				currentFogText.text = "Fog Is <color=green>ON</color>";
			}
			else
			{
				currentFogText.text = "Fog Is <color=red>OFF</color>";
			}
		}
	}
}