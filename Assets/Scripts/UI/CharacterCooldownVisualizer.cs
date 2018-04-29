using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Manages the visual indicators for the cooldowns. The actual timers are stored locally, so technically its possible to desync but probably not.
/// </summary>
public class CharacterCooldownVisualizer : MonoBehaviour
{
	[SerializeField] private UtilObjects.PlayerSlot m_playerID;
	[SerializeField] private GameObject[] m_cooldowns = null;
    [SerializeField] private Slider m_healthBar = null;
	private Text[] m_cooldownTimers = null;
	private float[] m_timers = new float[4];
	private void Start()
	{
		m_visualizers[(int)m_playerID] = this;
		m_cooldownTimers = new Text[m_cooldowns.Length];
		for(int j = 0; j < m_cooldowns.Length; j++)
		{
			m_cooldowns[j].SetActive(false);
			m_cooldownTimers[j] = m_cooldowns[j].GetComponentInChildren<Text>();
			m_cooldownTimers[j].text = "0.0";
			m_timers[j] = 0.0f;
		}
	}
	private void Update()
	{
		for (int j = 0; j < m_cooldowns.Length; j++)
		{
			if(m_timers[j] > 0)
			{
				m_timers[j] -= Time.deltaTime;
				if(m_timers[j] <= 0)
				{
					m_cooldowns[j].SetActive(false);
					continue;
				}
				m_cooldownTimers[j].text = m_timers[j].ToString("0.0");
			}
		}
	}
	private void SetCooldown(int abilityIndex, float cooldown)
	{
		m_cooldowns[abilityIndex].SetActive(true);
		m_timers[abilityIndex] = cooldown;
		m_cooldownTimers[abilityIndex].text = m_timers[abilityIndex].ToString("0.0");
	}
	static CharacterCooldownVisualizer[] m_visualizers = new CharacterCooldownVisualizer[2];
	public static void SetCooldown(UtilObjects.PlayerSlot playerID, int abilityIndex, float cooldown)
	{
		m_visualizers[(int)playerID].SetCooldown(abilityIndex, cooldown);
	}
    public static float GetCooldown(UtilObjects.PlayerSlot playerID, int abilityIndex)
    {
        return m_visualizers[(int)playerID].m_timers[abilityIndex];
    }
    public static void SetHealthbar(UtilObjects.PlayerSlot playerID, float healthPercent)
    {
        m_visualizers[(int)playerID].m_healthBar.value = healthPercent;
    }
}
