using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    public void OnBackClick()
    {
        Debug.Log("click is registered");
        SceneManager.LoadScene("Menu+Start");
    }
}
