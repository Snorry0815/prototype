using UnityEngine;
using System.Collections;

using com.prototype.gameobjects.actions;
using com.prototype.gamestate;

public class CooldownButton {
	
	private enum State {
		ACTIVE,
		COOLDOWN,
		SELECTED
	}
	
	private int _player;
	private Texture _texture;
	private float _coolDownTimeInSec;
	private int _x;
	private int _y;
	private int _width;
	private int _height;
	private GUIStyle _coolDownStyle;
	private GUIStyle _selectedStyle;
	
	private State _state;
	private float _timeInCoolDown;
	private BasicAction _action;
	
	public CooldownButton(int player,Texture texture, int coolDownTimeInSec, int x, int y, int width, int height, BasicAction action) {
		_player = player;
		
		_texture = texture;
		_coolDownTimeInSec = coolDownTimeInSec;
		_x = x;
		_y = y;
		_width = width;
		_height = height;
		_state = State.ACTIVE;
		
		_action = action;
		InitCoolDownTexture();
		InitSelectedTexture();
	}
	
	public void OnGUI() {
		Update();
		
		if(_state == State.SELECTED) {
			DrawSelected();
		}
        if (GUI.Button(new Rect(_x,_y,_width,_height),_texture, GUIStyle.none)) {
			Pressed();
		}
		if(_state == State.COOLDOWN) {
			DrawCoolDown();
		}
    }
	
	private void InitCoolDownTexture() {
		Texture2D gray = new Texture2D(1, 1);
		Color color = new Color(0.1f,0.1f,0.1f,0.8f);
		gray.SetPixel(0,0,color);
		gray.wrapMode = TextureWrapMode.Repeat;
		gray.Apply();
		_coolDownStyle = new GUIStyle();
		_coolDownStyle.normal.background = gray;
	}
	
	private void InitSelectedTexture() {
		Texture2D yellow = new Texture2D(1, 1);
		Color color = new Color(1.0f,1.0f,0.0f,0.9f);
		yellow.SetPixel(0,0,color);
		yellow.wrapMode = TextureWrapMode.Repeat;
		yellow.Apply();
		_selectedStyle = new GUIStyle();
		_selectedStyle.normal.background = yellow;
	}
	
	private void DrawCoolDown() {
		float percent = 1f - _timeInCoolDown / _coolDownTimeInSec;
		
		float offset = _height*percent;
		float rest = _height - offset;
		GUI.Label(new Rect(_x,_y+rest,_width,offset), "", _coolDownStyle);
	}
	
	private void DrawSelected() {
		float overlay = 5f;
		GUI.Label(new Rect(_x-overlay,_y-overlay,_width+2*overlay,_height+2*overlay), "", _selectedStyle);
	}
	
	private void Update() {
		if(_state == State.COOLDOWN) {
			_timeInCoolDown += Time.deltaTime;
			if(_timeInCoolDown >= _coolDownTimeInSec) {
				_state = State.ACTIVE;
			}
		}
	}
	
	private void Pressed() {
		switch(_state) {
			case State.ACTIVE: 
				Selected();
				break;
		case State.SELECTED:
				break;
			case State.COOLDOWN:
				break;
			default:
				Debug.Log("Warning: Unknown button state " + _state.ToString());
				break;
		}
	}
	
	private void Selected() {
		GameState.Instance().SetSelectedButton(this,_player);
		_state = State.SELECTED;
	}
	
	public void Activated(Vector3 startPoint, Vector2 distance) {
		GameState.Instance().ActivatedSelectedButton(this,_player);
		_state = State.COOLDOWN;
		_timeInCoolDown = 0f;
		_action.Trigger(_player,startPoint,distance);
		Debug.Log("Activated!");
	}
	
	public void Reset() {
		_state = State.ACTIVE;
	}
}
