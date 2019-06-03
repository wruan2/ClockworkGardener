using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHolder : MonoBehaviour
{
  [SerializeField]
    private bool finishedDialog = false;
    public string dialogue;
    private DialogueManager dMan;

    public string[] dialogueLines;

    // Start is called before the first frame update
    void Start()
    {

      dMan = FindObjectOfType<DialogueManager>();

      PlayerController thePlayer = FindObjectOfType<PlayerController>();

    }
    void OnTriggerEnter2D(Collider2D other) {

      PlayerController thePlayer = FindObjectOfType<PlayerController>();

      //thePlayer.SetActive(false);

      if(!finishedDialog) {

        if (other.gameObject.name == "Player") {

            other.GetComponent<PlayerController>().stopPlayer();
          if (!dMan.dialogActive) {

            dMan.dialogLines = dialogueLines;
            dMan.currentLine = 0;
            dMan.ShowDialogue();

          }

          finishedDialog = true;



        }
        

      }

    }
}
