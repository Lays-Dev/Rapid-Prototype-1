using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenController : MonoBehaviour
{
    public void OnTryAgainClick()
    {
        SceneManager.LoadScene("Menu+Start");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
