using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScreenController : MonoBehaviour
{
    public void OnPlayAgainClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
