using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Extensions;
using Firebase.Storage;
using UnityEngine.Networking;

public class ImageLoader : MonoBehaviour
{
    RawImage rawImage;
    FirebaseStorage storage;
    StorageReference storageReference;

    IEnumerator LoadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rawImage = gameObject.GetComponent<RawImage>();
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://air-director.appspot.com/");

        // 從 PlayerPrefs 中獲取上傳的文件名
        string uploadedFileName = PlayerPrefs.GetString("UploadedFileName");
        Debug.Log(uploadedFileName);

        // 構建 Firebase Storage 中的參考
        StorageReference imageRef = storageReference.Child("Desktops/" + uploadedFileName);

        // 獲取圖片的下載 URL
        imageRef.GetDownloadUrlAsync().ContinueWithOnMainThread(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                string imageUrl = task.Result.ToString();
                StartCoroutine(LoadImage(imageUrl));
            }
            else
            {
                Debug.Log(task.Exception);
            }
        });
    }
}
