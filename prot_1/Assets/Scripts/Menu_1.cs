using UnityEngine;
using System.Collections;

using com.prototype.gameobjects.actions;

public class Menu_1 : MonoBehaviour {
	public Texture btnTexture;
	
	public GameObject[] unitTypes;
	
	private CooldownButton _button;
	
	
	public void Start () {
		_button = new CooldownButton(0,btnTexture,10, 10,10,50,50, new SpawnUnitAction(unitTypes[0]));
	}
	
    public void OnGUI() {
		_button.OnGUI();
    }
	
	// Update is called once per frame
	void Update () {		
		//Debug.Log (Input.GetAxis("L_XAxis_1"));
	}
}
