using UnityEngine;
using System.Collections;

public class PlayerAnimController : MonoBehaviour {
    public Animator weaponAnimator;

    public void StartMove()
    {
        weaponAnimator.SetBool("isWalking", true);
    }
    public void StopMove()
    {
        weaponAnimator.SetBool("isWalking", false);
    }
}
