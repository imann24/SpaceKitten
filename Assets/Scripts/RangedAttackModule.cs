/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class RangedAttackModule : SKBehaviour {
	KittenBehaviour kitten;

	void Start () {
		kitten = GetComponentInParent<KittenBehaviour>();
	}
		
	public override void OnCollidedWithHitBox (GameObject target, string objectType) {
		kitten.CheckToAttack(target, objectType);
	}
}
