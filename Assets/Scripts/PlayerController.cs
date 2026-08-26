using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public Vector2 moveInput;
    public bool playerInteracting;
    public int collectedPlants;

    public TextMeshProUGUI collectionText;
    public GameObject finalRestoredArea;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collectionText.text = "Collection: " + collectedPlants.ToString() + " / 3";
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerInteracting = true;
        }
        else if (context.canceled)
        {
            playerInteracting = false;
        }
    }

    public void CollectPlant()
    {
        collectedPlants += 1;

        collectionText.text = "Collection: " + collectedPlants.ToString() + " / 3";

        if (collectedPlants == 3)
        {
            finalRestoredArea.SetActive(true);
        }
    }
}
