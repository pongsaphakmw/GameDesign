using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

   public void DisplayNextSentence()
   {
       if (sentences.Count == 0)
       {
           EndDialogue();
           return;
       }

       string sentence = sentences.Dequeue();
       StopAllCoroutines();
       StartCoroutine(TypeSentence(sentence));
   }
    // This is the function that makes the text appear letter by letter
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);  // 0.03f is the delay between each letter
        }
    }
   public void EndDialogue()
   {
        Debug.Log("End of conversation");
        animator.SetBool("IsOpen", false);
   }
}
