using UnityEngine;
using UnityEngine.SceneManagement;
//This adds a section in the inspector to change scroll speed and what scene comes after
public class CrawlText : MonoBehaviour
{
    public float scrollSpeed = 15f;
    public float endYPosition = 1000f;
    public string nextScene;

    //This loads next scene at a position I specify
    void Update()
    {transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        if (transform.position.y >= endYPosition)
        {
            LoadNextScene();
        }
    }

//This is for skip button
    public void LoadNextScene()
    {SceneManager.LoadScene(nextScene);}
}