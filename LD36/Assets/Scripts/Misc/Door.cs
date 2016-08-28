using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public Animator doorAnimC;
    public AudioSource audioSource;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        
        doorAnimC.SetBool("isOpen", true);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        doorAnimC.SetBool("isOpen", false);
    }
}
