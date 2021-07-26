using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;
	public GameObject panel;
	public Animator animator;

	private CC3D controller3d;
	private CC2D controller2d;
	private bool was2d;

	private Queue<string> sentences;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();

		controller2d = GameObject.FindGameObjectWithTag("Player").GetComponent<CC2D>();
		controller3d = GameObject.FindGameObjectWithTag("Player").GetComponent<CC3D>();
		animator = controller3d.GetComponent<Animator>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		//DISABILITA PLAYER
		if (controller2d.isActiveAndEnabled)
		{
			was2d = true;
			animator.SetBool("isRunning", false);
			animator.SetBool("isGrounded", true);
			controller2d.enabled = false;
		}
		else
		{
			was2d = false;
			animator.SetBool("isRunning_TD", false);
			controller3d.enabled = false;
		}

		//animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;
		panel.SetActive(true);
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		Debug.Log(sentences.Count);
		DisplayNextSentence();

	}

	public void DisplayNextSentence()
	{
		Debug.Log(sentences.Count);
		if (sentences.Count == 0) 
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	virtual public void EndDialogue()
	{
        //RIABILITA PLAYER
        if (was2d)
        {
			controller2d.enabled = true;
		}
		else
			controller3d.enabled = true;

		//animator.SetBool("IsOpen", false);
		panel.SetActive(false);
	}

}


