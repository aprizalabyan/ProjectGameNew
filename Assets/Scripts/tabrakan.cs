using System.Collections;
using UnityEngine;

public class tabrakan : MonoBehaviour {

	public GameObject playerExplosion;
	public GameObject explosion;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary" || other.tag == "Enemy") {
			return;
		}
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}

		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
