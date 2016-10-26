/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class SpawnController : SKBehaviour {
	public GameObject Dragon;
	public GameObject Wolf;
	public GameObject Shark;

	public GameObject Milk;
	public GameObject Tuna;
	public GameObject Friskies;

	public float spawnDelay = 2.5f;
	public bool spawningEnabled = true;

	void Start () {;
		StartCoroutine(WaitToStartSpawn(Random.Range(0.5f, 10.5f)));
	}

	IEnumerator WaitToStartSpawn (float waitTime) {
		yield return new WaitForSeconds(waitTime);
		StartCoroutine(SpawnCoroutine());
	}


	IEnumerator SpawnCoroutine () {
		while (spawningEnabled) {
			SpawnObject();
			yield return new WaitForSeconds(spawnDelay);
		}
	}

	void SpawnObject () {
		string objectType;
		GameObject prefab = Random.Range(0, 2) == 0 ? GetRandomEnemy(out objectType) : GetRandomFood(out objectType);
		if (prefab) {
			GameObject target;
			SKBehaviour behaviour = (target = (Instantiate(prefab) as GameObject)).GetComponent<SKBehaviour>();
			behaviour.SetObjectType(objectType);
			target.transform.position = transform.position;
			behaviour.MoveTowards(KittenBehaviour.kitten.gameObject);
			if (behaviour is EnemyBehaviour) {
				(behaviour as EnemyBehaviour).SetWeakness(GetWeakness(objectType));
			}
		}
	}


	GameObject GetRandomEnemy (out string enemyType) {
		enemyType = KittenBehaviour.RandomEnemy();
		if (enemyType == "Dragon") {
			return Dragon;
		} else if (enemyType == "Wolf") {
			return Wolf;
		} else if (enemyType == "Shark") {
			return Shark;
		} else {
			return null;
		}
	}

	GameObject GetRandomFood (out string foodType) {
		foodType = KittenBehaviour.RandomFood();
		if (foodType == "Milk") {
			return Milk;
		} else if (foodType == "Tuna") {
			return Tuna;
		} else if (foodType == "Friskies") {
			return Friskies;
		} else {
			return null;
		}
	}

	string GetWeakness (string enemyType) {
		if (enemyType == "Wolf") {
			return "Fire Ball";
		} else if (enemyType == "Dragon") {
			return "Ice Cubes";
		} else if (enemyType == "Shark") {
			return "Lightning Bolt";
		} else {
			return string.Empty;
		}
	}
}
