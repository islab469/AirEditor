using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    [SerializeField] RectTransform fader;
    private void Start()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(()=> {
            fader.gameObject.SetActive(false);
        });
    }
    public void PlayGame()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1,1,1), 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
            SceneManager.LoadScene("selectgame");
        });
    }
    public void BackMenu()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
            SceneManager.LoadScene("menu");
        });
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
