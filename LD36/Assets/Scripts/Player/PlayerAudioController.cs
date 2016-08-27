using UnityEngine;
using System.Collections;

public class PlayerAudioController : MonoBehaviour {

    private bool canPlayStepSound = true;
    public float playTime = 1f;
    public AudioClip footStep;
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void StartMove()
    {
        if (canPlayStepSound)
        {
            // Debug.Log("Play Sound");
            canPlayStepSound = false;
            StartCoroutine(waitForNextStepSound(playTime));
            audioSource.clip = footStep;
            audioSource.Play();
        }
    }

    IEnumerator waitForNextStepSound(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        canPlayStepSound = true;
    }
}
