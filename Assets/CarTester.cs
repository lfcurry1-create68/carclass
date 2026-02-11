using TMPro;
using UnityEngine;
using UnityEngine.UI;
/////////////////////////////////////////////
//Assignment/Lab/Project: Car Class
//Name: Louis Curry
//Section: SGD.213.4123
//Instructor: Ven Lewis
//Date: 2/10/2026
/////////////////////////////////////////////
// Controls the user interface, player input, and communication with the Car class
public class CarGameUI : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private TMP_InputField yearInput; // Input field where the player enters the car year
    [SerializeField] private TMP_InputField makeInput; // Input field where the player enters the car make

    [Header("Button")]
    [SerializeField] private Button createButton; // Button used to create the car after validation

    [Header("Text")]
    [SerializeField] private TMP_Text feedbackText; // Displays validation messages and feedback to the player
    [SerializeField] private TMP_Text carInfoText; // Displays the current car information on screen
    [SerializeField] private TMP_Text controlsText; // Displays control instructions for the player

    private Car car; // Reference to the Car object created by the player
    private bool carCreated; // Tracks whether the car has been created yet
    private int lastSpeed; // Stores the last speed value to detect changes

    private void Start()
    {
        carCreated = false; // Ensures no car exists when the game starts
        lastSpeed = -1; // Initializes last speed to an invalid value for comparison

        if (feedbackText != null)
        {
            feedbackText.text = ""; // Clears feedback text at the start
        }

        if (carInfoText != null)
        {
            carInfoText.gameObject.SetActive(false); // Hides car information until a car is created
            carInfoText.text = ""; // Clears any existing text
        }

        if (controlsText != null)
        {
            controlsText.gameObject.SetActive(false); // Hides controls text until a car is created
            controlsText.text = "Up Arrow accelerate. Down Arrow decelerate."; // Sets control instructions
        }

        if (createButton != null)
        {
            createButton.onClick.AddListener(CreateCar); // Calls CreateCar when the button is pressed
        }
    }

    private void Update()
    {
        if (!carCreated)
        {
            return; // Stops input logic from running until a car exists
        }

        bool changed = false; // Tracks whether speed changed this frame

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            car.Accelerate(); // Calls the car accelerate method
            changed = true; // Marks that a change occurred
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            car.Decelerate(); // Calls the car decelerate method
            changed = true; // Marks that a change occurred
        }

        if (changed && car.CurrentSpeed != lastSpeed)
        {
            lastSpeed = car.CurrentSpeed; // Updates stored speed value
            UpdateCarInfoText(); // Updates UI only when speed changes
        }
    }

    private void CreateCar()
    {
        if (feedbackText != null)
        {
            feedbackText.text = ""; // Clears previous feedback messages
        }

        string yearText = yearInput != null ? yearInput.text : ""; // Reads year input text
        string makeText = makeInput != null ? makeInput.text : ""; // Reads make input text

        int yearValue;
        bool yearParsed = int.TryParse(yearText, out yearValue); // Attempts to convert year text into an integer

        int currentYear = System.DateTime.Now.Year; // Gets the current real-world year
        bool yearValid = yearParsed && yearValue >= 1886 && yearValue <= currentYear; // Checks valid year range
        bool makeValid = !string.IsNullOrWhiteSpace(makeText); // Checks that make is not empty

        if (!yearValid)
        {
            WriteFeedback("Enter a valid year from 1886 to " + currentYear + "."); // Shows error if year is invalid
            return; // Stops execution if validation fails
        }

        if (!makeValid)
        {
            WriteFeedback("Enter a make."); // Shows error if make is empty
            return; // Stops execution if validation fails
        }

        car = new Car(yearValue, makeText); // Creates a new Car object with player input
        carCreated = true; // Marks that the car now exists
        lastSpeed = car.CurrentSpeed; // Stores initial speed value

        if (carInfoText != null)
        {
            carInfoText.gameObject.SetActive(true); // Shows car information text
        }

        if (controlsText != null)
        {
            controlsText.gameObject.SetActive(true); // Shows control instructions
        }

        UpdateCarInfoText(); // Updates UI with initial car data
        WriteFeedback("Car created."); // Displays confirmation message
    }

    private void UpdateCarInfoText()
    {
        if (carInfoText != null && car != null)
        {
            carInfoText.text = car.GetCarInfo(); // Updates displayed car information
        }
    }

    private void WriteFeedback(string message)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message; // Displays feedback message to the player
        }
    }
}
