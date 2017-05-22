/*
All assets created by Brian Moakley and the Unity Team at www.raywenderlich.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raywenderlich.TwinStickShooter.Chapter8 {
  public class Upgrade : MonoBehaviour {
    public Gun gun;

    void OnTriggerEnter(Collider other) {
      gun.UpgradeGun();
      Destroy(gameObject);
      SoundManager.Instance.PlayOneShot(SoundManager.Instance.powerUpPickup);
    }
  }
}