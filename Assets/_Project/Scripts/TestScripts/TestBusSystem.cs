using System;

namespace _Project.Scripts.TestScripts
{
	public static class TestBusSystem
	{
		public static Action OnEnableDynamicLoad;
		public static void CallEnableDynamicLoad() { OnEnableDynamicLoad?.Invoke(); }

		public static Action OnDisableDynamicLoad;
		public static void CallDisableDynamicLoad() { OnDisableDynamicLoad?.Invoke(); }
	}
}