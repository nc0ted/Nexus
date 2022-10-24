using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    public void LeaveGame()
    {
        Application.Quit();
    }
    public void OpenScene(string sceneName)
    {
        loadingScreen.SetActive(true);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
    }
}
