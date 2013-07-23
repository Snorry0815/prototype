using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteAnimationSequence  {
	private List<Vector2> _sequence;
	private float _animationSpeed;
	public SpriteAnimationSequence(List<Vector2> sequence, float animationSpeed) {
		_sequence = sequence;
		_animationSpeed = animationSpeed;
	}
	
	public List<Vector2> GetSequence() {
		return _sequence;	
	}
	
	public float GetAnimationSpeed() {
		return _animationSpeed;
	}
	
}
