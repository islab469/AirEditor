using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchPage : MonoBehaviour
{
    [SerializeField]
    private GameObject dogModel; // 狗的模型
    [SerializeField]
    private GameObject catModel; // 貓的模型

    private string selectedModel; // 儲存選擇的模型

    public static Page curnPage = Page.LENGTH;
    public enum Page
    {
        MODEL,
        LENGTH
    }

    // 按下狗的圖片
    public void LoadDogModel()
    {
        Debug.Log("call LoadDogModel");
        Debug.Log("Switched to the Dog model!");
        PlayerPrefs.SetString("SelectedModel", "Dog"); // 設定要顯示的模型名稱
        PlayerPrefs.Save(); // 确保保存
        curnPage = Page.LENGTH; // 设置当前页面
        SceneSystem.changeScene(SceneType.SCENE_CREATE_PROJECT); // 切換到 CreatProject 場景
    }

    // 按下貓的圖片
    public void LoadCatModel()
    {
        Debug.Log("call LoadCatModel");
        Debug.Log("Switched to the Cat model!");
        PlayerPrefs.SetString("SelectedModel", "Cat"); // 設定要顯示的模型名稱
        PlayerPrefs.Save(); // 确保保存
        curnPage = Page.LENGTH; // 设置当前页面
        SceneSystem.changeScene(SceneType.SCENE_CREATE_PROJECT); // 切換到 CreatProject 場景
    }

    // 切換到其他場景
    public void SwitchUploadImage()
    {
        Debug.Log("call SwitchUploadImage");
        curnPage = Page.LENGTH;
        PlayerPrefs.SetString("SelectedModel", "NULL"); // 默認為狗模型
        SceneSystem.changeScene(SceneType.SCENE_CHOOSE_IMAGE); // 切換到 UploadImage 場景
    }

    public void SwitchLobby()
    {
        Debug.Log("call SwitchLobby");
        curnPage = Page.LENGTH;
        SceneManager.LoadScene(0); // 切換到 LOGIN 場景
    }

    public void Switch3DModel()
    {
        Debug.Log("call Switch3DModel");
        curnPage = Page.MODEL;
        SceneSystem.changeScene(SceneType.SCENE_3DMODEL); // 切換到 3DModel 場景
    }

    public void SwitchCreatProject()
    {
        Debug.Log("call SwitchCreatProject");
        curnPage = Page.LENGTH;
        SceneSystem.changeScene(SceneType.SCENE_CREATE_PROJECT); // 切換到 CreatProject 場景
    }

    public void SwitchAIQA()
    {
        Debug.Log("call SwitchAIQA");
        curnPage = Page.LENGTH;
        SceneManager.LoadScene((int)SceneType.SCENE_AIQA); // 切換到 CreatProject 場景
    }

    public void CreatProject()
    {
        Debug.Log("call CreatProject");
        SceneManager.LoadScene(7); // 切換到 CreatProject 場景
    }

    public void ChooseImage()
    {
        Debug.Log("call ChooseImage");
        SceneManager.LoadScene(1); // 切換到 CreatProject 場景
    }
    public void EditProject()
    {
        Debug.Log("call EditProject");
        SceneManager.LoadScene(6); // 切換到 EditProject 場景
    }

    private void Start()
    {
        Debug.Log(curnPage);
        selectedModel = PlayerPrefs.GetString("SelectedModel", "Dog"); // 在 Start 中獲取選擇的模型

        // 根據選擇顯示相應模型
        if (curnPage == Page.LENGTH) { return; }
        if (selectedModel == "Dog")
        {
            Instantiate(dogModel, new Vector3(488, 158, 17), Quaternion.identity);
            Debug.Log("Dog model instantiated.");
        }
        else if (selectedModel == "Cat")
        {
            Instantiate(catModel, new Vector3(488, 158, 17), Quaternion.identity);
            Debug.Log("Cat model instantiated.");
        }
    }
}
