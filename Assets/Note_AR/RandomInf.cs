using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomInf : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image image;

    // Start is called before the first frame update
    void Start()
    {
        float f = Random.Range(0, sprites.Length);
        image.sprite = sprites[(int)f];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
