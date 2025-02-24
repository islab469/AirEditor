using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownSchool_Others : MonoBehaviour
{
    public Text output;
    // Start is called before the first frame update
     public void HandleInputData(int val)
    {
        if (val == 1)
        {
            output.text = "營隊";
        }
        if (val == 2)
        {
            output.text = "其他縣市";
        }
       
    }
}
