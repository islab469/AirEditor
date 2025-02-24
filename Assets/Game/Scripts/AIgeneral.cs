using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AIgeneral : MonoBehaviour
{
    public TMP_InputField inputField; // �s���� UI �� Input Field

    // �o�Ӥ�k�N�Q���s�� OnClick �ƥ�ե�
    public void getUserContent()
    {
        string content = inputField.text; // ����Τ��J
        int index = content.LastIndexOf("�C");
        int type = 0;
        if (index == -1)
        {
            Debug.Log("�S���y��");
        }
        switch (content.Substring(index + 1).Trim())
        {
            case "�O�D�D":
                type = 0;
                break;
            case "��ܬO�D�D":
                type = 1;
                break;
            case "����D":
                type = 2; 
                break;
            case "�h���D":
                type = 3;
                break;
            case "�ݵ��D":
                type = 4;
                break;
        }
        content = content.Substring(0,index+1);
        // �ˬd�O�_���ũ� null
        if (string.IsNullOrEmpty(content))
        {
            Debug.Log("��J���e���šA�п�J���e");
            return; // �p�G���šA�h�X���
        }

        // �ϥ� StartCoroutine �ӱҰʨ�{
        StartCoroutine(UploadContent(content,type));

        Debug.Log("getUserContent Called");
        
    }

    // ��{�G�W�Ǥ��e�ܫ��w�� URL
    IEnumerator UploadContent(string content,int type)
    {
        string url = "http://127.0.0.1:8000/unitydata/upload_content/"; // ��אּ�A���W�� API
        WWWForm form = new WWWForm(); // �Ыطs�����
        
        string id = FirebaseManager.getEmail(); // �����e�Τ᪺ email

        // �ˬd id �O�_�� null
        if (string.IsNullOrEmpty(id))
        {
            Debug.LogError("�Τ� ID ���šA�L�k�W�Ǥ��e�C");
            yield break; // �p�G id ���šA�h�X��{
        }

        form.AddField("userid", id); // �K�[�Τ� ID ����
        form.AddField("content", content); // �K�[���e����
        form.AddField("questiontype", type);
        Debug.Log($"�W�Ǫ����e: {content}"); // ��x��X�W�Ǥ��e

        using (UnityWebRequest www = UnityWebRequest.Post(url, form)) // �ϥ� POST �ШD�W��
        {
            // www.timeout = 10; // �i��G�]�w 10 ��W��
            yield return www.SendWebRequest(); // �o�e�ШD�õ��ݦ^��

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                // �ШD���~�A��X���~�H��
                Debug.LogError($"�W�ǿ��~: {www.error}\n�^��: {www.downloadHandler.text}");
            }
            else
            {
                // �W�Ǧ��\�A��X�^���H��
                Debug.Log($"�W�ǧ����I�^��: {www.downloadHandler.text}");
                SceneSystem.changeScene(SceneType.SCENE_AIQUESTION);
            }
        }
    }
}
