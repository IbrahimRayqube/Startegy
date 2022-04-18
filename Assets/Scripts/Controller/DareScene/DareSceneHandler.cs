using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DareSceneHandler : Singleton<DareSceneHandler>
{
    public DareMenuHandler menuHandler;
    public List<DareCube> allCubes;
    public Color[] cubeColor;
    // Start is called before the first frame update
    void Start()
    {
        //menuHandler.screenFade.GetComponent<ImageFadeInNOut>().fadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (DareCube c in allCubes)
            {
                c.FormLetter();
            }
            menuHandler.showDareMessage();
        }
    }

    public void startDareIntro()
    {
        
    }
}
