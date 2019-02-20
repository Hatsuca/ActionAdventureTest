using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour {

	private NavMeshAgent navAgent;
	private Animator anim;
	private Transform mainCam;
	private Vector3 move;
	private Vector3 camForward;
	private Vector3 playerForward;

	[SerializeField]
	public float moveSpeed = 10.0f;
	[SerializeField]
	public float turnSpeed = 180.0f;

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();

		if (Camera.main != null) {
			mainCam = Camera.main.transform;
		} else {
			Debug.Log ("No Main Camera.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (mainCam != null) {
			camForward = Vector3.Scale (mainCam.forward, new Vector3 (1, 0, 1)).normalized;
			move = v * camForward + h * mainCam.right;
		} else {
			move = v * Vector3.forward + h * Vector3.right;
		}

		//移動、回転
		if (move.magnitude > 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
			anim.SetBool ("isMove", true);
			navAgent.Move (move * moveSpeed * Time.deltaTime);

			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(move, Vector3.up),turnSpeed * Time.deltaTime);

		} else {
			anim.SetBool ("isMove", false);
		}

		if (Input.GetButtonDown ("Fire1") && !anim.GetCurrentAnimatorStateInfo (0).IsName ("Attack") && !anim.IsInTransition (0)) {
			anim.SetTrigger ("Attack");
		}

	}
}
