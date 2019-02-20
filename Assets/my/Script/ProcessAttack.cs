using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessAttack : MonoBehaviour {

	[SerializeField]
	public CapsuleCollider hitCol;

	// Use this for initialization
	void Start () {
	}

	void AttackStart () {
		hitCol.enabled = true;
	}

	public void AttackEnd() {
		hitCol.enabled = false;
	}
}
