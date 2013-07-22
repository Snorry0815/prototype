using UnityEngine;
using System.Collections;

using com.prototype.gameobjects.actions;
using com.prototype.gamestate;
	
public class Menu_1 : MonoBehaviour {
	public Texture btnTexture;
	
	public GameObject[] unitTypes;
	
	private CooldownButton _button;
	private CooldownButton _button2;
	private string _score;
	
	public Menu_1() {
		_score = "0:0";	
		GameState.Instance().SetMenu(this);
	}
	
	public void Start () {
		

		
		_button = new CooldownButton(0,btnTexture,10, 10,10,50,50, new SpawnUnitAction(unitTypes[0]));
		_button2 = new CooldownButton(1,btnTexture,10,Screen.width - 100,10,50,50, new SpawnUnitAction(unitTypes[0]));
	}
	
    public void OnGUI() {
		_button.OnGUI();
		_button2.OnGUI();
		
		int width = 50;
		int x = (Screen.width - width) / 2;
		GUI.Label(new Rect(x,10,width,50), _score);
    }
	
	// Update is called once per frame
	void Update () {		
	
	}
	
	public void SetScore(string score) {
		_score = score;
	}
}
