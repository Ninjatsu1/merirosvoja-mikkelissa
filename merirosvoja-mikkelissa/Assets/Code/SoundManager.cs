using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip popSoundToDie;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        popSoundToDie = Resources.Load<AudioClip>("pop_1_low");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public static void playSound()
    {
        audioSource.PlayOneShot(popSoundToDie);
    }
}
