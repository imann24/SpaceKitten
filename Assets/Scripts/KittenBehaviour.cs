/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KittenBehaviour : SKBehaviour {
	public static KittenBehaviour kitten;

	private static string[] foods = new string[]{"Tuna", "Milk", "Friskies"};
	private static string[] enemies = new string[]{"Dragon", "Wolf", "Shark"};
	private static string[] attacks = new string[]{"Ice Cubes", "Fire Ball", "Lightning Bolt"};

	public Image healthBar;
	public Image attackCooldownBar;
	public GameObject IceAttack;
	public GameObject FireAttack;
	public GameObject LightningAttack;

	int maxHealth = 100;
	int health;
	public float attackCooldownTime = 2.0f;
	bool attackCooldownActive = false;

	private bool ShouldAttack (string objectType) {
		// TODO: Return true if the object is in the enemies array
		return false;
	}

	private bool ShouldEat (string objectType) {
		// TODO: Return true if the object is in the foods array
		return false;
	}
		
	private string GetAttackType (string enemyType) {
		/* TODO: Return the correct attack type:
		 * Ice Cubes kill Dragons
		 * Fire Balls kill Wolves
		 * Lightning Bolts kill Sharks
		 */
		return string.Empty;	
	}


	private GameObject GetAttack (string attackType) {
		// TODO: Return the attack corresponding to the attack name
		return null;
	}


	void Start () {
		kitten = this;
		health = maxHealth;
	}

	public void CheckToAttack (GameObject target, string objectType) {
		if (ShouldAttack(objectType)) {
			Attack(target, objectType);
		}
	}
		
	public static string RandomFood () {
		return foods[Random.Range(0, foods.Length)];
	}

	public static string RandomEnemy () {
		return enemies[Random.Range(0, enemies.Length)];
	}

	public static string RandomAttack () {
		return attacks[Random.Range(0, attacks.Length)];
	}

	public override void OnCollidedWithHitBox (GameObject target, string objectType) {
		if (ShouldEat(objectType)) {
			Eat(target);
		} else if (target.GetComponent<RangedAttackModule>() == null) {
			Destroy(target);
		}
	}

	private IEnumerator AttackCooldown () {
		attackCooldownActive = true;
		float timer = 0;
		attackCooldownBar.fillAmount = 1;
		while (timer <= attackCooldownTime) {
			attackCooldownBar.fillAmount = 1 - timer / attackCooldownTime;
			yield return new WaitForEndOfFrame();
			timer += Time.deltaTime;
		}
		attackCooldownBar.fillAmount = 0;
		attackCooldownActive = false;	
	}

	private void Attack (GameObject enemy, string enemyType) {
		if (!attackCooldownActive) {
			string attackType = GetAttackType(enemyType);
			GameObject attackPrefab = GetAttack(attackType);
			if (attackPrefab) {
				AttackBehaviour attack = (Instantiate(attackPrefab) as GameObject).GetComponent<AttackBehaviour>();
				attack.SetObjectType(attackType);
				attack.MoveTowards(enemy);
			}
			StartCoroutine(AttackCooldown());
		}
	}

	public void Damage (int damage) {
		ChangeHealth(-damage);
	}

	private void Heal (int healthPoints) {
		ChangeHealth(healthPoints);
	}

	private float getHealthFraction () {
		return (float) health / (float) maxHealth;
	}

	private void updateHealthDisplay () {
		healthBar.fillAmount = getHealthFraction();
	}
	
	private void ChangeHealth (int deltaHealth) {
		health = Mathf.Clamp(health + deltaHealth, 0, maxHealth);
		updateHealthDisplay();
		if (HasPerished()) {
			ActivateGameOver();
		}
	}

	private void Eat (GameObject foodObject) {
		FoodBehaviour food = foodObject.GetComponent<FoodBehaviour>();
		if (food) {
			Heal(food.Eat());
		}
	}

	private bool HasPerished () {
		return health == 0;
	}

	private void ActivateGameOver () {
		GameController.Instance.GameOver();
		Destroy(gameObject);
	}
}
