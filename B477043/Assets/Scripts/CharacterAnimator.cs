using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour {

    const float locomotionAnimationSmoothTime = .1f;

    Rigidbody rb;
    PlayerController playerController;
    Animator animator;

	// Use this for initialization
	void Start () {
        playerController = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float speedPercent = playerController.moveSpeed;
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
        
	}
}
