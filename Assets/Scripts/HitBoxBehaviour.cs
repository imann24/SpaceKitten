/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class HitBoxBehaviour : SKBehaviour {
	KittenBehaviour behaviour;

	void Start () {
		behaviour = GetComponentInParent<KittenBehaviour>();
	}

	protected override void HandleObjectWithTypeCollide (GameObject target, string objectType) {
		behaviour.OnCollidedWithHitBox(target, objectType);
	}
}
