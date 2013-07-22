using UnityEngine;
using System.Collections;

namespace com.prototype.gamestate
{	
	
public class GameState {
	private static GameState _gameState = null;	
		
	private PlayerState[] _players;
	private Menu_1 _menu;	
		
	private GameState() {
		_players = new PlayerState[2];
		_players[0] = new PlayerState();
		_players[1] = new PlayerState();
	}
		
	static public GameState Instance() {
		if(_gameState == null) {
			_gameState = new GameState();
		}
		return _gameState;
	}
		
	public void SetSelectedButton(CooldownButton selectedButton, int player) {
		_players[player].SetSelectedButton(selectedButton);
	}
	
	public CooldownButton GetSelectedButton(int player) {
		return _players[player].GetSelectedButton();
	}
		
	public void ActivatedSelectedButton(CooldownButton selectedButton, int player) {
		_players[player].ActivatedSelectedButton(selectedButton);
	}
		
	public void HitSpawnPoint(GameObject spawnPoint,int player) {
		_players[player].HitSpawnPoint(spawnPoint);	
	}
		
	public void UpdateMousePosition(Vector3 mousePosition) {
		_players[0].UpdateMousePosition(mousePosition);
		_players[1].UpdateMousePosition(mousePosition);
	}
		
	public void MouseUp() {
		_players[0].MouseUp();
		_players[1].MouseUp();	
	}
		
	public void SetMenu(Menu_1 menu) {
		_menu = menu;	
	}
		
	public void Scored(int player) {
		_players[player].Scored();
		_menu.SetScore(_players[0].GetScore() + ":" + _players[1].GetScore());
	}
}
	
}
