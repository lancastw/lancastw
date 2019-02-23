using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WordManager : MonoBehaviour {

	public List<Word> words;
    public Text scoreDisplayText;
    public WordSpawner wordSpawner;
    public int Score = 0;
	private bool hasActiveWord;
	private Word activeWord;

	public void AddWord ()
	{
		Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
		Debug.Log(word.word);

		words.Add(word);
        
    }

	public void TypeLetter (char letter)
	{
        
        if (hasActiveWord)
		{
			if (activeWord.GetNextLetter() == letter)
			{
				activeWord.TypeLetter();
                Score += 10;
                scoreDisplayText.text = "Score: " + Score.ToString();
            }
		} else
		{
			foreach(Word word in words)
			{
				if (word.GetNextLetter() == letter)
				{
					activeWord = word;
					hasActiveWord = true;
					word.TypeLetter();
					break;
				}
			}
		}

		if (hasActiveWord && activeWord.WordTyped())
		{
			hasActiveWord = false;
			words.Remove(activeWord);
		}
	}
   
}
