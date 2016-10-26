/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class GameController : SKBehaviour {
	public static GameController Instance;

	public GameObject GameOverText;

	void Start () {
		Instance = this;
	}

	public void GameOver () {
		GameOverText.SetActive(true);
		foreach (SpawnController spawn in GetComponentsInChildren<SpawnController>()) {
			spawn.spawningEnabled = false;
		}
	}
}
