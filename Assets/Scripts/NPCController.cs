using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCController : MonoBehaviour
{
    public Canvas canvas; // Reference to the UI canvas
    public GameObject dialogueBox; // Reference to the UI dialogue box
    public TMP_Text dialogueText; // Reference to the UI text box
    // public string npcMessage; // The NPC's message

    bool playerInRange; // Flag to check if the player is within range

    //set the NPC's message directly in the script 
    string npcMessage = "Hello Buddy!";

    void Update()
    {
        if (playerInRange) // Check for player interaction 
        {
            Debug.Log("Message should appear");
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position); // Get the NPC's position on the screen
            dialogueBox.transform.position = screenPosition + new Vector3(0, 150, 0); // Set the dialogue box's position to be above the NPC
            DisplayDialogue(npcMessage); // Display the NPC's message
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // Check if the player has collided with the NPC
        {
            playerInRange = true;
            dialogueBox.SetActive(true); // Enable the dialogue box
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // Check if the player has stopped colliding with the NPC
        {
            playerInRange = false;
            dialogueBox.SetActive(false); // Disable the dialogue box
            dialogueText.text = ""; // Clear the dialogue text
        }
    }

    void DisplayDialogue(string message)
    {
        dialogueText.text = message; // Set the UI text box to display the NPC's message
    }
}