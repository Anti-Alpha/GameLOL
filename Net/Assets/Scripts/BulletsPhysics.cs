using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float f = 0;
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, f));
        f += 4;
    }
}
