using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : Interactable {

    public Door door;
	public int num_inputs = 4;
    public Canvas puzzle_canvas;
    public Button[] inc_inputs;
    public Button[] dec_inputs;
    public Button button;
    public Button button_1;
    public Image[] results;
    public Text[] text;
    public Image status;
    private bool exited = false;
    private int[] solution;
    private int[] guess;

	void Awake ()
    {
        solution = new int[num_inputs];
        guess = new int[num_inputs];
        puzzle_canvas.GetComponent<Canvas>();
        //increment and decrement arrays
        Button[] inc = new Button[inc_inputs.Length];
        Button[] dec = new Button[dec_inputs.Length];
        //the numbers to be displayed during puzzle
        Text[] numbers = new Text[text.Length];
        //the results of the tests
        Image[] colorful_results = new Image[results.Length];
        //an indicator of the door's locked status
        Image door_status = status.GetComponent<Image>();
        //the big enter button
        Button submit = button.GetComponent<Button>();
        //the locked door that needs to be opened
        Door locked = door.GetComponent<Door>();
        Button exit = button_1.GetComponent<Button>();
        //Get Components for both button arrays
        for(int i = 0; i < inc_inputs.Length; i++)
        {
            inc[i] = inc_inputs[i].GetComponent<Button>();
        }
        for (int i = 0; i < dec_inputs.Length; i++)
        {
            dec[i] = dec_inputs[i].GetComponent<Button>();
        }
        //Get componenets for the text array
        for(int i = 0; i < text.Length; i++)
        {
            numbers[i] = text[i].GetComponent<Text>();
        }

        //Assign listeners to all buttons so that pressing a certain button incremnets corresponding value
        for(int i = 0; i < num_inputs; i++)
        {
            int current = i;
            inc[i].onClick.AddListener(() => Inc_Sol(current));
            dec[i].onClick.AddListener(() => Dec_Sol(current));
        }
        submit.onClick.AddListener(Check_Sol);
        exit.onClick.AddListener(Exit);
        //Get Component for all the images in the results
        for(int i = 0; i < results.Length; i++)
        {
            colorful_results[i] = results[i].GetComponent<Image>();
        }
        for (int i = 0; i < num_inputs; i++)
        {
            solution[i] = Random.Range(0, 9);
            Debug.Log("Solution is " + solution[i]);
        }
        for(int i = 0; i < guess.Length; i++)
        {
            guess[i] = 0;
        }

        door_status.color = Color.red;
        puzzle_canvas.enabled = false;
	}

    void Update()
    {
        if(puzzle_canvas.enabled == true && (Input.GetKeyDown(KeyCode.Escape) || exited == true))
        {
            puzzle_canvas.enabled = false;
            for (int i = 0; i < num_inputs; i++)
            {
                solution[i] = Random.Range(0, 9);
                guess[i] = 0;
            }

            foreach(Image element in results)
            {
                element.color = Color.white;
            }

            foreach(Text element in text)
            {
                element.text = "0";
            }
        }

        this.name_of_object = puzzle_canvas.enabled ? "" : "Panel";

        // During Puzzle disable player movement to stop them from going to unintended places.
        if (puzzle_canvas.enabled)
        {
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			GetComponent<Animator>().SetBool("isWalking", false);
			GetComponent<Animator>().SetBool("isRunning", false);
			player.GetComponent<PlayerMovementController>().enabled = false;
        } 
		else
        {
			player.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX;
			player.GetComponent<PlayerMovementController>().enabled = true;
        }
    }

    public override void Interact()
    {
        puzzle_canvas.enabled = true;
    }

    void Inc_Sol(int inc_index)
    {
        if(guess[inc_index] >= 0 && guess[inc_index] <= 9)
        {
            if (guess[inc_index] != 9) guess[inc_index]++;
            text[inc_index].text = guess[inc_index].ToString();
        }
    }

    void Dec_Sol(int dec_index)
    {
        if (guess[dec_index] >= 0 && guess[dec_index] <= 9)
        {
            if(guess[dec_index] != 0) guess[dec_index]--;
            text[dec_index].text = guess[dec_index].ToString();
        }
    }

    void Check_Sol()
    {
        int truth = 0;
        for(int i = 0; i < num_inputs; i++)
        {
            if(guess[i] > solution[i])
            {
                results[i].color = Color.red;
                results[i + num_inputs].color = Color.yellow;
            } else if (guess[i] < solution[i])
            {
                results[i + num_inputs].color = Color.red;
                results[i].color = Color.yellow;
            } else if (guess[i] == solution[i])
            {
                truth++;
                results[i].color = Color.green;
                results[i + num_inputs].color = Color.green;
            }
        }
        Debug.Log(truth);
        if(truth == num_inputs)
        {
            door.unlocked = true;
            status.color = Color.green;
            truth = 0;
        }
    }

    void Exit()
    {
		puzzle_canvas.enabled = false;
		if(door.unlocked){
        	exited = true;
		}
    }
}
