using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreTrigger : MonoBehaviour
{

    public Lore lore;
    public bool Readable =false;
    private LoreManager loreManager;
    private bool pressedDialogInput;

    private void Start()
    {
        loreManager = FindObjectOfType<LoreManager>();
        pressedDialogInput = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Readable = true;
            Debug.Log("Press E on keyboard or B on controller");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Readable = false;
            loreManager.EndLore();
            pressedDialogInput = false;
        }
    }


    private void Update()
    {
        if (Readable && Input.GetButtonDown("Grapple") && !pressedDialogInput)
        {
            loreManager.StartLore(lore);
            pressedDialogInput = true;
        }
        else if (Readable && Input.GetButtonDown("Grapple") && pressedDialogInput)
        {
            loreManager.EndLore();
            pressedDialogInput = false;
        }
    }
}
