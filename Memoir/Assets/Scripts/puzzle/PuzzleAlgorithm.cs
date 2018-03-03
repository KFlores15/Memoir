using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PuzzleAlgorithm : MonoBehaviour {
    int sol;
    public InputField input;
	public Text debug;
    const float SOL_MIN = 1000f;
    const float SOL_MAX = 9999f;
	public Image[] images;

    void Start () {
    	sol = (int) Mathf.Round(Random.Range(SOL_MIN, SOL_MAX));
	    //initializes the solution, a random number between
        //1000-9999
    }
	public void PuzzleSubmit(){
		int G = 0;
		int tempsol = sol;
		int finishState = 0;
		string result = "";
		G = int.Parse (input.text);
		for(int i = 3; i >= 0 ; i--) {
			int Isol = tempsol % 10;
			int Iguess = G % 10;
			if(Isol == Iguess){
				images [i].color = Color.green;
				result = "= " + result;
				finishState++;
			}else if(Isol > Iguess){
				images [i].color = Color.yellow;
				result = "< " + result;
				finishState--;
			}else{
				images [i].color = Color.blue;
				result = "> " + result;
				finishState--;
			}
			tempsol = tempsol / 10;
			G = G / 10;
		}
		/* DEBUG CODE
		if (result.Length > 1) {
			debug.text = result.Trim ();
		} else {
			debug.text = "ERROR: result was not calculated";
		}*/
		if (finishState == 4) {
			debug.text = "solution found, implement finish listener";

		}
		input.ActivateInputField ();
	}   
}