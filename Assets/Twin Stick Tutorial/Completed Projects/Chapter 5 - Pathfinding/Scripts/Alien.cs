/*
All assets created by Brian Moakley and the Unity Team at www.raywenderlich.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Raywenderlich.TwinStickShooter.Chapter5 {
  public class Alien : MonoBehaviour {

    public Transform target;
    public float navigationUpdate;
    private float navigationTime = 0;
    private NavMeshAgent agent;

  	// Use this for initialization
  	void Start () {
      agent = GetComponent<NavMeshAgent>();
  	}
  	
  	// Update is called once per frame
  	void Update () {
      if (target != null) {
        navigationTime += Time.deltaTime;
        if (navigationTime > navigationUpdate) {
          agent.destination = target.position;
          navigationTime = 0;
        }
      }
  	}

    void OnTriggerEnter(Collider other) {
      Destroy(gameObject);
    }
  }
}