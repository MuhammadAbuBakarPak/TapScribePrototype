using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonSelection : MonoBehaviour
{
	private const float defaultSelectionTime = 0.5f;

	public TMP_InputField inputField;
	public TextMeshProUGUI textField;


	private string[] sentences = {
		"my preferred treat is chocolat",
		"we are subjects and must obey",
		"there will be some fog tonight",
		"there will be some fog tonight",
		"my bank account is overdrawn"
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
		selectedButton = buttons[13];

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



		// Check mouse movement direction
		MouseMovement();

		// Change the color of the selected button
		ChangeButtonColor(selectedButton);

	}



	// Helper methods to calculate the new selected button based on layout
	public GameObject GetButtonOnRight(GameObject currentButton)
	{
		int currentIndex = System.Array.IndexOf(buttons, currentButton);
		int nextIndex = currentIndex + 1;

		// Check if it's at the rightmost button
		if (nextIndex % columnSize == 0)
			nextIndex -= columnSize;

		return buttons[nextIndex];
	}

	public GameObject GetButtonOnLeft(GameObject currentButton)
	{
		int currentIndex = System.Array.IndexOf(buttons, currentButton);
		int prevIndex = currentIndex - 1;

		// Check if it's at the leftmost button
		if (currentIndex % columnSize == 0)
			prevIndex += columnSize;

		return buttons[prevIndex];
	}

	public GameObject GetButtonAbove(GameObject currentButton)
	{
		int currentIndex = System.Array.IndexOf(buttons, currentButton);
		int aboveIndex = currentIndex - columnSize;

		// Check if it's at the topmost button
		if (aboveIndex < 0)
			aboveIndex += buttons.Length;

		return buttons[aboveIndex];
	}

	public GameObject GetButtonBelow(GameObject currentButton)
	{
		int currentIndex = System.Array.IndexOf(buttons, currentButton);
		int belowIndex = currentIndex + columnSize;

		// Check if it's at the bottommost button
		if (belowIndex >= buttons.Length)
			belowIndex -= buttons.Length;

		return buttons[belowIndex];
	}

	public GameObject GetButtonTopRight(GameObject currentButton)
	{
		GameObject buttonOnRight = GetButtonOnRight(currentButton);
		return GetButtonAbove(buttonOnRight);
	}

	public GameObject GetButtonTopLeft(GameObject currentButton)
	{
		GameObject buttonOnLeft = GetButtonOnLeft(currentButton);
		return GetButtonAbove(buttonOnLeft);
	}

	public GameObject GetButtonBottomRight(GameObject currentButton)
	{
		GameObject buttonOnRight = GetButtonOnRight(currentButton);
		return GetButtonBelow(buttonOnRight);
	}

	public GameObject GetButtonBottomLeft(GameObject currentButton)
	{
		GameObject buttonOnLeft = GetButtonOnLeft(currentButton);
		return GetButtonBelow(buttonOnLeft);
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

		if (selectedButton == buttons[0])
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				WriteCharacterToInputField('q');
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				WriteCharacterToInputField('w');
			}
			else if (Input.GetKeyDown(KeyCode.I))
			{
				WriteCharacterToInputField('e');
			}
			else if (Input.GetKeyDown(KeyCode.O))
			{
				WriteCharacterToInputField('r');
			}
			else if (Input.GetKeyDown(KeyCode.U))
			{
				WriteCharacterToInputField('t');
			}
		}
		else if (selectedButton == buttons[1])
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				WriteCharacterToInputField('y');
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				WriteCharacterToInputField('u');
			}
			else if (Input.GetKeyDown(KeyCode.I))
			{
				WriteCharacterToInputField('i');
			}
			else if (Input.GetKeyDown(KeyCode.O))
			{
				WriteCharacterToInputField('o');
			}
			else if (Input.GetKeyDown(KeyCode.U))
			{
				WriteCharacterToInputField('p');
			}
		}
		else if (selectedButton == buttons[2])
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				WriteCharacterToInputField('a');
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				WriteCharacterToInputField('s');
			}
			else if (Input.GetKeyDown(KeyCode.I))
			{
				WriteCharacterToInputField('d');
			}
			else if (Input.GetKeyDown(KeyCode.O))
			{
				WriteCharacterToInputField('f');
			}
			else if (Input.GetKeyDown(KeyCode.U))
			{
				WriteCharacterToInputField('g');
			}
		}
		else if (selectedButton == buttons[3])
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				WriteCharacterToInputField('h');
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				WriteCharacterToInputField('j');
			}
			else if (Input.GetKeyDown(KeyCode.I))
			{
				WriteCharacterToInputField('k');
			}
			else if (Input.GetKeyDown(KeyCode.O))
			{
				WriteCharacterToInputField('l');
			}
			else if (Input.GetKeyDown(KeyCode.U))
			{
				WriteCharacterToInputField('.');
			}
		}
		else if (selectedButton == buttons[4])
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				WriteCharacterToInputField('z');
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				WriteCharacterToInputField('x');
			}
			else if (Input.GetKeyDown(KeyCode.I))
			{
				WriteCharacterToInputField('c');
			}
			else if (Input.GetKeyDown(KeyCode.O))
			{
				WriteCharacterToInputField('v');
			}
			else if (Input.GetKeyDown(KeyCode.U))
			{
				WriteCharacterToInputField('b');
			}
		}
		else if (selectedButton == buttons[5])
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				WriteCharacterToInputField('n');
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				WriteCharacterToInputField('m');
			}
			else if (Input.GetKeyDown(KeyCode.I))
			{
				WriteCharacterToInputField(',');
			}
			else if (Input.GetKeyDown(KeyCode.O))
			{
				WriteCharacterToInputField('.');
			}
			else if (Input.GetKeyDown(KeyCode.U))
			{
				WriteCharacterToInputField('/');
			}
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




	private void LateUpdate()
	{
		ProcessKeyPress();
	}


	// Check mouse movement direction
	public void MouseMovement()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;


		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {
			float inputX = Input.GetAxis ("Mouse X");
			float inputY = Input.GetAxis ("Mouse Y");

			if (Mathf.Abs (inputX) > Mathf.Abs (inputY)) {
				if ( inputX > 0) {
					selectedButton = GetButtonOnRight (selectedButton);
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
					//Debug.Log ("Value of X is: " + inputX);
				} else if (inputX < 0) {
					selectedButton = GetButtonOnLeft (selectedButton);
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				}
				} 

			else {
				if (inputY > 0) {
					selectedButton = GetButtonAbove (selectedButton);
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (inputY < 0) {
					selectedButton = GetButtonBelow (selectedButton);
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				}
			}

			if (inputX > 0 && inputY > 0) {
				selectedButton = GetButtonTopRight (selectedButton);
				lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
			} 

			else if (inputX < 0 && inputY > 0) {
				selectedButton = GetButtonTopLeft (selectedButton);
				lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
			} 

			else if (inputX > 0 && inputY < 0) {
				selectedButton = GetButtonBottomRight (selectedButton);
				lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
			}
			else if (inputX < 0 && inputY < 0) {
				selectedButton = GetButtonBottomLeft (selectedButton);
				lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
			} 

		} 



































		/*
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;


		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0) {
			// Get Trackball movement input
			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Check mouse movement direction
			if (mouseX > 0 && Mathf.Abs(mouseX) > 0.01f)
			{
				// Move to the button on the right
				selectedButton = GetButtonOnRight(selectedButton);
				lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
			}
			else if (mouseX < 0 && Mathf.Abs(mouseX) > 0.01f)
			{
				// Move to the button on the left
				selectedButton = GetButtonOnLeft(selectedButton);
				lastSelectionTime=defaultSelectionTime; 
			}

			else if (mouseY > 0 && Mathf.Abs(mouseY) > 0.01f)
			{
				// Move to the button above
				selectedButton = GetButtonAbove(selectedButton);
				lastSelectionTime=defaultSelectionTime;
			}
			else if (mouseY < 0 && Mathf.Abs(mouseY) > 0.01f)
			{
				// Move to the button below
				selectedButton = GetButtonBelow(selectedButton);
				lastSelectionTime=defaultSelectionTime; 
			}





			// Check mouse movement direction
			if (mouseX  >= -6 && Mathf.Abs (mouseX) > 0.01f) {
				// Move to the button on the left
				selectedButton = buttons [1];
				lastSelectionTime = defaultSelectionTime; 
			}
			else if (mouseX  >= 6 && Mathf.Abs (mouseX) > 0.01f) {
				// Move to the button on the right
				selectedButton = buttons [4];
				lastSelectionTime = defaultSelectionTime; 
			}
			else if (mouseY  >= 6 && Mathf.Abs (mouseY) > 0.01f) {
				// Move to the button on the 
				selectedButton = buttons [2];
				lastSelectionTime = defaultSelectionTime; 
			}
			else if (mouseY  >= -6 && Mathf.Abs (mouseY) > 0.01f) {
				// Move to the button on the 
				selectedButton = buttons [5];
				lastSelectionTime = defaultSelectionTime; 
			}
			*/







			/*
			// Check mouse movement direction
			if (mouseX > 0 && Mathf.Abs (mouseX) > 0.01f) {
				// Move to the button on the right
				selectedButton = buttons [4];
				lastSelectionTime = defaultSelectionTime; 
			} else if (mouseX < 0 && Mathf.Abs (mouseX) > 0.01f) {
				// Move to the button on the left
				selectedButton = buttons [1];
				lastSelectionTime = defaultSelectionTime; 
			} else if (mouseY > 0 && Mathf.Abs (mouseY) > 0.01f) {
				// Move to the button above
				selectedButton = buttons [3];
				lastSelectionTime = defaultSelectionTime;
			} else if (mouseY < 0 && Mathf.Abs (mouseY) > 0.01f) {
				// Move to the button below
				selectedButton = buttons [5];
				lastSelectionTime = defaultSelectionTime; 
			}



			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2(mouseX, mouseY) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;
			Debug.Log ("Current angle is " + angle);



			if (angle > 0 && angle < 50  )
			{
				selectedButton = buttons[1];
				//lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				Debug.Log ("Current angle is " + angle);
			}
			else if (angle > 50 &&  angle < 90)
			{
				selectedButton = buttons[2];
				//lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				Debug.Log ("Current angle is " + angle);
			}
			else if (angle > 90 && angle < 150)
			{
				selectedButton = buttons[3];
				//lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				Debug.Log ("Current angle is " + angle);
			}
			else if (angle > 150 && angle < 200)
			{
				selectedButton = buttons[4];
				//lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				Debug.Log ("Current angle is " + angle);
			}
			else if (angle > 200 && angle < 260)
			{
				selectedButton = buttons[5];
				//lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				Debug.Log ("Current angle is " + angle);
			}


			// Check mouse movement direction
			if (mouseX > 0 && Mathf.Abs(mouseX) > 0.01f)
			{
				// Move to the button on the right
				selectedButton = GetButtonOnRight(selectedButton);
				lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
			}
			else if (mouseX < 0 && Mathf.Abs(mouseX) > 0.01f)
			{
				// Move to the button on the left
				selectedButton = GetButtonOnLeft(selectedButton);
				lastSelectionTime=defaultSelectionTime; 
			}

			else if (mouseY > 0 && Mathf.Abs(mouseY) > 0.01f)
			{
				// Move to the button above
				selectedButton = GetButtonAbove(selectedButton);
				lastSelectionTime=defaultSelectionTime;
			}
			else if (mouseY < 0 && Mathf.Abs(mouseY) > 0.01f)
			{
				// Move to the button below
				selectedButton = GetButtonBelow(selectedButton);
				lastSelectionTime=defaultSelectionTime; 
			}
		}*/
	}

}





