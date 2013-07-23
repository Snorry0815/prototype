using UnityEngine;
using System.Collections;

namespace com.prototype.animations
{	

public class SpriteAnimationTypes {
		
	public enum SpriteAnimationType {	
		WALKING_NORTH,
		WALKING_NORTH_WEST,
		WALKING_WEST,
		WALKING_SOUTH_WEST,
		WALKING_SOUTH,
		WALKING_SOUTH_EAST,
		WALKING_EAST,
		WALKING_NORTH_EAST,
		ATTACK_NORTH,
		ATTACK_NORTH_WEST,
		ATTACK_WEST,
		ATTACK_SOUTH_WEST,
		ATTACK_SOUTH,
		ATTACK_SOUTH_EAST,
		ATTACK_EAST,
		ATTACK_NORTH_EAST,	
		DIE
	}
		
	public enum SpriteAnimationGroup {
		WALKING,
		ATTACK,
		DIE
	}
		
	public enum SpriteAnimationDirection {
		NORTH,
		NORTH_WEST,
		WEST,
		SOUTH_WEST,
		SOUTH,
		SOUTH_EAST,
		EAST,
		NORTH_EAST	
	}
		
	public static SpriteAnimationType GetSpriteAnimationType(SpriteAnimationGroup sGroup, SpriteAnimationDirection direction) {
		switch(sGroup) {
			case SpriteAnimationGroup.WALKING:
				return GetSpriteAnimationTypeWalking(direction);
			case SpriteAnimationGroup.ATTACK:
				return GetSpriteAnimationTypeAttack(direction);
			case SpriteAnimationGroup.DIE:
				return SpriteAnimationType.DIE;
			default:
				return SpriteAnimationType.DIE;
		}
	}
	private static SpriteAnimationType GetSpriteAnimationTypeWalking(SpriteAnimationDirection direction) {
		switch(direction) {
			case SpriteAnimationDirection.NORTH:
				return SpriteAnimationType.WALKING_NORTH;
			case SpriteAnimationDirection.NORTH_WEST:
				return SpriteAnimationType.WALKING_NORTH_WEST;
			case SpriteAnimationDirection.WEST:
				return SpriteAnimationType.WALKING_WEST; 
			case SpriteAnimationDirection.SOUTH_WEST:
				return SpriteAnimationType.WALKING_SOUTH_WEST; 
			case SpriteAnimationDirection.SOUTH:
				return SpriteAnimationType.WALKING_SOUTH; 
			case SpriteAnimationDirection.SOUTH_EAST:
				return SpriteAnimationType.WALKING_SOUTH_EAST; 
			case SpriteAnimationDirection.EAST:
				return SpriteAnimationType.WALKING_EAST; 
			case SpriteAnimationDirection.NORTH_EAST:
				return SpriteAnimationType.WALKING_NORTH_EAST; 	
			default:
				return SpriteAnimationType.WALKING_NORTH;			
		}
	}	
		
	private static SpriteAnimationType GetSpriteAnimationTypeAttack(SpriteAnimationDirection direction) {
		switch(direction) {
			case SpriteAnimationDirection.NORTH:
				return SpriteAnimationType.ATTACK_NORTH;
			case SpriteAnimationDirection.NORTH_WEST:
				return SpriteAnimationType.ATTACK_NORTH_WEST;
			case SpriteAnimationDirection.WEST:
				return SpriteAnimationType.ATTACK_WEST; 
			case SpriteAnimationDirection.SOUTH_WEST:
				return SpriteAnimationType.ATTACK_SOUTH_WEST; 
			case SpriteAnimationDirection.SOUTH:
				return SpriteAnimationType.ATTACK_SOUTH; 
			case SpriteAnimationDirection.SOUTH_EAST:
				return SpriteAnimationType.ATTACK_SOUTH_EAST; 
			case SpriteAnimationDirection.EAST:
				return SpriteAnimationType.ATTACK_EAST; 
			case SpriteAnimationDirection.NORTH_EAST:
				return SpriteAnimationType.ATTACK_NORTH_EAST; 	
			default:
				return SpriteAnimationType.ATTACK_NORTH;					
		}
	}	
}

	
}