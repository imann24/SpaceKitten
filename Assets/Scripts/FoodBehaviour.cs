/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class FoodBehaviour : SKBehaviour {
	[SerializeField]
	private int healthPointsFromEating;

	public int Eat () {
		Destroy(gameObject);
		return healthPointsFromEating;
	}
}
