using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingAstrale : MonoBehaviour
{
    public Material astral;
    public Color coulAstral;
    public float alpha = 1;
    public GameObject pono;
    public string state;
    PlayerMovement playerMovement;
    public bool isFlying;
    public Color coulIni;
    public Color coulPollution;
    public bool dansPollution;
    public float timerPollution;

    private void Awake()
    {
        pono = this.gameObject.transform.root.gameObject;
        playerMovement = pono.GetComponent<PlayerMovement>();
        astral = this.gameObject.GetComponent<Renderer>().material;
    }


    private void Update()
    {
        astral.color = coulAstral;
        coulAstral.a = alpha;
        state = playerMovement.States.ToString();
        dansPollution = playerMovement.isTainted;

        if (state == "Flying" /*&& isFlying == true*/)
        {
            alpha = 1;
            //StartCoroutine(FadeTo(1.0f, 1.0f));
        }
        if (state != "Flying" /*&& isFlying == false*/)
        {
            alpha = 0;
            //StartCoroutine(FadeTo(0.0f, 0.2f));
        }

        if (dansPollution == true)
        {
            StartCoroutine(PollutionSortie());
        }
    }

    /*IEnumerator FadeTo(float aValue, float aTime)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            alpha = Mathf.Lerp(alpha, aValue, aTime);
            isFlying = !isFlying;
            yield return null;
        }
            
    }*/


    IEnumerator PollutionSortie()
    {
        timerPollution = playerMovement.TaintedTimer;
        astral.SetColor("_EmissionColor", coulPollution * 2f);

        if (dansPollution == false)
        {
            yield return new WaitForSeconds(timerPollution);
            astral.SetColor("_EmissionColor", coulIni * 2f);
        }
    }
}
