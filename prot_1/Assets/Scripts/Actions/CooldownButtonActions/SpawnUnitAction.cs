using UnityEngine;
using System.Collections;

namespace com.prototype.gameobjects.actions
{	
	
public class SpawnUnitAction : BasicAction {
	
	private GameObject _unitType;
		
	public SpawnUnitAction(GameObject unitType) {
		_unitType = unitType;		
	}
		
	public void Trigger(int player, Vector3 startPoint, Vector2 distance) {
		_unitType.GetComponent<BasicUnit>().Spawn(player,startPoint,distance);
	}
}
	
}