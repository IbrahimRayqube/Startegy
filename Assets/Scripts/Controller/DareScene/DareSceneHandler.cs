using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DareSceneHandler : Singleton<DareSceneHandler>
{
    public DareMenuHandler menuHandler;
    public List<DareCube> allCubes;
    public Color[] cubeColor;
    public GameObject cubeHolder;
    public GameObject dInsight, aInsight, rInsight, eInsight ;
    public GameObject[] dInsightHands, AInsightHands;
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

    public void slideCubeHolder()
    {
        foreach (DareCube c in allCubes)
        {
            c.createLetter = false;
        }
        cubeHolder.GetComponent<TweenPosition>().enabled = true;
        dInsight.GetComponent<TweenPosition>().enabled = true;
    }

    public void slideDInsight()
    {
        dInsight.SetActive(false);
        Destroy(dInsight.gameObject.GetComponent<TweenPosition>());
        dInsight.gameObject.AddComponent<TweenPosition>();
        TweenPosition tweener = dInsight.GetComponent<TweenPosition>();
        tweener.from = dInsight.transform.position;
        tweener.to = new Vector3(-30, 0, 0);
        tweener.style = UITweener.Style.Once;
        //tweener.delay = Random.Range(0, 1.5f);
        tweener.enabled = false;
        transform.parent = null;
        tweener.PlayForward();
        aInsight.GetComponent<TweenPosition>().enabled = true;
    }

    public void showDInsightHands()
    {
        foreach (GameObject temp in dInsightHands)
        {
            temp.SetActive(true);
            temp.GetComponent<TweenPosition>().enabled = true;
            temp.GetComponent<TweenPosition>().PlayForward();
        }
    }

    public void showAInsightHands()
    {
        foreach (GameObject temp in AInsightHands)
        {
            temp.SetActive(true);
            temp.GetComponent<TweenPosition>().enabled = true;
            temp.GetComponent<TweenPosition>().PlayForward();
        }
    }
}
