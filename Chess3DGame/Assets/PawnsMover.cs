using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnsMover : MonoBehaviour
{
    public void MovePawnTo(float x, float z)
    {
        transform.position = new Vector3(x,transform.position.y,z);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
