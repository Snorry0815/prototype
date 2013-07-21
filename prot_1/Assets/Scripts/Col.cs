using UnityEngine;
using System.Collections;

public class Col : MonoBehaviour {

	public void OnCollisionEnter(Collision collision) {
		Debug.Log("collision!");
	}
}
