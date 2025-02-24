using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class School_Dataset_Keelong : MonoBehaviour
{
    public Text uri_text;
    public void HandleInputData(int val)
    {
        if (val == 1)
        {
            uri_text.text = "https://script.google.com/macros/s/AKfycbwim-hfx2wbm-2bgINdx_HGlK4X5aEJ9Q5fYdSQyr_NP41fHWtZQXBHgfrOUPqRAKXh/exec";
        }
    }
}
