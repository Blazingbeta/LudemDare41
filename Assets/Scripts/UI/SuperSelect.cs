using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the selection of a character's super move before the round starts.
/// Each character has their own local version of this object.
/// </summary>
public class SuperSelect : MonoBehaviour
{
	public UtilObjects.PlayerSlot m_playerID;
	public CanvasGroup m_superMenuGroup = null;
	UtilObjects.IntCallbackDelegate callback;
	bool superSelected = true;
	public void ShowSuperMenu(UtilObjects.IntCallbackDelegate resultCallback)
	{
		superSelected = false;
		callback = resultCallback;
		m_superMenuGroup.alpha = 1;
		//Do super menu setup
	}
	IEnumerator FadeSuperMenu()
	{
		float t = 1.0f;
		while(t > 0)
		{
			yield return null;
			t -= Time.deltaTime;
			m_superMenuGroup.alpha = t;
		}
		m_superMenuGroup.alpha = 0;
	}
	private void Update()
	{
		if (!superSelected)
		{
			if (InputWrapper.GetLeftTriggerDown(m_playerID))
			{
				SelectSuper(0);
			}
			else if (InputWrapper.GetRightBumperDown(m_playerID) || Input.GetKeyDown(KeyCode.B))
			{
				SelectSuper(1);
			}
			else if (InputWrapper.GetLeftBumperDown(m_playerID))
			{
				SelectSuper(2);
			}
		}
	}
	void SelectSuper(int number)
	{
		//Super menu cleanup
		superSelected = true;
		callback(number, m_playerID);
		StartCoroutine(FadeSuperMenu());
	}
}
