using UnityEngine;
using System.Collections;

public class CooldownButton {
	
	private enum State {
		ACTIVE,
		COOLDOWN
	}
	
	
	private Texture _texture;
	private float _coolDownTimeInSec;
	private int _x;
	private int _y;
	private int _width;
	private int _height;
	private GUIStyle _coolDownStyle;
	
	private State _state;
	private float _timeInCoolDown;
	
	public CooldownButton(Texture texture, int coolDownTimeInSec, int x, int y, int width, int height) {
		_texture = texture;
		_coolDownTimeInSec = coolDownTimeInSec;
		_x = x;
		_y = y;
		_width = width;
		_height = height;
		_state = State.ACTIVE;
		
		InitCoolDownTexture();
	}
	
	public void OnGUI() {
		Update();


		
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
	
	private void DrawCoolDown() {
		float percent = 1f - _timeInCoolDown / _coolDownTimeInSec;
		
		float offset = _height*percent;
		float rest = _height - offset;
		GUI.Label(new Rect(_x,_y+rest,_width,offset), "", _coolDownStyle);
	}
	
	private void Update() {
		_timeInCoolDown += Time.deltaTime;
		if(_timeInCoolDown >= _coolDownTimeInSec) {
			_state = State.ACTIVE;
		}
	}
	
	private void Pressed() {
		switch(_state) {
			case State.ACTIVE: 
				Activated();
				break;
			case State.COOLDOWN:
				break;
			default:
				Debug.Log("Warning: Unknown button state " + _state.ToString());
				break;
		}
	}
	
	private void Activated() {
		_state = State.COOLDOWN;
		_timeInCoolDown = 0f;
		Debug.Log("Activated!");
	}
}
