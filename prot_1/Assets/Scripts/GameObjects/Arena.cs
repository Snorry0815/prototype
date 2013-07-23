using UnityEngine;
using System.Collections;

public class Arena {
	
	private int _x;
	private int _y;
	private int _z;
	
	private int _width;
	private int _height;
	private int _depth;
	
	
	private Texture _floorTexture;
	private Texture _wallTexture;
	
	public Arena(int x, int y, int z, int width, int height, int depth, Texture floorTexture, Texture wallTexture) {
		_x = x;
		_y = y;
		_z = z;
		_width = width;
		_height = height;
		_depth = depth;
		
		_floorTexture = floorTexture;
		_wallTexture = wallTexture;
	}
	
	public void Load() {
		GameObject arena = new GameObject();	
		arena.name = "Arena";
		CreateFloor(arena);
		CreateWalls(arena);
	}
	
	private void CreateFloor(GameObject arena) {
		Vector3[] vertices = new Vector3[4];
		Vector2[] uv = new Vector2[4];
		int[] triangles = new int[6];
		
		
		int floorY = _y - _height;
		vertices[0] = new Vector3(_x,floorY,_z);
		vertices[1] = new Vector3(_x,floorY,_z+_depth);
		vertices[2] = new Vector3(_x+_width,floorY,_z+_depth);
		vertices[3] = new Vector3(_x+_width,floorY,_z);
		
		uv[0] = new Vector2(2,1);
		uv[1] = new Vector2(2,0);
		uv[2] = new Vector2(0,0);
		uv[3] = new Vector2(0,1);
		
		triangles[0] = 0;
		triangles[1] = 1;
		triangles[2] = 2;
		
		triangles[3] = 0;
		triangles[4] = 2;
		triangles[5] = 3;	
		
		GameObject floor = new GameObject();	
		floor.name = "Floor";
		floor.AddComponent("MeshFilter");
		floor.AddComponent("MeshRenderer");
		//floor.AddComponent("MeshCollider");
			
		Mesh mesh = new Mesh();
		floor.GetComponent<MeshFilter>().mesh = mesh;
		mesh.Clear();
		mesh.vertices = vertices;
	    mesh.uv = uv;
	    mesh.triangles = triangles;
		mesh.RecalculateNormals();	
		
		//floor.GetComponent<MeshCollider>().sharedMesh = mesh;
		
		floor.GetComponent<MeshRenderer>().material.SetTexture("_MainTex",_floorTexture);
		
		floor.transform.parent = arena.transform;
	}
	
	
	private void CreateWalls(GameObject arena) {
		Vector3[] vertices = new Vector3[8];
		Vector2[] uv = new Vector2[8];
		int[] triangles = new int[24];
		
		
		int floorY = _y - _height;
		vertices[0] = new Vector3(_x,floorY,_z);
		vertices[1] = new Vector3(_x,floorY,_z+_depth);
		vertices[2] = new Vector3(_x+_width,floorY,_z+_depth);
		vertices[3] = new Vector3(_x+_width,floorY,_z);
		vertices[4] = new Vector3(_x,_y,_z);
		vertices[5] = new Vector3(_x,_y,_z+_depth);
		vertices[6] = new Vector3(_x+_width,_y,_z+_depth);
		vertices[7] = new Vector3(_x+_width,_y,_z);
		
		uv[0] = new Vector2(1,0);
		uv[4] = new Vector2(1,1);
		
		uv[1] = new Vector2(0,1);
		uv[5] = new Vector2(0,0);
		
		uv[2] = new Vector2(1,0);
		uv[6] = new Vector2(1,1);
		
		uv[3] = new Vector2(0,1);
		uv[7] = new Vector2(0,0);
		
		
		triangles[0] = 4;
		triangles[1] = 0;
		triangles[2] = 7;
		
		triangles[3] = 0;
		triangles[4] = 3;
		triangles[5] = 7;	
		
		triangles[6] = 5;
		triangles[7] = 1;
		triangles[8] = 4;
		
		triangles[9] = 1;
		triangles[10] = 0;
		triangles[11] = 4;
	
		triangles[12] = 5;
		triangles[13] = 6;
		triangles[14] = 2;
		
		triangles[15] = 2;
		triangles[16] = 1;
		triangles[17] = 5;
		
		triangles[18] = 6;
		triangles[19] = 7;
		triangles[20] = 3;
		
		triangles[21] = 3;
		triangles[22] = 2;
		triangles[23] = 6;	
		
		GameObject walls = new GameObject();	
		walls.name = "Walls";
		walls.AddComponent("MeshFilter");
		walls.AddComponent("MeshRenderer");
		walls.AddComponent("MeshCollider");
			
		Mesh mesh = new Mesh();
		walls.GetComponent<MeshFilter>().mesh = mesh;
		mesh.Clear();
		mesh.vertices = vertices;
	    mesh.uv = uv;
	    mesh.triangles = triangles;
		mesh.RecalculateNormals();	
		
		walls.GetComponent<MeshCollider>().sharedMesh = mesh;
		
		walls.GetComponent<MeshRenderer>().material.SetTexture("_MainTex",_wallTexture);
		walls.transform.parent = arena.transform;
	}
}
