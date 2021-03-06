﻿/*
All assets created by Brian Moakley and the Unity Team at www.raywenderlich.com
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raywenderlich.TwinStickShooter.Chapter8 {
  public class Arena : MonoBehaviour {

    public GameObject player;
    public Transform elevator;
    private Animator arenaAnimator;
    private SphereCollider sphereCollider;

  	// Use this for initialization
  	void Start () {
      arenaAnimator = GetComponent<Animator>();
      sphereCollider = GetComponent<SphereCollider>();
  	}
  	
  	// Update is called once per frame
  	void Update () {
  		
  	}

    public void ActivatePlatform() {
      sphereCollider.enabled = true;
    } 

    void OnTriggerEnter(Collider other) {
      Camera.main.transform.parent.gameObject.GetComponent<CameraMovement>().enabled = false;
      player.transform.parent = elevator.transform;
      player.GetComponent<PlayerController>().enabled = false;
      SoundManager.Instance.PlayOneShot(SoundManager.Instance.elevatorArrived);
      arenaAnimator.SetBool("OnElevator", true);
    }

  }
}
