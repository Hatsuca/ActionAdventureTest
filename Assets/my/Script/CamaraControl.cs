using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour {

	private Vector3 diff;

	[SerializeField]
	public Transform playerTransform;

	// Use this for initialization
	void Start () {
		diff = transform.position - playerTransform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = playerTransform.position + diff;
	}
}
