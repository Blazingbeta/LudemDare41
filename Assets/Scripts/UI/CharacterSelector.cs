using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Controls a player's token on the character select menu
/// </summary>
public class CharacterSelector : MonoBehaviour
{
	Vector2 m_startPos = Vector2.zero;
	[SerializeField] int m_currentCharacterIndex = 1;
	[SerializeField] UtilObjects.PlayerSlot m_playerID;
	[SerializeField] RectTransform m_portrait = null;
	RectTransform m_rectTransform;

	bool m_isTransitioning = false;
	bool m_lockedIn = false;
	private void Start()
	{
		m_rectTransform = GetComponent<RectTransform>();
		m_startPos = m_rectTransform.anchoredPosition;
		m_rectTransform.anchoredPosition = m_startPos + (Vector2.right * CharacterSelectMenu.IconDistance * (m_currentCharacterIndex));
	}
	private void Update()
	{
		if (!m_isTransitioning && !m_lockedIn)
		{
			float xDir = InputWrapper.GetHorizontalAxis(m_playerID);
			//Replace all these with input manager obviously
			if (xDir <= -0.3f && m_currentCharacterIndex != 0)
			{
				StartCoroutine(ChangeSelectedCharacter(-1));
			}
			else if (xDir >= 0.3f && m_currentCharacterIndex != 2)
			{
				StartCoroutine(ChangeSelectedCharacter(1));
			}
			else if (InputWrapper.GetAButton(m_playerID) || Input.GetKeyDown(KeyCode.A))
			{
				LockInSelection();
			}
		}
		else if (m_lockedIn && InputWrapper.GetBButton(m_playerID))
		{
			CharacterSelectMenu.i.UnselectCharacter(m_playerID);
			m_lockedIn = false;
		}
	}
	void LockInSelection()
	{
		m_lockedIn = true;
		CharacterSelectMenu.i.LockCharacter(m_playerID, 2);
	}
	IEnumerator ChangeSelectedCharacter(int direction)
	{
		m_isTransitioning = true;
		Vector2 currentPos = m_rectTransform.anchoredPosition;
		Vector2 targetPos = m_startPos + (Vector2.right * CharacterSelectMenu.IconDistance * (m_currentCharacterIndex+direction));
		Vector2 picPos = m_portrait.anchoredPosition;
		Vector2 picBackPos = m_portrait.anchoredPosition + Vector2.right * ((int)m_playerID - .5f) * 700f;
		float t = 2;
		while(t > 1)
		{
			t -= Time.deltaTime*3;
			m_rectTransform.anchoredPosition = Vector2.Lerp(targetPos, currentPos, t/2);
			m_portrait.anchoredPosition = Vector2.Lerp(picBackPos, picPos, t-1);
			yield return null;
		}
		CharacterSelectMenu.i.SwapCharacterPortrait(m_playerID, m_currentCharacterIndex + direction);
		while(t > 0)
		{
			t -= Time.deltaTime*3;
			m_rectTransform.anchoredPosition = Vector2.Lerp(targetPos, currentPos, t / 2);
			m_portrait.anchoredPosition = Vector2.Lerp(picPos, picBackPos, t);
			yield return null;
		}
		m_rectTransform.anchoredPosition = targetPos;
		m_portrait.anchoredPosition = picPos;
		m_currentCharacterIndex += direction;

		m_isTransitioning = false;
	}
}
