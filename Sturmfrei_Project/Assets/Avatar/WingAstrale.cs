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
    public GameObject particuleCloud;
    public bool toxicCheck;

    private void Awake()
    {
        particuleCloud = this.gameObject.transform.GetChild(0).gameObject;
        pono = this.gameObject.transform.root.gameObject;
        playerMovement = pono.GetComponent<PlayerMovement>();
        astral = this.gameObject.GetComponent<Renderer>().material;
    }

    private void Update()
    {
        astral.color = coulAstral;
        coulAstral.a = alpha;

        if (playerMovement.States == PlayerMovement.WorldState.Flying /*&& isFlying == true*/)
        {
            alpha = 1;
            //StartCoroutine(FadeTo(1.0f, 1.0f));
        }
        if (playerMovement.States != PlayerMovement.WorldState.Flying /*&& isFlying == false*/)
        {
            alpha = 0;
            //StartCoroutine(FadeTo(0.0f, 0.2f));
        }

        if (playerMovement.isTainted && toxicCheck == false)
        {
            toxicCheck = true;
            astral.SetColor("_EmissionColor", Color.Lerp(coulIni, coulPollution, 0.8f) * 2f);
            particuleCloud.GetComponent<ParticleSystem>().Play();
        }
        if (!playerMovement.isTainted && toxicCheck == true)
        {
            toxicCheck = false;
            astral.SetColor("_EmissionColor", Color.Lerp(coulPollution, coulIni, 0.5f) * 2f);
            particuleCloud.GetComponent<ParticleSystem>().Pause();
            StartCoroutine(ColorSwitch());
        }
    }

    IEnumerator ColorSwitch()
    {
        yield return new WaitForSeconds(2.5f);
        astral.SetColor("_EmissionColor", coulIni * 2f);
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

    /*
    IEnumerator PollutionSortie()
    {
        timerPollution = playerMovement.TaintedTimer;
        astral.SetColor("_EmissionColor", coulPollution * 2f);

        if (dansPollution == false)
        {
            yield return new WaitForSeconds(timerPollution);
            astral.SetColor("_EmissionColor", coulIni * 2f);
        }
    }*/
}
