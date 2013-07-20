using UnityEngine;
using System.Collections;

public class Menu_1 : MonoBehaviour {
	public Texture btnTexture;
	
	private CooldownButton _button;
	
	public void Start () {
		_button = new CooldownButton(btnTexture,10, 10,10,50,50);
	}
	
    public void OnGUI() {
		_button.OnGUI();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
