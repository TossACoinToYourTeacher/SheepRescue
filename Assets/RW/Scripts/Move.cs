using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 position = new Vector3(0, 10, 0);
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
            transform.Translate(position * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(position * Time.deltaTime, Space.Self);
        }
    }
}
