/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class EnemyBehaviour : SKBehaviour {
	public int attackPower = 10;
	string weakness;

	protected override void HandleObjectWithTypeCollide (GameObject target, string objectType) {
		if (!target.GetComponent<RangedAttackModule>() && target.GetComponentInParent<KittenBehaviour>()) {
			Attack(KittenBehaviour.kitten);
		} else if (objectType == weakness) {
			Destroy(gameObject);
		}
	}

	public void SetWeakness (string weakness) {
		this.weakness = weakness;
	}

	public void Attack (KittenBehaviour kitten) {
		kitten.Damage(attackPower);
		Destroy(gameObject);
	}

}
