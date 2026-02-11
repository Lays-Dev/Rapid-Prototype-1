using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
   public void OnStartClick()
    {
        SceneManager.LoadScene("EpilogueScreen");
    }

    public void OnCreditClick()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
