using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;
    public int currentLine;

    private PlayerController thePlayer;

    private Animator thePlayerAnimation;

    // Start is called before the first frame update
    void Start()
    {

      thePlayer = FindObjectOfType<PlayerController>();

      thePlayerAnimation = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
      if (dialogActive && Input.GetKeyDown(KeyCode.Space)) {

        //dBox.SetActive(false);
        //dialogActive = false;

        currentLine++;
        if (currentLine == 7)
            {
                SceneManager.LoadScene("Victory");
            }
      }

      if (currentLine >= dialogLines.Length) {

        dBox.SetActive(false);
        dialogActive = false;

        currentLine = 0;
        thePlayer.canMove = true;

        thePlayer.moveSpeed = 6.5f;

      }
      if (dialogLines.Length > 0)
        dText.text = dialogLines[currentLine];

    }

    public void ShowBox(string dialogue)
    {
      dialogActive = true;
      dBox.SetActive(true);
      dText.text = dialogue;
    }

    public void ShowDialogue() {

      dialogActive = true;
      dBox.SetActive(true);
      //thePlayerAnimation.canMove = false;
    }

}
