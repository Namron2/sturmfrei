using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAmInTheWay : MonoBehaviour
{
    [SerializeField] public GameObject solidBody;
    [SerializeField] public GameObject transparentBody;
    // Start is called before the first frame update
    void Start()
    {
        ShowSolid();
    }

    public void ShowTransparent()
    {
        solidBody.SetActive(false);
        transparentBody.SetActive(true);
    }
    public void ShowSolid()
    {
        solidBody.SetActive(true);
        transparentBody.SetActive(false);
    }


}
