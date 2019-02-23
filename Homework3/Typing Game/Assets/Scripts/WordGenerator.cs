using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {

   
        static TextAsset worddata = Resources.Load<TextAsset>("Words"); //Load the CSV file with the words
        private static string[] wordList = worddata.text.Split(new char[] { ',' });
       
       
  
   

	public static string GetRandomWord ()
	{
		int randomIndex = Random.Range(0, wordList.Length);
		string randomWord = wordList[randomIndex];

		return randomWord;
	}

}
