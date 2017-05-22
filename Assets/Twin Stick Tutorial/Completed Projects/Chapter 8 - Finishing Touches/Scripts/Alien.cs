/*
All assets created by Brian Moakley and the Unity Team at www.raywenderlich.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Raywenderlich.TwinStickShooter.Chapter8 {
  public class Alien : MonoBehaviour {

    public Transform target;
    public float navigationUpdate;
    public UnityEvent OnDestroy;
    public Rigidbody head;
    public bool isAlive = true;

    private float navigationTime = 0;
    private NavMeshAgent agent;
    private DeathParticles deathParticles;

  	// Use this for initialization
  	void Start () {
      agent = GetComponent<NavMeshAgent>();
      agent.enabled = false;
      isAlive = true;
  	}


    public DeathParticles GetDeathParticles() {
      if (deathParticles == null) {
        deathParticles = GetComponentInChildren<DeathParticles>();
      }
     return deathParticles;
   }

    public void Die() {
      isAlive = false;
      head.GetComponent<Animator>().enabled = false;
      head.isKinematic = false;
      head.useGravity = true;
      head.GetComponent<SphereCollider>().enabled = true;
      head.gameObject.transform.parent = null;
      head.velocity = new Vector3(0, 26.0f, 3.0f);
      OnDestroy.Invoke();
      OnDestroy.RemoveAllListeners();
      SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
      head.GetComponent<SelfDestruct>().Initiate();
      if (deathParticles) {
        deathParticles.transform.parent = null;
        deathParticles.Activate();
      }
      Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) {
      if (isAlive) {
        Die();
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
      }
    }

  	// Update is called once per frame
  	void Update () {
      if (isAlive) {
        if (target != null) {
          if (!agent.enabled) { agent.enabled = true; }
          navigationTime += Time.deltaTime;
          if (navigationTime > navigationUpdate) {
            agent.destination = target.position;
            navigationTime = 0;
          }
        }
      }
  	}
    
  }
}