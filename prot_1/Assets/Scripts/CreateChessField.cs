using UnityEngine;
using System.Collections;

public class CreateChessField : MonoBehaviour {
	
	public GameObject tile;
	public int x;
	public int y;
	public int z;
	public int width;
	public int height;
	
	// Use this for initialization
	void Start () {
		Create(tile,x,y,z,width,height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Create(GameObject tile, int xStart, int yStart, int z, int width, int height) {
		int yEnd = yStart + height;
		int xEnd = xStart + width;
		for(int y = yStart; y < yEnd; ++y) {
			for(int x = xStart; x < xEnd; ++x) {
				Instantiate(tile, new Vector3(x,y,z), Quaternion.identity);
			}
		}
	}
}
