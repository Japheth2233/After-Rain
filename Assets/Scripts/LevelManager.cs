using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int flowersCollected = 0;

    public TextMeshProUGUI flowerCountText;

    void Start()
    {
        flowerCountText.text =
            "× " + flowersCollected.ToString();
    }

    public void CollectFlower()
    {
        flowersCollected += 1;

        flowerCountText.text =
            "× " + flowersCollected.ToString();
    }
}