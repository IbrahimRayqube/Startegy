using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionIcons : MonoBehaviour
{
    public float speed;
    public Vector3 initPos;
    public VisionHandler visionHandler;
    // Start is called before the first frame update
    void Start()
    {
        visionHandler = FindObjectOfType<VisionHandler>();
    }

    private void OnEnable()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.localPosition.x > 2300 && visionHandler.isHoveringIconsActive)
        {
            transform.position = initPos;
        }
    }
}
