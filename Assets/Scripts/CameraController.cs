using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    new Transform transform;
    new Camera camera;
    GameObject[] players;
	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();
        camera = GetComponent<Camera>();
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
  
	}
    private void LateUpdate()
    {
        Vector3 temp = (players[0].transform.position - players[1].transform.position) / 2;

        Vector3 newPosition = (players[0].transform.position + players[1].transform.position) / 2;
        newPosition.z = -10.0f;
        transform.position = newPosition;

        camera.orthographicSize = Mathf.Clamp(temp.magnitude, 6.0f, 10.0f);
    }
}
