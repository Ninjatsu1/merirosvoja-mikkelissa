using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 GetPosition = this.GetComponent<Transform>().position;
        GetPosition.x = this.player.GetComponent<Transform>().position.x;
        GetPosition.y = this.player.GetComponent<Transform>().position.y;
        this.GetComponent<Transform>().position = GetPosition;
    }
}
