using UnityEngine;
using System.Collections;

public class BasicUnit : MonoBehaviour {
	private int _owner;
	
	public void SetOwner(int owner) {
		_owner = owner;
	}
	
	public int GetOwner() { 
		return _owner;
	}
	
	public bool IsOwner(int owner) {
		return _owner == owner;	
	}
	
	
	public void Spawn(int player, Vector3 startPoint, Vector2 distance) {
		Debug.Log("Spawned!");
		
		GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		Vector3 pos = startPoint;
		pos.y = -1.5f;
		ball.transform.position = pos;
		ball.AddComponent("Rigidbody");
		
		Vector3 direction = new Vector3(distance.x,0f,distance.y); 
		direction.Normalize();
		
		ball.AddComponent("BasicUnit");
		ball.GetComponent<BasicUnit>().SetOwner(player);
		
		Vector3 force = new Vector3(distance.x,0f,distance.y);
		force.Normalize();
		force *= 1000f;
		
		ball.GetComponent<Rigidbody>().AddForce(force);
		ball.GetComponent<Rigidbody>().useGravity = false;
		
	}
	
	public void Update() {
	}
	
	public void OnCollisionEnter(Collision collision) {
		ContactPoint contactPoint = collision.contacts[0];
		
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		rigidbody.velocity = Vector3.Reflect ((collision.impactForceSum * -1), contactPoint.normal);

	}
}
