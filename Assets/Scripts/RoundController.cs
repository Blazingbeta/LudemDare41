using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour {
	public static RoundController i;
	[SerializeField] SuperSelect m_p1Select = null;
	[SerializeField] SuperSelect m_p2Select = null;
	[SerializeField] Text m_countdownText = null;
	[SerializeField] Transform m_roundCounters = null;
	PlayerController player1;
	PlayerController player2;
	int p1Super;
	int p2Super;
	int[] roundCounter = new int[2];
	void Awake ()
	{
		i = this;
		Debug.Log(CharacterSelectMenu.PlayerOneCharacter + " vs " + CharacterSelectMenu.PlayerTwoCharacter);

		GameObject p1 = Instantiate(Resources.Load<GameObject>("Characters/" + CharacterSelectMenu.PlayerOneCharacter));
		GameObject p2 = Instantiate(Resources.Load<GameObject>("Characters/" + CharacterSelectMenu.PlayerTwoCharacter));

		player1 = p1.GetComponent<PlayerController>();
		player2 = p2.GetComponent<PlayerController>();

		player1.m_playerID = UtilObjects.PlayerSlot.P1;
		player2.m_playerID = UtilObjects.PlayerSlot.P2;

		NextRound();
	}
	void NextRound()
	{
		p1Super = -1;
		p2Super = -1;
		m_p1Select.ShowSuperMenu(SetSuper);
		m_p2Select.ShowSuperMenu(SetSuper);
		player1.transform.position = Vector3.right * -6;
		player2.transform.position = Vector3.right *  6;
		player1.GetComponent<Character>().Initialize();
		player2.GetComponent<Character>().Initialize();
	}
	public void RoundOver(UtilObjects.PlayerSlot loser)
	{
		StartCoroutine(EndRound(loser));
	}
	IEnumerator EndRound(UtilObjects.PlayerSlot loser)
	{
        UtilObjects.PlayerSlot winner = (loser == UtilObjects.PlayerSlot.P1) ? UtilObjects.PlayerSlot.P2 : UtilObjects.PlayerSlot.P1;
		m_roundCounters.GetChild((int)winner).GetChild(roundCounter[(int)winner]).GetComponent<RawImage>().color = Color.green;
		roundCounter[(int)winner]++;
		if (roundCounter[(int)winner] >= 3)
		{
			//Announce the winner
			m_countdownText.text = ((winner == UtilObjects.PlayerSlot.P1) ? CharacterSelectMenu.PlayerOneCharacter : CharacterSelectMenu.PlayerTwoCharacter) + " wins!";
			m_countdownText.gameObject.SetActive(true);
			yield return new WaitForSeconds(3.0f);
			UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelect");
		}
		else
		{
			m_countdownText.text = "Knockout!";
			m_countdownText.gameObject.SetActive(true);
			yield return new WaitForSeconds(2.0f);
			m_countdownText.gameObject.SetActive(false);
			NextRound();
		}
	}
	IEnumerator StartRound()
	{
		m_countdownText.gameObject.SetActive(true);
		m_countdownText.text = "3";
		yield return new WaitForSeconds(0.5f);
		m_countdownText.text = "2";
		yield return new WaitForSeconds(0.5f);
		m_countdownText.text = "1";
		yield return new WaitForSeconds(0.5f);
		m_countdownText.text = "FIGHT";
		yield return new WaitForSeconds(0.5f);
		m_countdownText.gameObject.SetActive(false);
		player1.GetComponent<Character>().StartRound(p1Super);
		player2.GetComponent<Character>().StartRound(p2Super);
	}
	void SetSuper(int id, UtilObjects.PlayerSlot slot)
	{
		if(slot == UtilObjects.PlayerSlot.P1)
		{
			p1Super = id;
		}
		else
		{
			p2Super = id;
		}
		if(p1Super != -1 && p2Super != -1)
		{
			StartCoroutine(StartRound());
		}
	}

}
