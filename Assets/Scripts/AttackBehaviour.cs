/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class AttackBehaviour : SKBehaviour {
	public override void OnCollidedWithHitBox (GameObject target, string objectType) {
		if (target.GetComponent<EnemyBehaviour>()) {
			Destroy(gameObject);
		}
	}
}
