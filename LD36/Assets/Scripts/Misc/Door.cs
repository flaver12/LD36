using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public Animator doorAnimC;
    public void OnTriggerEnter(Collider other)
    {
        doorAnimC.SetBool("isOpen", true);
    }

    public void OnTriggerExit(Collider other)
    {
        doorAnimC.SetBool("isOpen", false);
    }
}
