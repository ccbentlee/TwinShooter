/*
All assets created by Brian Moakley and the Unity Team at www.raywenderlich.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raywenderlich.TwinStickShooter.Chapter7 {
  public class SoundManager : MonoBehaviour {

    public static SoundManager Instance = null;  
    public AudioClip gunFire;
    public AudioClip upgradedGunFire;
    public AudioClip hurt;
    public AudioClip alienDeath;
    public AudioClip marineDeath;
    public AudioClip victory;
    public AudioClip elevatorArrived;
    public AudioClip powerUpPickup;
    public AudioClip powerUpAppear;
    private AudioSource soundEffectAudio;


  	// Use this for initialization
  	void Start () {
      if (Instance == null) {
        Instance = this;
      } else if (Instance != this) {
         Destroy(gameObject);
      } 
      AudioSource[] sources = GetComponents<AudioSource>();
      foreach (AudioSource source in sources) {
        if (source.clip == null) {
          soundEffectAudio = source;
        }
      }
  	}
  	
  	// Update is called once per frame
  	void Update () {
  		
  	}

    public void PlayOneShot(AudioClip clip) {
      soundEffectAudio.PlayOneShot(clip);
    } 

  }
}