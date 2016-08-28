using UnityEngine;
using System.Collections;

public class PlayerAudioController : MonoBehaviour {

    private bool canPlayStepSound = true;
	private bool canPlayShotSound = true;

    public float playTime = 1f;
    public AudioClip footStep;
	public AudioClip shotgun;
    public AudioSource audioSource;
	public AudioSource audioSourceForGun;

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

	IEnumerator waitForNextShotSound(float time)
	{
		yield return new WaitForSecondsRealtime(time);
		canPlayShotSound = true;
	}

	void StartShooting(BasicWeapon weapon) {

		//If we have more GUNS!!!! than we can do
		//here a fancy swicht but for to guns....NOT
		if(weapon.getWeaponType() == BasicWeapon.Type.SHOTGUN) {
			
			if (canPlayShotSound) {
				
				canPlayShotSound = false;
				StartCoroutine (waitForNextShotSound (playTime));
				audioSourceForGun.clip = shotgun;
				audioSourceForGun.Play ();

			}

		}

	}
}
