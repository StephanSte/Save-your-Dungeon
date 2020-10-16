using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//dazu da dass die Lebensanzeige auf den Spieler Zeigt wenn sie auf Gegnern platziert ist
public class Billboard : MonoBehaviour
{
    public Transform cam;
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
