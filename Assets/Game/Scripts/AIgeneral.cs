using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AIgeneral : MonoBehaviour
{
    public TMP_InputField inputField; // 連接到 UI 的 Input Field

    // 這個方法將被按鈕的 OnClick 事件調用
    public void getUserContent()
    {
        string content = inputField.text; // 獲取用戶輸入
        int index = content.LastIndexOf("。");
        int type = 0;
        if (index == -1)
        {
            Debug.Log("沒有句號");
        }
        switch (content.Substring(index + 1).Trim())
        {
            case "是非題":
                type = 0;
                break;
            case "選擇是非題":
                type = 1;
                break;
            case "選擇題":
                type = 2; 
                break;
            case "多選題":
                type = 3;
                break;
            case "問答題":
                type = 4;
                break;
        }
        content = content.Substring(0,index+1);
        // 檢查是否為空或 null
        if (string.IsNullOrEmpty(content))
        {
            Debug.Log("輸入內容為空，請輸入內容");
            return; // 如果為空，退出函數
        }

        // 使用 StartCoroutine 來啟動協程
        StartCoroutine(UploadContent(content,type));

        Debug.Log("getUserContent Called");
        
    }

    // 協程：上傳內容至指定的 URL
    IEnumerator UploadContent(string content,int type)
    {
        string url = "http://127.0.0.1:8000/unitydata/upload_content/"; // 更改為你的上傳 API
        WWWForm form = new WWWForm(); // 創建新的表單
        
        string id = FirebaseManager.getEmail(); // 獲取當前用戶的 email

        // 檢查 id 是否為 null
        if (string.IsNullOrEmpty(id))
        {
            Debug.LogError("用戶 ID 為空，無法上傳內容。");
            yield break; // 如果 id 為空，退出協程
        }

        form.AddField("userid", id); // 添加用戶 ID 到表單
        form.AddField("content", content); // 添加內容到表單
        form.AddField("questiontype", type);
        Debug.Log($"上傳的內容: {content}"); // 日誌輸出上傳內容

        using (UnityWebRequest www = UnityWebRequest.Post(url, form)) // 使用 POST 請求上傳
        {
            // www.timeout = 10; // 可選：設定 10 秒超時
            yield return www.SendWebRequest(); // 發送請求並等待回應

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                // 請求錯誤，輸出錯誤信息
                Debug.LogError($"上傳錯誤: {www.error}\n回應: {www.downloadHandler.text}");
            }
            else
            {
                // 上傳成功，輸出回應信息
                Debug.Log($"上傳完成！回應: {www.downloadHandler.text}");
                SceneSystem.changeScene(SceneType.SCENE_AIQUESTION);
            }
        }
    }
}
