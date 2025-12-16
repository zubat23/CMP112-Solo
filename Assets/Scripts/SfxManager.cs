using UnityEngine;
using UnityEngine.Rendering;

public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance;

    public AudioSource SfxObject;

    private void Awake()
    {
        //Set up SFXmanager as a singleton
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySound(AudioClip clip, Transform position, float volume)
    {
        //Create an audio source instance
        AudioSource audioSource = Instantiate(SfxObject, position.position, Quaternion.identity);

        //Setup the clip and volume
        audioSource.clip = clip;

        audioSource.volume = volume;

        //Play the sound
        audioSource.Play();

        //Destroy the audio source after the clip has finished playing
        float cliplength = audioSource.clip.length;

        Destroy(audioSource.gameObject, cliplength);
    }
}
