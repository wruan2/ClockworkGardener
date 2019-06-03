using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;

    private Vector3 targetPos;

    public float moveSpeed;
    
    void Start()
    {
        targetPos = transform.position - followTarget.transform.position;
        Screen.SetResolution(1280, 720, false);
    }
    // Update is called once per frame
    void Update()
    {
      targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
      transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);

    }
}
