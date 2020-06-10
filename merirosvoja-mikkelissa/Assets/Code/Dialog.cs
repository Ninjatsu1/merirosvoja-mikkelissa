using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
        public TextMeshProUGUI textDisplay;
        
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject panel;
    private int SentencesLength;
    private void Start()
    {

      
    }
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray() )
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }
    public void NextSentence()
    {
        SentencesLength = sentences.Length;
        Debug.Log(index);
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
       
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            panel.SetActive(false);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            panel.SetActive(true);
            StartCoroutine(Type());

        }
    }


}
