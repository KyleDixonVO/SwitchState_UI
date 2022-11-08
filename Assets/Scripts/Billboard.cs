using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera main;
    // Start is called before the first frame update
    void Start()
    {
        if (main == null)
        {
            main = GameObject.Find("Main Camera").GetComponent<Camera>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(main.transform.position, Vector3.up);
    }
}
