using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject welcomeText;
    public GameObject animatedAvatar;
    public GameObject dareText;
    public GameObject inspireText;
    public GameObject careText;
    public GameObject youSTCText;
    bool userInteracted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            userInteracted = true;
        }
    }

    private void OnEnable()
    {
        startTutorial();
    }

    public void startTutorial()
    {
        StartCoroutine(completeTutorialProcess());
    }

    IEnumerator completeTutorialProcess()
    {
        GetComponent<ImageFadeInNOut>().fadeIn();
        yield return new WaitForSeconds(2);
        SceneController.Instance.picController.welcomeMsg.SetActive(false);
        welcomeText.gameObject.SetActive(true);
        welcomeText.GetComponent<textFadeInNOut>().fadeIn();
        //welcomeText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        animatedAvatar.SetActive(true);
        youSTCText.GetComponent<textFadeInNOut>().fadeIn();
        while (!userInteracted)
        {
            dareText.GetComponent<textFadeInNOut>().fadeIn();
            yield return new WaitForSeconds(2);
            dareText.GetComponent<textFadeInNOut>().fadeOut();
            yield return new WaitForSeconds(2);
            careText.GetComponent<textFadeInNOut>().fadeIn();
            yield return new WaitForSeconds(2);
            careText.GetComponent<textFadeInNOut>().fadeOut();
            yield return new WaitForSeconds(2);
            inspireText.GetComponent<textFadeInNOut>().fadeIn();
            yield return new WaitForSeconds(2);
            inspireText.GetComponent<textFadeInNOut>().fadeOut();
            yield return new WaitForSeconds(2);
        }
    }

    public void clearTextures()
    {

        RenderTexture rt = RenderTexture.active;
        GL.Clear(true, true, Color.clear);
        RenderTexture.active = rt;
    }
}
