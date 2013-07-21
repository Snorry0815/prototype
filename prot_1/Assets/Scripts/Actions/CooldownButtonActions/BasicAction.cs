using UnityEngine;
using System.Collections;

namespace com.prototype.gameobjects.actions
{	
	
public interface BasicAction {
	void Trigger(int player, Vector3 startPoint, Vector2 distanc);
}
	
}