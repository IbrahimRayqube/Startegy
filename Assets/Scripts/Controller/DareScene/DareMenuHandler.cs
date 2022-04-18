using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DareMenuHandler : Singleton<DareMenuHandler>
{
    public GameObject screenFade;
    public GameObject dareMessage;
    public GameObject dMsg, aMsg, rMsg, eMsg;
    public bool stopShowingLetterMsgs = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            stopShowingLetterMsgs = true;
        }
    }

    public void showDareMessage()
    {
        dareMessage.SetActive(true);
        dareMessage.GetComponentInChildren<textFadeInNOut>().fadeIn();
        StartCoroutine(showLetterMessage());
    }

    IEnumerator showLetterMessage()
    {
        yield return new WaitForSeconds(4);
        while (!stopShowingLetterMsgs)
        {
            dMsg.GetComponentInChildren<textFadeInNOut>().fadeIn();
            yield return new WaitForSeconds(3f);
            dMsg.GetComponentInChildren<textFadeInNOut>().fadeOut();
            aMsg.GetComponentInChildren<textFadeInNOut>().fadeIn();
            yield return new WaitForSeconds(3);
            aMsg.GetComponentInChildren<textFadeInNOut>().fadeOut();
            rMsg.GetComponentInChildren<textFadeInNOut>().fadeIn();
            yield return new WaitForSeconds(3);
            rMsg.GetComponentInChildren<textFadeInNOut>().fadeOut();
            eMsg.GetComponentInChildren<textFadeInNOut>().fadeIn();
            yield return new WaitForSeconds(3);
            eMsg.GetComponentInChildren<textFadeInNOut>().fadeOut();
        }
    }
}
