using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeIncrease : MonoBehaviour
{
    public GameObject Circus;
    public bool Death = false;
    void Update()
    {
        if (Death)
        {
            transform.localScale += Vector3.one * Time.deltaTime * 50;
            Invoke("DestroyCircus", 1);
        }
    }

    void DestroyCircus()
    {
        Destroy(Circus);
    }
}
