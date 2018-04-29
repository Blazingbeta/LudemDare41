using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    Vector3 velocity;
    new Transform transform;
    GameObject sender;
    float duration = 1.0f;
	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        duration -= Time.deltaTime;
        if(duration <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Initiliaze(Vector3 direction, GameObject sender)
    {
        this.sender = sender;
        velocity = direction.normalized * 7.0f;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject != sender && collision.gameObject.CompareTag("Player"))
        {
            Character c = collision.gameObject.GetComponent<Character>();
            c.TakeDamage(2.0f);
            Destroy(gameObject);
        }
    }
}
