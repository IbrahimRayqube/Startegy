using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStrategyTopicBlock : MonoBehaviour
{

    // Start is called before the first frame update
    public Color[] allColors;
    private Material blockMaterial;
    bool isMovingAwayFromCamera;
    public float moveSpeed = 1;
    Vector3 moveDirection;
    private void Awake()
    {
        blockMaterial = GetComponent<Renderer>().material;
        blockMaterial.color = allColors[Random.Range(0, allColors.Length)];
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (isMovingAwayFromCamera)
        {
            transform.Translate(new Vector3(moveDirection.x, moveDirection.y, 0) * Time.deltaTime * moveSpeed);
        }
    }

    public void resetMaterial()
    {
        blockMaterial = GetComponent<Renderer>().material;
        blockMaterial.color = allColors[Random.Range(0, allColors.Length)];
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CubeEnd")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 32);
        }
    }

    public void moveAwayFromCamera()
    {
        moveDirection = transform.position - Camera.main.transform.position;
        isMovingAwayFromCamera = true;
    }
}
