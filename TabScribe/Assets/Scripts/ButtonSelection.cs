using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonSelection : MonoBehaviour
{
	private const float defaultSelectionTime = 4.0f;

	public TMP_InputField inputField;
	public TextMeshProUGUI textField;


	private string[] sentences = {
		"a bad fig jam",
		"ben can hang a bag",
		"ann had a mad camel",
		"ben can bake a cake",
		"khan feeding an eagle"
	};
	// Current sentence index
	private int currentSentenceIndex = 0;

	// Variables for tracking text entry speed
	private float startTime;
	private float endTime;
	private int T;


	// Public variable for button assignment in the Unity editor
	public GameObject[] buttons;
	public int columnSize; // Number of buttons in each column

	// Current selected button
	private GameObject selectedButton;
	private Color originalColor;
	public Color selectedColor;

	//public float mouseSensitivity;
	private float lastSelectionTime = defaultSelectionTime;


	private void Start()
	{
		// Initialize the starting selected button from sentences
		selectedButton = buttons[0];

		// Display the first sentence in the text field
		textField.text = sentences[currentSentenceIndex];

		// Get the original color of the button
		Renderer buttonRenderer = selectedButton.GetComponent<Renderer>();
		if (buttonRenderer != null)
		{
			originalColor = buttonRenderer.material.color;
		}

	}

	private void Update()
	{
		// Selections from different buttons
		SelectionfromA();
		SelectionfromB();
		SelectionfromC();
		SelectionfromD();
		SelectionfromE();
		SelectionfromF();
		SelectionfromG();
		SelectionfromH();
		SelectionfromI();
		SelectionfromJ();
		SelectionfromK();
		SelectionfromL();
		SelectionfromM();
		SelectionfromN();
		// Change the color of the selected button
		ChangeButtonColor(selectedButton);
		inputField.ActivateInputField();

	}

	private void LateUpdate()
	{
		ProcessKeyPress();
	}





	//Button Color Changing Mechanism
	private void ChangeButtonColor(GameObject button)
	{
		// Reset color of previously selected button
		foreach (GameObject btn in buttons)
		{
			if (btn != button)
			{
				SetButtonColor(btn, originalColor);
			}
		}

		// Change color of the selected button
		SetButtonColor(button, selectedColor);
	}

	private void SetButtonColor(GameObject button, Color color)
	{
		MeshRenderer[] renderers = button.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer renderer in renderers)
		{
			renderer.material.color = color;
		}
	}

	private Color GetButtonColor(GameObject button)
	{
		MeshRenderer[] renderers = button.GetComponentsInChildren<MeshRenderer>();
		if (renderers.Length > 0)
		{
			return renderers[0].material.color;
		}
		return Color.white;
	}

	// Write character into input field
	private void WriteCharacterToInputField(char character)
	{
		if (inputField != null)
		{
			inputField.text += character.ToString();
			T = inputField.text.Length; // Update the length of the transcribed string
		}
	}






	// ProcessKeyPress method checks the selected button and the pressed key to determine which character to write using the WriteCharacterToInputField method.
	private void ProcessKeyPress()
	{
		// Check if the user presses the first character of a sentence
		if (Input.anyKeyDown && T == 0)
		{
			// Start the timer for text entry
			startTime = Time.time;
		}

		if (selectedButton == buttons[0] &&  Input.GetKeyDown(KeyCode.I))
		{
				WriteCharacterToInputField('a');
		}
		else if (selectedButton == buttons[1] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('b');
		}
		else if (selectedButton == buttons[2] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('c');
		}
		else if (selectedButton == buttons[3] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('d');
		}
		else if (selectedButton == buttons[4] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('e');
		}
		else if (selectedButton == buttons[5] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('f');
		}
		else if (selectedButton == buttons[6] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('g');
		}
		else if (selectedButton == buttons[7] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('h');
		}
		else if (selectedButton == buttons[8] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('i');
		}

		else if (selectedButton == buttons[9] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('j');
		}
		else if (selectedButton == buttons[10] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('k');
		}
		else if (selectedButton == buttons[11] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('l');
		}
		else if (selectedButton == buttons[12] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('m');
		}
		else if (selectedButton == buttons[13] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('n');
		}

		// Handle backspace key
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			if (inputField != null && inputField.text.Length > 0)
			{
				inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
			}
		}

		// Handle space key
		if (Input.GetKeyDown(KeyCode.Space))
		{
			WriteCharacterToInputField(' ');
		}

		// Handle the "Enter" key press
		if (Input.GetKeyDown(KeyCode.Return))
		{
			EnterKeyFunctionality();

			//WPM Calculation
			// Stop the timer for text entry
			endTime = Time.time;
			// Calculate the text entry speed for the current sentence
			float S = endTime - startTime;
			float wordsPerMinute = (T - 1) / S * 60f * 0.2f;
			Debug.LogFormat("Text Entry Speed (Sentence {0}): {1} WPM", currentSentenceIndex, wordsPerMinute);
		}

	}

	//Perform Enter Key Functionality
	private void EnterKeyFunctionality()
	{
		if (textField != null)
		{

			currentSentenceIndex++;
			// Update the text field with the next sentence
			if (currentSentenceIndex  < sentences.Length)
			{
				textField.text = sentences[currentSentenceIndex];

				// Clear the input field
				inputField.text = string.Empty;
			}
			else
			{
				// Reset sentence index and display a message
				currentSentenceIndex = 0;
				textField.text = "Done";
			}
		}
	}







	// Selection for neighbours of a
	public void SelectionfromA()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0)
		{
			
			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;
			if (angle < 0)
				angle += 360;

		if (selectedButton == buttons[0])
		{
			if (angle > 0 && angle < 90) 
			{
				selectedButton = buttons [3];
				lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
			}
			else if (angle > 90 &&  angle < 155)
			{
				selectedButton = buttons[2];
				lastSelectionTime = defaultSelectionTime;
			}
			else if (angle > 155 &&  angle < 215)
			{
				selectedButton = buttons[1];
				lastSelectionTime = defaultSelectionTime;
			}
			else if (angle > 215 &&  angle < 310)
			{
				selectedButton = buttons[5];
				lastSelectionTime = defaultSelectionTime;
			}
			else if (angle > 310 &&  angle < 360)
			{
				selectedButton = buttons[4];
				lastSelectionTime = defaultSelectionTime;
			}
		}
	}
	}


	// Selection for neighbours of b
	public void SelectionfromB()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {
			
			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == buttons [1])
			{
				if (angle > 0 && angle < 40)
				{
					selectedButton = buttons [0];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 40 && angle < 90)
				{
					selectedButton = buttons [2];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 90 && angle < 140)
				{
					selectedButton = buttons [9];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 140 && angle < 200)
				{
					selectedButton = buttons [8];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 200 && angle < 280) 
				{
					selectedButton = buttons [7];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 280 && angle < 360)
				{
					selectedButton = buttons [5];
					lastSelectionTime = defaultSelectionTime;
				}
			}
		}
	}




	// Selection for neighbours of c
	public void SelectionfromC()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0)
		{

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;
			if (angle < 0)
				angle += 360;

			if (selectedButton == buttons[2])
			{
				if (angle > 0 && angle < 50) 
				{
					selectedButton = buttons [3];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				}
				else if (angle > 50 &&  angle < 110)
				{
					selectedButton = buttons[10];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 110 &&  angle < 180)
				{
					selectedButton = buttons[9];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 180 &&  angle < 270)
				{
					selectedButton = buttons[1];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 270 &&  angle < 360)
				{
					selectedButton = buttons[0];
					lastSelectionTime = defaultSelectionTime;
				}
			}
		}
	}




	// Selection for neighbours of d
	public void SelectionfromD()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0)
		{

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;
			if (angle < 0)
				angle += 360;

			if (selectedButton == buttons[3])
			{
				if (angle > 0 && angle < 65) 
				{
					selectedButton = buttons [11];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				}
				else if (angle > 65 &&  angle < 140)
				{
					selectedButton = buttons[10];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 140 &&  angle <200 )
				{
					selectedButton = buttons[2];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle >200  &&  angle < 260)
				{
					selectedButton = buttons[0];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 260 &&  angle < 360)
				{
					selectedButton = buttons[4];
					lastSelectionTime = defaultSelectionTime;
				}
			}
		}
	}




	// Selection for neighbours of E
	public void SelectionfromE()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == buttons [4])
			{
				if (angle > 0 && angle < 40)
				{
					selectedButton = buttons [12];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 40 && angle < 80)
				{
					selectedButton = buttons [11];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 80 && angle < 120)
				{
					selectedButton = buttons [3];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 120 && angle < 180)
				{
					selectedButton = buttons [0];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 180 && angle < 270) 
				{
					selectedButton = buttons [5];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 270 && angle < 360)
				{
					selectedButton = buttons [13];
					lastSelectionTime = defaultSelectionTime;
				}
			}
		}
	}




	// Selection for neighbours of F
	public void SelectionfromF()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == buttons [5])
			{
				if (angle > 0 && angle < 50)
				{
					selectedButton = buttons [4];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 50 && angle < 125)
				{
					selectedButton = buttons [0];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 125 && angle < 180)
				{
					selectedButton = buttons [1];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 180 && angle < 230)
				{
					selectedButton = buttons [7];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 230 && angle < 310) 
				{
					selectedButton = buttons [6];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 310 && angle < 360)
				{
					selectedButton = buttons [13];
					lastSelectionTime = defaultSelectionTime;
				}
			}
		}
	}



	// Selection for neighbours of G
	public void SelectionfromG()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == buttons [6])
			{
				if (angle > 0 && angle < 50)
				{
					selectedButton = buttons [13];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 50 && angle < 130)
				{
					selectedButton = buttons [5];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 130 && angle < 200)
				{
					selectedButton = buttons [7];
					lastSelectionTime = defaultSelectionTime;
				} 

			}
		}
	}




	// Selection for neighbours of H
	public void SelectionfromH()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == buttons [7])
			{
				if (angle > 0 && angle < 40)
				{
					selectedButton = buttons [5];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 40 && angle < 90)
				{
					selectedButton = buttons [1];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 90 && angle < 180)
				{
					selectedButton = buttons [8];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 180 && angle < 360)
				{
					selectedButton = buttons [6];
					lastSelectionTime = defaultSelectionTime;
				} 

			}
		}
	}




	// Selection for neighbours of I
	public void SelectionfromI()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == buttons [8])
			{
				if (angle > 0 && angle < 45)
				{
					selectedButton = buttons [1];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 45 && angle < 90)
				{
					selectedButton = buttons [9];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 270 && angle < 360)
				{
					selectedButton = buttons [7];
					lastSelectionTime = defaultSelectionTime;
				} 

			}
		}
	}


	// Selection for neighbours of J
	public void SelectionfromJ()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == buttons [9])
			{
				if (angle > 0 && angle < 40)
				{
					selectedButton = buttons [2];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 40 && angle < 90)
				{
					selectedButton = buttons [10];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 90 && angle < 270)
				{
					selectedButton = buttons [8];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 270 && angle < 360)
				{
					selectedButton = buttons [1];
					lastSelectionTime = defaultSelectionTime;
				} 

			}
		}
	}



	// Selection for neighbours of K
	public void SelectionfromK()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == buttons [10])
			{
				if (angle > 160 && angle < 225)
				{
					selectedButton = buttons [9];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 225 && angle < 270)
				{
					selectedButton = buttons [2];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 270 && angle < 315)
				{
					selectedButton = buttons [3];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 315 && angle < 360)
				{
					selectedButton = buttons [11];
					lastSelectionTime = defaultSelectionTime;
				} 

			}
		}
	}



	// Selection for neighbours of L
	public void SelectionfromL()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == buttons[11])
			{
				if (angle > 90 && angle < 170)
				{
					selectedButton = buttons [10];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 170 && angle < 270)
				{
					selectedButton = buttons [3];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 270 && angle < 360)
				{
					selectedButton = buttons [12];
					lastSelectionTime = defaultSelectionTime;
				} 


			}
		}
	}





	// Selection for neighbours of M
	public void SelectionfromM()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == buttons[12])
			{
				if (angle > 0 && angle < 150)
				{
					selectedButton = buttons [11];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 150 && angle < 210)
				{
					selectedButton = buttons [4];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 210 && angle < 360)
				{
					selectedButton = buttons [13];
					lastSelectionTime = defaultSelectionTime;
				} 


			}
		}
	}





	// Selection for neighbours of N
	public void SelectionfromN()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == buttons[13])
			{
				if (angle > 0 && angle < 90)
				{
					selectedButton = buttons [12];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 90 && angle < 145)
				{
					selectedButton = buttons [4];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 145 && angle < 180)
				{
					selectedButton = buttons [5];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 180 && angle < 360)
				{
					selectedButton = buttons [6];
					lastSelectionTime = defaultSelectionTime;
				} 


			}
		}
	}




	}
	





