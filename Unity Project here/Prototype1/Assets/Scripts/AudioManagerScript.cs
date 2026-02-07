using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    // This script will control game music and sound effects.
    [Header("=====Audio Sources=====")]
    [SerializeField] AudioSource musicSource; // For background music
    [SerializeField] AudioSource SFXSource;   // For sound effects
    [SerializeField] AudioSource SFXquiteSource;


    [Header("=====Audio Clips=====")]
    public AudioClip Level1_Background;
    public AudioClip PlayerIdle;
    public AudioClip laser1;
    public AudioClip damage;
    public AudioClip attack;
    
    private void Start()
    {
        // Start playing background music
        musicSource.clip = Level1_Background;
        musicSource.Play();
        //musicPlayer.clip = PlayerIdle;
        //musicPlayer.Play();
        //musicPlayer.loop = true;
    }

    public AudioSource PlaySFX(AudioClip clipip)
    {
        SFXSource.clip = clipip;
        SFXSource.loop = false;
        SFXSource.Play();
        return SFXSource;
    }

    public AudioSource PlayQuietSFX(AudioClip clip)
    {
        SFXquiteSource.clip = clip;
        SFXquiteSource.loop = false;
        SFXquiteSource.Play();
        return SFXquiteSource;
    }

}
