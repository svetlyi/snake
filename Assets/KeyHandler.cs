using UnityEngine;
using System.Collections;

public class KeyHandler : MonoBehaviour {
	public GameObject light;
	// Use this for initialization
	void Start () {
		Debug.Log("I am alive!");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tempLightPos;
		tempLightPos.z = transform.position.z;
		tempLightPos.x = transform.position.x;
		tempLightPos.y = light.transform.position.y;
		light.transform.position = tempLightPos;

		tempLightPos = transform.position;
		tempLightPos.x += 0.1f;
		transform.position = tempLightPos;
	}
}
