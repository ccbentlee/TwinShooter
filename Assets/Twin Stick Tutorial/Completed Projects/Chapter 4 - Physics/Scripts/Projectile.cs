/*
All assets created by Brian Moakley and the Unity Team at www.raywenderlich.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raywenderlich.TwinStickShooter.Chapter4 {
  public class Projectile : MonoBehaviour {

  	// Use this for initialization
  	void Start () {
  		
  	}
  	
  	// Update is called once per frame
  	void Update () {
  		
  	}

    void OnBecameInvisible() {
     Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision) {
      Destroy(gameObject);
    } 
  }
}
