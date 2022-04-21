using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject TutorialScreen;
    public GameObject overlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableTutorialScreen()
    {
        TutorialScreen.SetActive(true);
    }

    public void showOverlay()
    {
        overlay.GetComponent<ImageFadeInNOut>().fadeIn();
    }
}
