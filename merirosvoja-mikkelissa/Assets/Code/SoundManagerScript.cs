using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    
    public static AudioClip SwordSwingSound;
    public static AudioClip JumpatiJompati;
    public static AudioClip HurtMyFeelings;
    public static AudioClip GiveMeMyMoney;

    public static AudioClip Bottletus;

    
    static AudioSource audiSource;
    void Start()
    {
        
        SwordSwingSound = Resources.Load<AudioClip> ("SwingSwong");
        JumpatiJompati = Resources.Load<AudioClip>("PussyJump");
        HurtMyFeelings = Resources.Load<AudioClip>("Hurt");
        GiveMeMyMoney = Resources.Load<AudioClip>("Money");
        Bottletus = Resources.Load<AudioClip>("Bottle");

        audiSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
     public static void PlaySound (string clip){

        switch(clip){
        case "SwingSwong":
        audiSource.PlayOneShot(SwordSwingSound);
        break;
        case "PussyJump":
        audiSource.PlayOneShot(JumpatiJompati);
        break;
        case "Hurt":
        audiSource.PlayOneShot(HurtMyFeelings);
        break;
        case "Money":
        audiSource.PlayOneShot(GiveMeMyMoney);
        break;
        case "Bottle":
        audiSource.PlayOneShot(Bottletus);
        break;
        }
            
    }
}
