using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VisionHandler : MonoBehaviour
{
    public TMP_Text message;
    public SlidesSlider[] allSlides;
    public string[] allMessages;
    public GameObject hoveringIcons;
    public bool isHoveringIconsActive = false;
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
        startSlides();
    }

    public void startSlides()
    {
        StartCoroutine(startVisionSlides());
    }

    IEnumerator startVisionSlides()
    {
        allSlides[0].showOnScreen();
        yield return new WaitForSeconds(4);
        allSlides[0].removeFromScreen();
        yield return new WaitForSeconds(2);
        for (int i = 1; i < allSlides.Length; i++)
        {
            allSlides[i].showOnScreen();
            if (!isHoveringIconsActive)
            {
                isHoveringIconsActive = true;
                hoveringIcons.SetActive(true);

                for (int j = 0; j < allMessages.Length; j++)
                {
                    message.text = allMessages[j];
                    message.GetComponent<textFadeInNOut>().fadeIn();
                    yield return new WaitForSeconds(3);
                    message.GetComponent<textFadeInNOut>().fadeOut();
                    yield return new WaitForSeconds(2);
                }
            }
            else
            {
                isHoveringIconsActive = false;
            }
            yield return new WaitForSeconds(8);
            allSlides[i].removeFromScreen();
            yield return new WaitForSeconds(1);
        }
    }
}
