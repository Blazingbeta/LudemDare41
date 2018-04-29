using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds the virtual functions to be overriden by the individual characters. Anything that is generic (IE movement) will be stored elsewhere most likely
/// </summary>
public abstract class Character : MonoBehaviour
{
    public enum eState
    {   
        BASE,
        DASH,
        STUNNED,
        ATTACK_DASH,
        PAUSE
    }
    public eState state = eState.BASE;

    [SerializeField]
	public float m_moveSpeed = 5.0f;
	[SerializeField]
	public float m_turnSpeed = 5.0f;
	[SerializeField]
	public float m_health = 10.0f;
    protected PlayerController m_playerController;
    protected float m_invincibility = 0.0f;
    protected bool Alive = true;
    public bool isAlive { get { return Alive; } }

    protected float MaxHealth = 10.0f;
   

    public virtual void Initialize()
	{
        m_health = MaxHealth;
        state = Character.eState.PAUSE;
    }

    public virtual void StartRound(int superNum)
    {
        state = eState.BASE;
    }


	public abstract void DoDodge();
	public abstract void DoAttack1();
	public abstract void DoAttack2();
	public abstract void DoAttack3();
	public abstract void DoSuper();
    public virtual void TakeDamage(float damage)
    {
        if (m_invincibility == 0)
        {
            m_health -= damage;
            CharacterCooldownVisualizer.SetHealthbar(m_playerController.m_playerID, m_health / MaxHealth);
            if (m_health <= 0.0f)
            {
                m_health = 0.0f;
                Alive = false;
                RoundController.i.RoundOver(m_playerController.m_playerID);
            }
        }
    }
}
