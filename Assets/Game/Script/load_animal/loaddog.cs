using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Firebase;
using Firebase.Extensions;
using Firebase.Storage;
public class loaddog : MonoBehaviour
{
    RawImage rawImage;
    FirebaseStorage storage;
    StorageReference storageReference;
    IEnumerator LoadImage(string MediaUrl){
        UnityWebRequest request=UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if(request.isNetworkError||request.isHttpError){
            Debug.Log(request.error);
        }
        else{
            rawImage.texture=((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rawImage=gameObject.GetComponent<RawImage>();
        storage=FirebaseStorage.DefaultInstance;
        storageReference=storage.GetReferenceFromUrl("gs://air-director.appspot.com/");
        StorageReference image=storageReference.Child("狗.jpg");
        image.GetDownloadUrlAsync().ContinueWithOnMainThread(task=>
        {
            if(!task.IsFaulted&&!task.IsCanceled){
                StartCoroutine(LoadImage(Convert.ToString(task.Result)));
            }
            else{
                Debug.Log(task.Exception);
            }
        });
    }
}
