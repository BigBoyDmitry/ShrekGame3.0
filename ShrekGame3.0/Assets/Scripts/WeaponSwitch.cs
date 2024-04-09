using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject knife;
    public GameObject handR;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        { 
            if(handR.activeInHierarchy == true)
            {
                handR.SetActive(false);
                knife.SetActive(true);
            }
            else if (knife.activeInHierarchy == true)
            {
                knife.SetActive(false);
                handR.SetActive(true);
            }
        }
    }
}
