using UnityEngine;
using System.Collections;

using com.prototype.gameobjects;
using com.prototype.gamestate;


public class GameLoop : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		
		float dist = ray.origin.y / ray.direction.y;
		Vector3 mouseOnGamePlane = ray.GetPoint(-dist);
		
		
		if(Input.GetMouseButtonDown(0)) {
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(ray,out hit, 1000.0f) ) {
				if(hit.collider.name.Equals(Definitions.SPAWN_POINT)) {
					HitSpawnPoint(hit.collider.gameObject);	
				}
			}
		}
		
		
		GameState.Instance().UpdateMousePosition(mouseOnGamePlane);
		
		if(Input.GetMouseButtonUp(0)) {
			GameState.Instance().MouseUp();
		}
	}
	
	private void HitSpawnPoint(GameObject spawnPoint) {
		SpawnPoint spawnpointScript = spawnPoint.GetComponent<SpawnPoint>();	
		int player = spawnpointScript.GetPlayer();
		
		GameState gameState = GameState.Instance();
		gameState.HitSpawnPoint(spawnPoint, player);
	}
}
	
