using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Batas{
	public float xMin, xMax, zMin, zMax;
}

public class gerakPlayer : MonoBehaviour {

	public float speed;
	public float tilt;
	public Batas batas;

	public GameObject tembakan;
	public Transform spawnTembakan;
	public float lajupeluru;
	private float tembakanBerikut;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > tembakanBerikut) {
			tembakanBerikut = Time.time + lajupeluru;
			Instantiate (tembakan, spawnTembakan.position, spawnTembakan.rotation);
		}
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody> ().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, batas.xMin, batas.xMax),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, batas.zMin, batas.zMax)
		);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
