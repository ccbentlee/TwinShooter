/*
All assets created by Brian Moakley and the Unity Team at www.raywenderlich.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raywenderlich.TwinStickShooter.Chapter8 {
  public class SelfDestruct : MonoBehaviour {
    public float destructTime = 3.0f;

    public void Initiate() {
      Invoke("selfDestruct", destructTime);
    }

    private void selfDestruct() {
      Destroy(gameObject);
    }
  }
}