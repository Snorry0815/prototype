using UnityEngine;
using System.Collections;

namespace com.prototype.animations
{	
	
public class SpriteAnimationObject : MonoBehaviour {
	private float _x;
	private float _y;
	private float _width;
	private float _height;
		
	private SpriteAnimation _spriteAnimation;
	private SpriteAnimationTypes.SpriteAnimationGroup _group;
	private SpriteAnimationTypes.SpriteAnimationDirection _direction;	
		
	public void Create(
			GameObject gameObject,
			float x,
			float y,
			float width,
			float height,
			SpriteAnimation spriteAnimation,
			SpriteAnimationTypes.SpriteAnimationGroup sGroup,
			SpriteAnimationTypes.SpriteAnimationDirection direction) {
			
		_x = x;
		_y = y;
		_width = width;
		_height = height;
			
		_spriteAnimation = spriteAnimation;
		_group = sGroup;
		_direction = direction;
			
		CreateMesh(gameObject);
	}
		
	private void CreateMesh(GameObject gameObject) {
		Vector3[] vertices = new Vector3[4];
		Vector2[] uv = new Vector2[4];
		int[] triangles = new int[6];
		
		float startX = _x - _width / 2f;
		float startY = _y - _height / 2f;
			
		vertices[0] = new Vector3(startX,0f,startY);
		vertices[1] = new Vector3(startX,0f,startY+_height);
		vertices[2] = new Vector3(startX+_width,0f,startY+_height);
		vertices[3] = new Vector3(startX+_width,0f,startY);
		
		uv[0] = new Vector2(_spriteAnimation.GetWidth(),_spriteAnimation.GetHeight());
		uv[1] = new Vector2(_spriteAnimation.GetWidth(),0);
		uv[2] = new Vector2(0,0);
		uv[3] = new Vector2(0,_spriteAnimation.GetHeight());
		
		triangles[0] = 0;
		triangles[1] = 1;
		triangles[2] = 2;
		
		triangles[3] = 0;
		triangles[4] = 2;
		triangles[5] = 3;	
		
		gameObject.name = _spriteAnimation.GetTexture().name;
		gameObject.AddComponent("MeshFilter");
		gameObject.AddComponent("MeshRenderer");
			
		Mesh mesh = new Mesh();
		gameObject.GetComponent<MeshFilter>().mesh = mesh;
		mesh.Clear();
		mesh.vertices = vertices;
	    mesh.uv = uv;
	    mesh.triangles = triangles;
		mesh.RecalculateNormals();	
		
		gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex",_spriteAnimation.GetTexture());
	}
		
	
	public void Update () {
	
	}
		
	public static GameObject Init(
			float x,
			float y,
			float width,
			float height,
			SpriteAnimation spriteAnimation,
			SpriteAnimationTypes.SpriteAnimationGroup sGroup,
			SpriteAnimationTypes.SpriteAnimationDirection direction) {
		GameObject gameObject = new GameObject();
		gameObject.AddComponent("SpriteAnimationObject");
		gameObject.GetComponent<SpriteAnimationObject>().Create(
				gameObject,
				x,y,width,height,
				spriteAnimation,sGroup,direction
				);
		return gameObject;
	}
}
	
}