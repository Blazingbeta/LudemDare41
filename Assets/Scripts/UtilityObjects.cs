using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilObjects
{
	public delegate void IntCallbackDelegate(int result, PlayerSlot player);
	[System.Serializable]
	public enum PlayerSlot { P1, P2}
	public static class UtilFunctions
	{
		public static float AngleLerp(float angle1, float angle2, float t)
		{
			return angle1 + ShortAngleDistance(angle1, angle2) * t;
		}
		static float ShortAngleDistance(float angle1, float angle2)
		{
			float max = Mathf.PI * 2;
			float da = (angle1 - angle2) % max;
			return 2 * da % max - da;
		}

	}
}