using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wholemusic : MonoBehaviour
{
    public static wholemusic Instance;
    private void Awake()
    {
        if (Instance != null && Instance!= this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
}
