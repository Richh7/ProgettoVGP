using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChild : MonoBehaviour
{
    public bool hasChild = true;

    // Start is called before the first frame update
    void Start()
    {
        hasChild = true;
    }

    public void SetChild(bool val)
    {
        hasChild = val;
    }
}
