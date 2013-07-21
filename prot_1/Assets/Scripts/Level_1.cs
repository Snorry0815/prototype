using UnityEngine;
using System.Collections;

using com.prototype.gameobjects;
using  com.prototype.gamestate;

public class Level_1 : MonoBehaviour {
	
	public Texture floorTexture;
	public Texture wallTexture;
	
	public GameObject spawnPoint;
	
	public int spawnPointCount;
	
	private GameObject[] spawnPointsLeft;
	private GameObject[] spawnPointsRigth;
	
	// Use this for initialization
	public void Start () {
		Arena arena = new Arena(-50,0,-20,100,2,40,floorTexture,wallTexture);
		arena.Load();
		
		CreateSpawnPoints();
		CreateDespawnArea();
	}
	
	private void CreateSpawnPoints() {
		
		float left = -20f;
		float right = -left;
		float height = 0.2f;
		
		float posZ = 15f;
		float steps = 0f;
		if(spawnPointCount > 1) {
			steps = 2f * posZ / (spawnPointCount - 1f);
		}
		
		spawnPointsLeft = new GameObject[spawnPointCount];
		spawnPointsRigth = new GameObject[spawnPointCount];
		
		for(int i=0; i<spawnPointCount;++i) {
			spawnPointsLeft[i] =  (GameObject)Instantiate(spawnPoint,new Vector3(left,height,posZ),Quaternion.identity);
			spawnPointsLeft[i].GetComponent<SpawnPoint>().CreateSpawnPoint(2f,0);	
			
			spawnPointsRigth[i] =  (GameObject)Instantiate(spawnPoint,new Vector3(right,height,posZ),Quaternion.identity);
			spawnPointsRigth[i].GetComponent<SpawnPoint>().CreateSpawnPoint(2f,1);	
			
			posZ -= steps;
		}
		
	}
	
	private void CreateDespawnArea() {
		DespawnArea.CreateDespawnArea(0,-23,40f);
		DespawnArea.CreateDespawnArea(1,23,40f);
	}
}
