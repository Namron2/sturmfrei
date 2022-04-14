using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreTrigger : MonoBehaviour
{

    public Lore lore;
    public bool Readable =false;
    private LoreManager loreManager;
    public  bool pressedDialogInput;
    private GameObject playerObject;

    //private GameObject controllerY;
    //private GameObject keyboardF;

    bool inputLore;
    private void Start()
    {
        loreManager = FindObjectOfType<LoreManager>();
        pressedDialogInput = false;
        //controllerY = this.transform.Find("YController").gameObject;
        //keyboardF = this.transform.Find("FKeyboard").gameObject;
        playerObject = GameObject.FindGameObjectWithTag("Player");

        //controllerY.SetActive(false);
       // keyboardF.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Readable = true;
            loreManager.StartLore(lore);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //RemoveControleDeCheckPoint();
            Readable = false;
            loreManager.EndLore();
            pressedDialogInput = false;
        }
    }


    private void Update()
    {/*
        inputLore = Input.GetButtonDown("ReadLore");
        if (Readable)
        {
            //PlayerMovement player = playerObject.GetComponent<PlayerMovement>();
            //ControleDeCheckPoint(player);
        }

        if (Readable && inputLore && !pressedDialogInput)
        {
            loreManager.StartLore(lore);
            pressedDialogInput = true;

        }
        else if (Readable && inputLore && pressedDialogInput)
        {
            loreManager.EndLore();
            pressedDialogInput = false;
        }*/
    }
    /*
    private void ControleDeCheckPoint(PlayerMovement player)
    {
        if (controllerY != null && keyboardF != null)
        {
            controllerY.SetActive(true);
            keyboardF.SetActive(true);

            controllerY.transform.LookAt(player.Cam);
            keyboardF.transform.LookAt(player.Cam);
        }
    }

    private void RemoveControleDeCheckPoint()
    {
        if (controllerY != null && keyboardF != null)
        {
            controllerY.SetActive(false);
            keyboardF.SetActive(false);
        }
    }
    */
}
