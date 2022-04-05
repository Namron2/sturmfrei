using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public  class Loading_Scene:MonoBehaviour
{
    public static void Load_Scene (string nomDeScene)
    {
        SceneManager.LoadScene(nomDeScene);
    }
}
