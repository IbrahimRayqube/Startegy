using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidesSlider : MonoBehaviour
{
    public Vector3 screenVisiblePosition;
    public Vector3 DisappearingFromScreenPosition;
    private Vector3 destination;
    bool isMoving = false;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * 2);
            if (Vector3.Distance(transform.position, destination) < 0.1f)
            {
                isMoving = false;
            }
        }


    }

    public void showOnScreen()
    {
        destination = screenVisiblePosition;
        isMoving = true;
    }

    public void removeFromScreen()
    {
        destination = DisappearingFromScreenPosition;
        isMoving = true;
    }
}
