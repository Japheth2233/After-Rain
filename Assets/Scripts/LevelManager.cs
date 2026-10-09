using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int flowersCollected = 0;

    public void CollectFlower()
    {
        flowersCollected += 1;
    }
}