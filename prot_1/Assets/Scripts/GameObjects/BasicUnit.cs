using UnityEngine;
using System.Collections;

public class BasicUnit : MonoBehaviour {
	
	public void Spawn(Vector3 startPoint, Vector2 distance) {
		Debug.Log("Spawned!");
		
		GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		Vector3 pos = startPoint;
		pos.y = -2f;
		ball.transform.position = pos;
		ball.AddComponent("Rigidbody");
		
		Vector3 force = new Vector3(distance.x,0f,distance.y);
		force.Normalize();
		force *= 1000f;
		
		ball.GetComponent<Rigidbody>().AddForce(force);
	}
}
