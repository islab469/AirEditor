using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;


public class Spin : MonoBehaviour
{
    [SerializeField] private Button SpinButton;
    [SerializeField] private Text SpinButtonText;
    [SerializeField] private PickerWheel pickerWheel;

    // Start is called before the first frame update
    private void Start()
    {
        SpinButton.onClick.AddListener(() =>{
            SpinButton.interactable = false;
            SpinButtonText.text = "轉動中~";

            pickerWheel.OnSpinStart (() => Debug.Log("Spin started.."));
              
            pickerWheel.OnSpinEnd (wheelPiece => {
                Debug.Log("Spin end: Label:"+wheelPiece.Label+" ,Amount:"+wheelPiece.Amount);
                SpinButton.interactable = true;
                SpinButtonText.text = "轉動";

            });
            pickerWheel.Spin();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
