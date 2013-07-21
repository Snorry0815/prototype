using UnityEngine;
using System.Collections;

namespace com.prototype.gameobjects.actions
{	
	
public interface BasicAction {
	void Trigger(Vector3 startPoint, Vector2 distanc);
}
	
}