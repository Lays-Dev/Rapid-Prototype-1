using UnityEngine;

public class HeartContainer : MonoBehaviour
{
    public GameObject[] heartContainers;

    public void RemoveHeart(int index)
    {
        if (index >= 0 && index < heartContainers.Length)
        {
            Destroy(heartContainers[index]);
        }
    }
}
