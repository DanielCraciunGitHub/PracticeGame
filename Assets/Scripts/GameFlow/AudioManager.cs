using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource[] audioSources;
    static AudioClip bulletSound;
    static AudioClip orbSound;

    void Start() // array ordered based on ordering of audiosources components in inspector
    {
        audioSources = GetComponents<AudioSource>();
        bulletSound = audioSources[0].clip;
        orbSound = audioSources[1].clip;

    }
    public static void playLaserSound()
    {
        audioSources[0].PlayOneShot(bulletSound);
    }
    public static void playOrbSound()
    {
        audioSources[1].PlayOneShot(orbSound);
    }
}