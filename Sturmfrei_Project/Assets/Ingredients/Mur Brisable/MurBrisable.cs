using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurBrisable : MonoBehaviour
{
    public bool isDashing;
    public GameObject MurBrise;
    public GameObject MurSolide;
    public AudioSource bedingbedang;
    public PlayerCollisionSphere playMov;

    private void Start()
    {
        bedingbedang = this.gameObject.GetComponent<AudioSource>();
        MurSolide = this.gameObject.transform.GetChild(0).gameObject;
        MurBrise = this.gameObject.transform.GetChild(1).gameObject;
        MurBrise.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        playMov = other.gameObject.GetComponent<PlayerCollisionSphere>();
        if (other.gameObject.tag == "Player" && other != null)
        {
            isDashing = playMov.PlayerMov.isDashing;

            if (isDashing == true)
            {
                StartCoroutine(Brise());
            }
        }
    }

    //Not sure we need to put this in a enumerator, talk to Oli
    IEnumerator Brise()
    {
        MurSolide.SetActive(false);
        MurBrise.SetActive(true);
        bedingbedang.Play();
        yield return new WaitForSeconds(1.3f);
    }

}
