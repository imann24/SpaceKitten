/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class AttackBehaviour : SKBehaviour {

	protected override void HandleObjectWithTypeCollide (GameObject target, string objectType) {
		if (target.GetComponent<EnemyBehaviour>()) {
			Destroy(gameObject);
		}
	}

}
