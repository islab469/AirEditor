using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Threading.Tasks;
using System;


public enum Animal
{
    ANIMAL_CAT,
    ANIMAL_CHICKEN,
    ANIMAL_DEER,
    ANIMAL_DOG,
    ANIMAL_ELEPHANT,
    ANIMAL_HORSE,
    LENGTH
}
class ImageManager : MonoBehaviour
{
    private Sprite currentSprite; // 保存當前使用的圖片


    [SerializeField]
    private Image modelImage; // 空的 Image 組件，用於顯示選擇的圖片


    private void Start()
    {

        UpdateModelImage();
    }


    private void UpdateModelImage()
    {
        Animal selectedModel = (Animal)PlayerPrefs.GetInt("SelectedModel", 0); // 默認為狗模型
        Debug.Log($"【從 PlayerPrefs 獲取選擇的動物】{selectedModel}");
        Sprite sprite = AnimalUtil.GetAnimalSpriteByAnimalID((int)selectedModel);
        modelImage.sprite = sprite;
        currentSprite = sprite;
    }

    public void UploadImage() // 用於處理上傳圖片的按鈕
    {
        // 這裡應該包含用戶上傳圖片的邏輯，並將路徑保存到 PlayerPrefs
        string path = "你的圖片路徑"; // 根據上傳邏輯獲取實際圖片路徑
        PlayerPrefs.SetString("UploadedImagePath", path);
        PlayerPrefs.Save(); // 確保儲存成功

        Debug.Log($"【上傳圖片】路徑：{path}");

        UpdateModelImage(); // 更新顯示圖片
    }

    public Sprite GetCurrentSprite()
    {
        if (currentSprite == null)
        {
            Debug.LogError("【GetCurrentSprite】當前沒有可用的圖片！");
        }
        return currentSprite;
    }
}

