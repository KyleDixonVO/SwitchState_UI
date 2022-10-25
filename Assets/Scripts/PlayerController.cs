using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.forward * 5);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.back * 5);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.left * 5);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * 5);
        }
    }
}
