using UnityEngine;
using System.Collections;

public class DespawnArea : MonoBehaviour {
	
	private int _owner;
	
	public void SetOwner(int owner) {
		_owner = owner;
	}
	
	public int GetOwner() {
		return _owner;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnTriggerEnter(Collider collider) {
		BasicUnit bs = collider.gameObject.GetComponent<BasicUnit>();
		if(bs != null && !bs.IsOwner(_owner)) {
			Destroy(collider.gameObject);
		}
	}
	
	
	public static GameObject CreateDespawnArea(int player,float x, float scaleZ) {
		GameObject despawnArea = GameObject.CreatePrimitive(PrimitiveType.Cube);
		despawnArea.transform.position = new Vector3(x,0f,0f);
		despawnArea.transform.localScale = new Vector3(1f,5f,scaleZ);
		Destroy(despawnArea.GetComponent<MeshRenderer>());
		despawnArea.GetComponent<BoxCollider>().isTrigger = true;
		despawnArea.AddComponent("DespawnArea");
		despawnArea.GetComponent<DespawnArea>().SetOwner(player);
		
		return despawnArea;
	}
}
