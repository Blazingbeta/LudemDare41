using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWarrior : Character
{
  
    new Transform transform;
    [SerializeField] GameObject fireball;
    private void Start()
    {
        MaxHealth = 10.0f;
        transform = GetComponent<Transform>();
        m_playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        m_invincibility -= Time.deltaTime;
        if(m_invincibility < 0.0f && state != eState.PAUSE)
        {
            m_invincibility = 0.0f;
            state = eState.BASE;
        }
    }
    //Regular attack
    public override void DoAttack1()
	{
        if (CharacterCooldownVisualizer.GetCooldown(m_playerController.m_playerID, 0) > 0) return;
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, transform.right, 2.0f);
        Debug.DrawLine(transform.position, transform.position + transform.right * 2.0f, Color.red, 2.0f);
        if(hit && hit.transform.CompareTag("Player"))
        {
            hit.transform.GetComponent<Character>().TakeDamage(1.0f);
        }
        CharacterCooldownVisualizer.SetCooldown(m_playerController.m_playerID, 0, 1.0f);
	}

	public override void DoAttack2()
	{
        if (CharacterCooldownVisualizer.GetCooldown(m_playerController.m_playerID, 1) > 0) return;
        GameObject go = Instantiate(fireball, transform.position + transform.right, transform.rotation);
        go.GetComponent<Fireball>().Initiliaze(transform.right, gameObject);
        CharacterCooldownVisualizer.SetCooldown(m_playerController.m_playerID, 1, 5.0f);
    }
    //Dash attack
    public override void DoAttack3()
    {
        if (CharacterCooldownVisualizer.GetCooldown(m_playerController.m_playerID, 2) > 0) return;
        m_invincibility = .5f;
        state = Character.eState.ATTACK_DASH;
        m_playerController.m_velocity = transform.right * m_moveSpeed * 2.0f;
        CharacterCooldownVisualizer.SetCooldown(m_playerController.m_playerID, 2, 10.0f);
    }

    public override void DoDodge()
    {
        if (CharacterCooldownVisualizer.GetCooldown(m_playerController.m_playerID, 3) > 0) return;
        m_invincibility = .3f;
        state = Character.eState.DASH;
        Vector3 v = m_playerController.m_velocity.normalized;
        if (v.sqrMagnitude == 0.0f)
        {
            m_playerController.m_velocity = -transform.right * m_moveSpeed * 2.0f;
        }
        else
        {
            m_playerController.m_velocity = v * m_moveSpeed * 2.0f;
        }
        CharacterCooldownVisualizer.SetCooldown(m_playerController.m_playerID, 3, 8.0f);
    }

    public override void DoSuper()
	{
		throw new System.NotImplementedException();
	}

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }
}
