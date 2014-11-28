using UnityEngine;
using System.Collections;

public class KeyHandler : MonoBehaviour {
	public GameObject light;
	public float speed = 0.1f;
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

		this.keyHandler ();
	}

	private void keyHandler() {
		Vector3 oldObjPos = transform.position;
		//GameObject game = GameObject.Find("Plane");
		if (Input.anyKey) {
			oldObjPos = transform.position;
			if (Input.GetKey ("right")) {
					oldObjPos.x += this.speed;
			}
			if (Input.GetKey ("left")) {
					oldObjPos.x -= this.speed;	
			}
			if (Input.GetKey ("up")) {
					oldObjPos.z += this.speed;		
			}
			if (Input.GetKey ("down")) {
					oldObjPos.z -= this.speed;	
			}
			transform.position = oldObjPos;	
		}
	}

	void OnGUI() {
		Rect rect = new Rect (10,10,150,100);
		GUI.Label(rect, "Some information about this game!!!");
	}
}
