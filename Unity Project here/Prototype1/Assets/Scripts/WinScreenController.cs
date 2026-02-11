using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenController : MonoBehaviour
{
    public void OnPlayAgainClick()
    {
        Debug.Log("click is registered");
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
