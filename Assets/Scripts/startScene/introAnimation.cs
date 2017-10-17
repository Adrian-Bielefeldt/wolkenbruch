using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introAnimation : MonoBehaviour {

	public Animator animator;

	public float speed;

	// Use this for initialization
	void Start () {
		animator.speed = speed;
		animator.enabled = false;
	}

	void Update() {
		if (Time.time > 5) {
			animator.enabled = true;
		}
	}
}
