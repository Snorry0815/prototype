using UnityEngine;
using System.Collections;

public class PlayerState {
	private CooldownButton _selectedButton = null;
	private GameObject _spawnPoint = null;
	private Vector2 _distance;
	private bool _targeted = false;
	
	public PlayerState() {
	
	}

	public void SetSelectedButton(CooldownButton selectedButton) {
		if(_selectedButton != null) {
			_selectedButton.Reset();
			_spawnPoint = null;
			_targeted = false;
		}
		_selectedButton = selectedButton;
	}
	
	public CooldownButton GetSelectedButton() {
		return _selectedButton;	
	}
	
	public void ActivatedSelectedButton(CooldownButton selectedButton) {
		if(_selectedButton == selectedButton) {
			_selectedButton = null;
			_spawnPoint = null;
			_targeted = false;
		}
	}
	
	public void HitSpawnPoint(GameObject spawnPoint) {
		if(_selectedButton != null) {
			_spawnPoint = spawnPoint;
		}		
	}
	
	public void UpdateMousePosition(Vector3 mousePosition) {
		if(_spawnPoint != null) {
			UpdateSelectedSpawnPoint(mousePosition);	
		}
	}
	
	private void UpdateSelectedSpawnPoint(Vector3 mousePosition) {
		Vector2 distance = new Vector2(
			mousePosition.x - _spawnPoint.transform.position.x, 
			mousePosition.z - _spawnPoint.transform.position.z);
		if(distance.sqrMagnitude > Definitions.MOUSE_TRIGGER_DISTANCE) {
			_distance = distance;	
			_targeted = true;	
		} else {
			_targeted = false;	
		}
	}
	
	public void MouseUp() {
		if(_targeted && _selectedButton != null) {
			_selectedButton.Activated(_spawnPoint.transform.position,_distance);	
		}
	}
	
}
