using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public class Messages
{
    public string[] allMessages;
}

public class CSRProgramHandler : MonoBehaviour
{
    public Messages[] slideText;
    public SlidesSlider[] allSlides;
    int currentSlide = 0;
    public TMP_Text message;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        startExperience();
    }

    public void startExperience()
    {
        currentSlide = 0;
        StartCoroutine(startProgramDemo());
    }

    public IEnumerator startProgramDemo()
    {
        Debug.Log("Show slide 1");
        allSlides[0].showOnScreen();
        yield return new WaitForSeconds(4);
        Debug.Log("Remove slide 1");
        allSlides[0].removeFromScreen();
        yield return new WaitForSeconds(2);
        for (int i = 1; i < allSlides.Length; i++)
        {
            Debug.Log("Show slide "+i);
            allSlides[i].showOnScreen();
            for (int j = 0; j < slideText[i - 1].allMessages.Length; j++)
            {
                message.text = slideText[i - 1].allMessages[j];
                message.GetComponent<textFadeInNOut>().fadeIn();
                yield return new WaitForSeconds(3);
                message.GetComponent<textFadeInNOut>().fadeOut();
                yield return new WaitForSeconds(2);
            }
            Debug.Log("Remove slide "+i);
            allSlides[i].removeFromScreen();
            yield return new WaitForSeconds(1);
        }
        DareSceneHandler.Instance.Vision.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
