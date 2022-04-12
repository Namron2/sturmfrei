using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Test_Cinemachine : MonoBehaviour
{
    public CinemachineBrain cineBrain;
    public CinemachineVirtualCamera virtCam;
    // Start is called before the first frame update
    void Start()
    {
        cineBrain = this.GetComponent<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float progressLook;
    private float elapedTimeLook;
    IEnumerator LookAround()
    {
        while (progressLook < 1)
        {
            elapedTimeLook += Time.unscaledDeltaTime;
            progressLook = elapedTimeLook / 6; // number of second to look at

            yield return null;
        }
        // call fade to black function
    }
}
