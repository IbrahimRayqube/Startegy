using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSlidesHandler : MonoBehaviour
{
    public SlidesSlider[] allSlides;
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
        StartCoroutine(startProgramDemo());
    }

    public IEnumerator startProgramDemo()
    {
        allSlides[0].showOnScreen();
        yield return new WaitForSeconds(4);
        allSlides[0].removeFromScreen();
        yield return new WaitForSeconds(2);
        for (int i = 1; i < allSlides.Length; i++)
        {
            allSlides[i].showOnScreen();
            //for (int j = 0; j < slideText[i - 1].allMessages.Length; j++)
            //{
            //    message.text = slideText[i - 1].allMessages[j];
            //    message.GetComponent<textFadeInNOut>().fadeIn();
            //    yield return new WaitForSeconds(3);
            //    message.GetComponent<textFadeInNOut>().fadeOut();
            //    yield return new WaitForSeconds(2);
            //}
            yield return new WaitForSeconds(8);
            allSlides[i].removeFromScreen();
            yield return new WaitForSeconds(1);
        }
    }
}
