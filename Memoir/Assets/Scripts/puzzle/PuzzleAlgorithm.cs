using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PuzzleAlgorithm : MonoBehaviour {
    int sol;
    public InputField input;
	public Image int1, int2, int3, int4;
	public Text debug;
    string[] feedback;
    const float SOL_MIN = 1000f;
    const float SOL_MAX = 9999f;
	Image[] images;
	private UnityAction submit;

    // Use this for initialization
    void Start () {
		feedback = new string[4];
        input = gameObject.GetComponent<InputField>();
		var e = new InputField.SubmitEvent();
		e.AddListener (PuzzleSubmit);
		submit = PuzzleSubmit;
		input.onEndEdit.AddListener (submit);
        sol = (int) Mathf.Round(Random.Range(SOL_MIN, SOL_MAX));
		debug = GetComponent<Text> ();
		for (int i = 0; i < 4; i++) {
		}

        //initializes the solution, a random number between
        //1000-9999
    }
	// Update is called once per frame
	void Update () {
		//enter is pressed 
	}
	void PuzzleSubmit(string guess){
		int G = 0;
		int tempsol = sol;
		string result = "";
		G = int.Parse (guess);
		for(int i = 4; i > 0; i--) {
			int Isol = sol % 10;
			int Iguess = G % 10;
			if(Isol == Iguess){
				result = result + "= ";
			}else if(Isol > Iguess){
				result = result + "> ";
			}else{
				result = result + "< ";
			}
		}
		debug.text = result;
		input.ActivateInputField ();
	}
    
}
