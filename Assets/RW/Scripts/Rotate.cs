using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotation = new Vector3(300, 50, 0);
    public bool SpaceWorld = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpaceWorld)
        {
            transform.Rotate(rotation * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Rotate(rotation * Time.deltaTime, Space.Self);
        }
    }
}
