using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;
    public Vector3 velocity = Vector3.zero;
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 playerPos = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref velocity, smooth); 

    }

}
