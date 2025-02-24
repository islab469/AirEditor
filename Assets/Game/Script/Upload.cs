using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleFileBrowser;
using Firebase;
using Firebase.Extensions;
using Firebase.Storage;
using UnityEngine.SceneManagement;

public class Upload : MonoBehaviour
{
    RawImage rawImage;
    FirebaseStorage storage;
    StorageReference storageReference;

    void Start()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"));
        FileBrowser.SetDefaultFilter(".jpg");
        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://air-director.appspot.com/");
    }

    public void OnClick()
    {
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, null, null, "Load Files", "Load");

        if (FileBrowser.Success)
        {
            string selectedFilePath = FileBrowser.Result[0];
            string selectedFileName = Path.GetFileName(selectedFilePath);
            PlayerPrefs.SetString("UploadedFileName", selectedFileName);
            PlayerPrefs.Save();

            // Use the selected file name to dynamically set the storage path
            StorageReference uploadRef = storageReference.Child("Desktops/" + selectedFileName);

            byte[] bytes = FileBrowserHelpers.ReadBytesFromFile(selectedFilePath);

            // Upload the file to Firebase storage
            uploadRef.PutBytesAsync(bytes).ContinueWithOnMainThread((task) =>
            {
                if (task.IsFaulted || task.IsCanceled)
                {
                    Debug.Log(task.Exception.ToString());
                }
                else
                {
                    Debug.Log("File uploaded successfully");
                    Debug.Log(uploadRef);
                    SceneManager.LoadScene("user");
                }
            });
        }
    }
}
