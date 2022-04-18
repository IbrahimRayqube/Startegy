using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DareCube : MonoBehaviour
{
    private Material blockMaterial;
    public bool isCurrentAvatar;
    public Vector3 moveDirection;
    public Vector3 wordPosition;
    public bool canMove = true;
    public bool createLetter = false;
    // Start is called before the first frame update
    void Start()
    {
        wordPosition = transform.position;
        transform.position = new Vector3(0, 0, transform.position.z);
        DareSceneHandler.Instance.allCubes.Add(this);
    }

    private void OnEnable()
    {
        blockMaterial = GetComponent<Renderer>().material;
        blockMaterial.color = DareSceneHandler.Instance.cubeColor[Random.Range(0, DareSceneHandler.Instance.cubeColor.Length)];
        if (!isCurrentAvatar)
        {
            moveDirection = new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), transform.position.z);
        }
        else
        {
            wordPosition = transform.position;
            transform.position = new Vector3(0f, 1, -6.5f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!isCurrentAvatar && canMove)
        {
            transform.Translate(new Vector3(moveDirection.x, moveDirection.y, 0) * Time.deltaTime * (0.1f * (transform.position.z / 3)));
        }
        else if(isCurrentAvatar && canMove)
        {
            transform.localPosition = new Vector3(0f, 1, -6.5f);
        }
        if (createLetter)
        {
            transform.position = Vector3.Lerp(transform.position, wordPosition, Time.deltaTime * 2);
            //transform.Translate(new Vector3(wordPosition.x, wordPosition.y, 0) * Time.deltaTime * (0.1f * (transform.position.z / 3)));
        }
        if (Mathf.Abs(transform.position.x) >= 60)
        {
            transform.position = new Vector3(0, 0, transform.position.z);
        }
        if (Mathf.Abs(transform.position.y) >= 60)
        {
            transform.position = new Vector3(0, 0, transform.position.z);
        }

    }

    public void FormLetter()
    {
        canMove = false;
        createLetter = true;
        if (isCurrentAvatar)
        {
            this.gameObject.SetActive(false);
        }
    }
}
