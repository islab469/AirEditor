using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCam : MonoBehaviour
{
    public float SensX;
    public float SensY;
    public Transform orientation;
    float Xrotation;
    float Yrotation;
    private void Update() {
        float mouseX=Input.GetAxisRaw("Mouse X")*Time.deltaTime*SensX;   
        float mouseY=Input.GetAxisRaw("Mouse Y")*Time.deltaTime*SensY;  
        Yrotation+=mouseX;
        Xrotation-=mouseY;
        Xrotation=Mathf.Clamp(Xrotation,-90f,90f);
        transform.rotation=Quaternion.Euler(Xrotation,Yrotation,0);
        orientation.rotation=Quaternion.Euler(0,Yrotation,0);
    }
}
