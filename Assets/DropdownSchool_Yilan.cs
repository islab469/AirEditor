using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownSchool_Yilan : MonoBehaviour
{
    public Text output;
    // Start is called before the first frame update
    public void HandleInputData(int val)
    {
        if (val == 1)
        {
            output.text = "中道國小";
        }
        if (val == 2)
        {
            output.text = "七賢國小";
        }
        if (val == 3)
        {
            output.text = "南屏國小";
        }
        if (val == 4)
        {
            output.text = "光復國小";
        }
    }
}
