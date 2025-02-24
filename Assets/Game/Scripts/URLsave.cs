using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static FirebaseManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

public class URLsave : MonoBehaviour
{
    // Start is called before the first frame update
    public static string url;
    public TMP_InputField inputField;


    //Save the input's text to the url
    public void SaveURL()
    {
        url = inputField.text;
        if (inputField == null)
        {
            Debug.LogError("inputField is not assigned.");
            return;
        }
        else
        {
            Debug.Log(url);
        }

    }

}
