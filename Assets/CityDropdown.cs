using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CityDropdown : MonoBehaviour
{
    public GameObject Keelong;
    public GameObject Yilan;
    public GameObject Others;
    // Start is called before the first frame update
    public void HandleInputData(int val)
    {
        if (val == 1)
        {
            Keelong.SetActive(true);
            Yilan.SetActive(false);
            Others.SetActive(false);
        }
        if (val == 2)
        {
            Keelong.SetActive(false);
            Yilan.SetActive(true);
            Others.SetActive(false);
        }
        if (val == 3)
        {
            Keelong.SetActive(false);
            Yilan.SetActive(false);
            Others.SetActive(true);
        }
    }
}
