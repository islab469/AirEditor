using System.Collections;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Presentation;
using UnityEngine;
using static ImageManager;

public class AnimalSelect : MonoBehaviour
{

    public void SetSelectedAnimalById(int animalID)
    {
        SetSelectedAnimal((Animal)animalID);
    }

    private void SetSelectedAnimal(Animal animal)
    {
        PlayerPrefs.SetInt("SelectedModel", (int)animal); // 儲存選擇的動物到 PlayerPrefs
        PlayerPrefs.Save(); // 確保儲存成功

        Debug.Log($"【已選擇動物】{animal}");
    }
}
