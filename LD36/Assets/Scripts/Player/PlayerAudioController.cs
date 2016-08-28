using UnityEngine;
using System.Collections;

public class PlayerAudioController : MonoBehaviour
{

    private bool canPlayStepSound = true;
	private bool canPlayShotSound = true;

    public float playTime = 1f;
    public AudioClip footStep;
	public AudioClip shotgun;
	public AudioClip pistol;
    private AudioSource[] audioSources;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Use this for initialization
    void StartMove()
    {
        if (canPlayStepSound)
        {
            // Debug.Log("Play Sound");
            canPlayStepSound = false;

            if (audioSources[0].clip != footStep)
            {
                audioSources[0].clip = footStep;
            }

            audioSources[0].pitch = Random.Range(.8f, 1.2f);
            audioSources[0].Play();

            StartCoroutine(waitForNextStepSound(playTime));
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
		if (weapon.getWeaponType () == BasicWeapon.Type.SHOTGUN) {
			
			if (canPlayShotSound) {
				canPlayShotSound = false;
				StartCoroutine (waitForNextShotSound (playTime));
				audioSources [1].clip = shotgun;
				audioSources [1].Play ();

			}

		} else {
			if (canPlayShotSound) {
				canPlayShotSound = false;
				StartCoroutine (waitForNextShotSound (0.5f));
				audioSources [1].clip = pistol;
				audioSources [1].Play ();
			}
		}

	}
}
