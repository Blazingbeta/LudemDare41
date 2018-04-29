using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectMenu : MonoBehaviour
{
	//These values will persist across scenes and be used to load the character from resources at runtime
	public static string PlayerOneCharacter = "Warrior", PlayerTwoCharacter = "Warrior";
	public static float IconDistance = 150.0f;
	[SerializeField] GameObject[] m_characters;
	[SerializeField] Sprite[] m_characterPortraits;
	[SerializeField] RawImage[] m_visualPortraits;

	bool p1LockedIn = false;
	bool p2LockedIn = false;

	public static CharacterSelectMenu i;
	private void Awake()
	{
		i = this;
	}
	public void SwapCharacterPortrait(UtilObjects.PlayerSlot player, int newPictureIndex)
	{
		m_visualPortraits[(int)player].texture = m_characterPortraits[newPictureIndex].texture;
	}
	public void LockCharacter(UtilObjects.PlayerSlot player, int characterID)
	{
		if(player == UtilObjects.PlayerSlot.P1)
		{
			PlayerOneCharacter = m_characters[characterID].name;
			p1LockedIn = true;
		}
		else if(player == UtilObjects.PlayerSlot.P2)
		{
			PlayerTwoCharacter = m_characters[characterID].name;
			p2LockedIn = true;
		}
		if (p1LockedIn && p2LockedIn)
		{
			//TODO Load the next scene, now that both of the static strings are set properly
			UnityEngine.SceneManagement.SceneManager.LoadScene("ArenaDebug");
		}
	}
	public void UnselectCharacter(UtilObjects.PlayerSlot player)
	{
		if (player == UtilObjects.PlayerSlot.P1) p1LockedIn = false;
		else p2LockedIn = false;
	}
}
