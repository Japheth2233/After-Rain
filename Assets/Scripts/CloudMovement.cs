using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    public float leftPosition = -12f;
    public float rightPosition = 12f;

    void Update()
    {
        transform.localPosition +=
            Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.localPosition.x < leftPosition)
        {
            transform.localPosition =
                new Vector3(
                    rightPosition,
                    transform.localPosition.y,
                    transform.localPosition.z
                );
        }
    }
}
