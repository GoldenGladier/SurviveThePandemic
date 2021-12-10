using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QR : MonoBehaviour
{
    public GameObject canvas;
    void Start()
    {
        //canvas.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(true);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            canvas.SetActive(false);
        }
    }
}
