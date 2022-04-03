using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSturmfrei : MonoBehaviour
{
    public Animator sturmfreiAnim;
    public GameObject sturmfrei;
    public GameObject pono;
    public Transform poncho1;
    public Transform poncho2;
    private bool collecte = false;

    private void Awake()
    {
        sturmfrei = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        sturmfreiAnim = sturmfrei.GetComponent<Animator>();
        pono = GameObject.Find("PonoPrefab#03");
        //poncho1 = gameObject.transform.Find("ponchoMain");
        //poncho2 = gameObject.transform.Find("poncho2");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && collecte == false)
        {

            StartCoroutine(Collecte());
        }
    }

    IEnumerator Collecte()
    {
        this.gameObject.GetComponent<AudioSource>().Play();

        collecte = true;
        yield return new WaitForSeconds(3.5f);
        sturmfreiAnim.SetBool("Collecte", true);
        yield return new WaitForSeconds(1.9f);
        sturmfrei.SetActive(false);
        yield return new WaitForSeconds(1.2f);
        poncho1.GetComponent<SkinnedMeshRenderer>().enabled = true;
        poncho2.GetComponent<SkinnedMeshRenderer>().enabled = true;

    }
}
