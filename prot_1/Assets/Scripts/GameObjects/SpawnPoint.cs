using UnityEngine;
using System.Collections;

namespace com.prototype.gameobjects
{	

public class SpawnPoint : MonoBehaviour {
	public Material spawnPointMaterial;
	private int _player;
		
	public void CreateSpawnPoint(float size,int player) {
		_player = player;	
			
		Vector3[] vertices = new Vector3[4];
		Vector2[] uv = new Vector2[4];
		int[] triangles = new int[6];
		
		float sizeH = size / 2f;
		
		float xP = - sizeH;
		float zP = - sizeH;

		vertices[0] = new Vector3(xP,0,zP);
		vertices[1] = new Vector3(xP,0,zP+size);
		vertices[2] = new Vector3(xP+size,0,zP+size);
		vertices[3] = new Vector3(xP+size,0,zP);
		
		uv[0] = new Vector2(1,1);
		uv[1] = new Vector2(1,0);
		uv[2] = new Vector2(0,0);
		uv[3] = new Vector2(0,1);
		
		triangles[0] = 0;
		triangles[1] = 1;
		triangles[2] = 2;
		
		triangles[3] = 0;
		triangles[4] = 2;
		triangles[5] = 3;	
		
		this.gameObject.name = Definitions.SPAWN_POINT;
		this.gameObject.AddComponent("MeshFilter");
		this.gameObject.AddComponent("MeshRenderer");
		this.gameObject.AddComponent("MeshCollider");
			
		Mesh mesh = new Mesh();
		this.gameObject.GetComponent<MeshFilter>().mesh = mesh;
		mesh.Clear();
		mesh.vertices = vertices;
	    mesh.uv = uv;
	    mesh.triangles = triangles;
		mesh.RecalculateNormals();	
		
		this.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
		this.gameObject.GetComponent<MeshRenderer>().material = spawnPointMaterial;
	}
		
	public int GetPlayer() {
		return _player;		
	}
}
	
}