using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CharacterUI")]
public class CharacterUI : ScriptableObject
{
	[SerializeField] public string Name = "";
	[SerializeField] public Texture CharacterIcon = null;
	[SerializeField] public Texture[] AbilityIcons = null;
	[SerializeField] public SuperMoveUI[] SuperMoves = null;
}
[System.Serializable]
public class SuperMoveUI
{
	[SerializeField] public string Name = "";
	[SerializeField] public Texture Display = null;
	[SerializeField] public string Description = "";
}