using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown : MonoBehaviour
{
    public Text output;
    // Start is called before the first frame update
    public void HandleInputData(int val)
    {
        if (val == 1) {
            output.text = "¨k";
        }
        if (val == 2) {
            output.text = "¤k"; 
        }
    }

}
