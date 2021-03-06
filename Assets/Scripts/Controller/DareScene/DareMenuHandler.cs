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
    public GameObject dInsightMsg, aInsightMsg, rInsightMsg, eInsightMsg;
    public GameObject dInsightDetail, aInsightDetail, rInsightDetail, eInsightDetail;
    // Start is called before the first frame update
    void Start()
    {
        screenFade.GetComponent<ImageFadeInNOut>().fadeOut();
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
        dareMessage.GetComponentInChildren<textFadeInNOut>().fadeOut();
        DareSceneHandler.Instance.slideCubeHolder();
        yield return new WaitForSeconds(2);
        dInsightMsg.GetComponentInChildren<textFadeInNOut>().fadeIn();
        DareSceneHandler.Instance.showDInsightHands();
        dInsightDetail.GetComponentInChildren<textFadeInNOut>().fadeIn();
        yield return new WaitForSeconds(4);
        dInsightMsg.GetComponentInChildren<textFadeInNOut>().fadeOut();
        dInsightDetail.GetComponentInChildren<textFadeInNOut>().fadeOut();
        yield return new WaitForSeconds(2);
        DareSceneHandler.Instance.slideDInsight();
        aInsightMsg.GetComponentInChildren<textFadeInNOut>().fadeIn();
        DareSceneHandler.Instance.showAInsightHands();
        aInsightDetail.GetComponentInChildren<textFadeInNOut>().fadeIn();
        yield return new WaitForSeconds(4);
        aInsightMsg.GetComponentInChildren<textFadeInNOut>().fadeOut();
        aInsightDetail.GetComponentInChildren<textFadeInNOut>().fadeOut();
        yield return new WaitForSeconds(2);
        DareSceneHandler.Instance.slideAInsight();
        rInsightMsg.GetComponentInChildren<textFadeInNOut>().fadeIn();
        DareSceneHandler.Instance.showRInsightHands();
        rInsightDetail.GetComponentInChildren<textFadeInNOut>().fadeIn();
        yield return new WaitForSeconds(4);
        rInsightMsg.GetComponentInChildren<textFadeInNOut>().fadeOut();
        rInsightDetail.GetComponentInChildren<textFadeInNOut>().fadeOut();
        yield return new WaitForSeconds(2);
        DareSceneHandler.Instance.slideRInsight();
        eInsightMsg.GetComponentInChildren<textFadeInNOut>().fadeIn();
        DareSceneHandler.Instance.showEInsightHands();
        eInsightDetail.GetComponentInChildren<textFadeInNOut>().fadeIn();
        yield return new WaitForSeconds(4);
        eInsightMsg.GetComponentInChildren<textFadeInNOut>().fadeOut();
        eInsightDetail.GetComponentInChildren<textFadeInNOut>().fadeOut();
        yield return new WaitForSeconds(2);
        DareSceneHandler.Instance.slideEInsight();
        DareSceneHandler.Instance.Mission.SetActive(true);
    }
}
