using UnityEngine;
using UnityEngine.Rendering;

public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance;

    public AudioSource SfxObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySound(AudioClip clip, Transform position, float volume)
    {
        AudioSource audioSource = Instantiate(SfxObject, position.position, Quaternion.identity);

        audioSource.clip = clip;

        audioSource.volume = volume;

        audioSource.Play();

        float cliplength = audioSource.clip.length;

        Destroy(audioSource.gameObject, cliplength);
    }
}
