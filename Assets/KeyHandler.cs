using UnityEngine;
using System.Collections;

public class KeyHandler : MonoBehaviour {
	public GameObject light;
	public float speed = 0.1f;
	private GameObject[] chain = new GameObject[100];
	private int chainCounter = 0;

	// Use this for initialization
	void Start () {
		//GameObject newCube = new 
		for (int i = 0; i < 5; i++) {
			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphere.AddComponent<Rigidbody>().mass = 0.0002f;
			sphere.transform.position = new Vector3(i*3, 10, i*2);
			sphere.name = "sphere" + i.ToString();
			//GameObject light = GameObject.CreatePrimitive(PrimitiveType.s
		}
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

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name != "Plane") {
			chain[chainCounter] = col.gameObject;
			if (chainCounter > 1) {
				chain[chainCounter].AddComponent<FixedJoint>().connectedBody = col.gameObject.rigidbody;
			} else {
				this.gameObject.AddComponent<FixedJoint>().connectedBody = col.gameObject.rigidbody;
			}
			chainCounter ++;
		}
		//Destroy (col.gameObject);
	}

	private void keyHandler() {
		Vector3 oldObjPos = transform.position;
		//GameObject game = GameObject.Find("Plane");
		if (Input.anyKey) {
			oldObjPos = transform.position;
			if (Input.GetKey ("right")) {
				//oldObjPos.x += this.speed;
				this.gameObject.rigidbody.AddForce(10, 0, 0);
				//transform.Translate(0,0,10);
			}
			if (Input.GetKey ("left")) {
					oldObjPos.x -= this.speed;
				//this.gameObject.rigidbody.AddForce(0, -10, 0);
			}
			if (Input.GetKey ("up")) {
					oldObjPos.z += this.speed;	
				//this.gameObject.rigidbody.AddForce(10, 0, 0);
			}
			if (Input.GetKey ("down")) {
					oldObjPos.z -= this.speed;	
				//this.gameObject.rigidbody.AddForce(-10, 0, 0);
			}
			if (Input.GetKey ("space")) {
				this.gameObject.rigidbody.AddForce(0, 40, 0);
			}
			transform.position = oldObjPos;	
		}
	}

	void OnGUI() {
		Rect rect = new Rect (10,10,150,100);
		GUI.Label(rect, "Some information about this game!!!");
	}
}
