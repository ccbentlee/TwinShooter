/*
All assets created by Brian Moakley and the Unity Team at www.raywenderlich.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raywenderlich.TwinStickShooter.Chapter6 {
  public class WallTrigger : MonoBehaviour {

    private Animator arenaAnimator;

  	// Use this for initialization
  	void Start () {
      GameObject arena = transform.parent.gameObject;
      arenaAnimator = arena.GetComponent<Animator>();
  	}
  	
  	// Update is called once per frame
  	void Update () {
  		
  	}

    void OnTriggerEnter(Collider other) {
      arenaAnimator.SetBool("IsLowered", true);
    }

    void OnTriggerExit(Collider other) {
      arenaAnimator.SetBool("IsLowered", false);
    }
  }
}
