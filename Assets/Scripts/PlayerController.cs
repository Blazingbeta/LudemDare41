using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {
    [SerializeField] public UtilObjects.PlayerSlot m_playerID;

    Animator m_animator;
	Character m_character;

    public Vector3 m_velocity;

    Vector3 angle = Vector3.right;

    new Transform transform;
	void Start () {
        transform = GetComponent<Transform>();
		m_character = GetComponent<Character>();
        m_animator = transform.GetChild(0).GetComponent<Animator>();
	}
    

	void Update ()
	{
        if (m_animator.GetBool("Attacking"))
        {
            m_animator.SetBool("Attacking", false);

        }

        if (m_character.state == Character.eState.BASE)
        {
            m_velocity = InputWrapper.GetLeftInput(m_playerID) * m_character.m_moveSpeed;
            Vector2 newDir = InputWrapper.GetRightInput(m_playerID);

            if (newDir.sqrMagnitude != 0)
            {
                angle = Vector3.RotateTowards(angle, newDir, m_character.m_turnSpeed * Time.deltaTime, 0);
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg);
            }

            if (InputWrapper.GetLeftTriggerDown(m_playerID))
            {
                m_character.DoDodge();
            }
            else
            {
                
                if (InputWrapper.GetRightTriggerDown(m_playerID))
                {
                    m_animator.SetBool("Attacking", true);
                    m_character.DoAttack1();              
                }
                else if (InputWrapper.GetRightBumperDown(m_playerID))
                {
                    m_character.DoAttack2();
                }
                else if (InputWrapper.GetLeftBumperDown(m_playerID))
                {
                    m_character.DoAttack3();
                }
            }

            if (m_velocity.sqrMagnitude > 0.0f)
            {
                m_animator.SetBool("IsRunning", true);
            }
            else
            {
                m_animator.SetBool("IsRunning", false);
            }

            transform.position += m_velocity * Time.deltaTime;
        }
		else if(m_character.state == Character.eState.ATTACK_DASH || m_character.state == Character.eState.DASH)
        {
            transform.position += m_velocity * Time.deltaTime;
        }
    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (m_character.state == Character.eState.ATTACK_DASH)
            {
                collision.transform.GetComponent<Character>().TakeDamage(3.0f);
                m_character.state = Character.eState.BASE;
                m_velocity = Vector3.zero;            
            }
        }
    }
}
