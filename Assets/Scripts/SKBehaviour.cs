/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class SKBehaviour : MonoBehaviour {
	[SerializeField]
	string type;
	public float speed = 1.0f;

	public void SetObjectType (string objectType) {
		this.type = objectType;
	}

	public string GetObjectType () {
		return this.type;
	}

	public void MoveTowards (GameObject target) {
		StartCoroutine(MoveCoroutine(target));
	}

	public virtual void OnCollidedWithHitBox (GameObject target, string objectType) {
		// NOTHING
	}

	private IEnumerator MoveCoroutine (GameObject target) {
		while (target && transform.position != target.transform.position) {
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
			yield return new WaitForEndOfFrame();
		}
	}

	private void HandleObjectCollide (GameObject target) {
		SKBehaviour behaviour = target.GetComponent<SKBehaviour>();
		if (behaviour) {
			HandleSKObjectCollide(target, behaviour);
		}
	}

	private void HandleSKObjectCollide (GameObject target, SKBehaviour behaviour) {
		HandleObjectWithTypeCollide(target, behaviour.GetObjectType());
	}

	protected virtual void HandleObjectWithTypeCollide (GameObject target, string objectType) {
		// NOTHING
	}

	void OnTriggerEnter2D(Collider2D other) {
		HandleObjectCollide(other.gameObject);
	}
}
