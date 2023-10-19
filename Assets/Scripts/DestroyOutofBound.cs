using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class DestroyOutofBound : MonoBehaviour
{
    private float rangeY = -5.0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < rangeY)
        {
            Destroy(gameObject);
        }
    }
}
