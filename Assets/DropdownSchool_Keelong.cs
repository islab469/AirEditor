using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownSchool_Keelong : MonoBehaviour
{
  public Text output;
    // Start is called before the first frame update
     public void HandleInputData(int val)
    {
        if (val == 1)
        {
            output.text = "仁愛國小";
        }

       
    }
}
