using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIManager : MonoBehaviour {
	[SerializeField] UtilObjects.PlayerSlot m_playerID;
	[SerializeField] Text m_name = null;
	[SerializeField] RawImage m_icon = null;
	[SerializeField] RawImage[] m_abilities = null;
	[SerializeField] Transform m_superMenu = null;
	void Start ()
	{
		CharacterUI charUI = Resources.Load<CharacterUI>("UI/" + ((m_playerID == UtilObjects.PlayerSlot.P1) ? CharacterSelectMenu.PlayerOneCharacter : CharacterSelectMenu.PlayerTwoCharacter));
		m_name.text = charUI.Name;
		m_icon.texture = charUI.CharacterIcon;
		for(int j = 0; j < m_abilities.Length; j++)
		{
			m_abilities[j].texture = charUI.AbilityIcons[j];
		}
		for(int j = 0; j < 3; j++)
		{
			Transform child = m_superMenu.GetChild(j);
			child.GetChild(1).GetComponent<RawImage>().texture = charUI.SuperMoves[j].Display;
			child.GetChild(2).GetComponent<Text>().text = charUI.SuperMoves[j].Name;
			child.GetChild(3).GetComponent<Text>().text = charUI.SuperMoves[j].Description;
		}
	}
}
