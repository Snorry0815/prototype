using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace com.prototype.animations
{	
	
public class SpriteAnimation {	
	private Texture _texture;
	private Dictionary<SpriteAnimationTypes.SpriteAnimationType,SpriteAnimationSequence> _spriteSequences;
	private float _width;
	private float _height;
		
	public SpriteAnimation(
			Texture texture, 
			Dictionary<SpriteAnimationTypes.SpriteAnimationType,SpriteAnimationSequence> spriteSequence,
			float width,
			float height) {
		_texture = texture;
		_spriteSequences = spriteSequence;
		_width = width;
		_height = height;
	}
		
	public Texture GetTexture() {
		return _texture;		
	}
		
	public SpriteAnimationSequence GetSpriteSequence(
			SpriteAnimationTypes.SpriteAnimationGroup sGroup, 
			SpriteAnimationTypes.SpriteAnimationDirection direction) {
		return _spriteSequences[SpriteAnimationTypes.GetSpriteAnimationType(sGroup,direction)];
	}
		
	public float GetWidth() {
		return _width;
	}
		
	public float GetHeight() {
		return _height;		
	}
}
	
}