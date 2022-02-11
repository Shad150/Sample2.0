using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSTBehabiour : MonoBehaviour
{
    private static OSTBehabiour instance = null;
    public static OSTBehabiour Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
