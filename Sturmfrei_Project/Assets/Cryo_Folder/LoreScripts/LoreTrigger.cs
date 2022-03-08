using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreTrigger : MonoBehaviour
{

    public Lore lore;
    public bool Readable =false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Readable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Readable = false;
        }
    }


    public void TriggerDialogue()
    {
 

        
            FindObjectOfType<LoreManager>().StartLore(lore);
        
    }

    private void Update()
    {
        if (Readable == true && Input.GetKeyDown(KeyCode.Tab) )
        {
            TriggerDialogue();
        }
    }
}
