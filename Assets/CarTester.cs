using UnityEngine;

public class CarTester : MonoBehaviour
{
    private Car car;
    private bool carCreated;

    private int lastPrintedSpeed;

    private void Start()
    {
        carCreated = false;
        lastPrintedSpeed = -1;

        Debug.Log("Car Class Console Test");
        Debug.Log("Up Arrow accelerates. Down Arrow decelerates.");
        Debug.Log("Creating car after validation.");

        int enteredYear = 2020;
        string enteredMake = "Toyota";

        CreateCarIfValid(enteredYear, enteredMake);
    }

    private void Update()
    {
        if (!carCreated)
        {
            return;
        }

        bool speedChanged = false;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            car.Accelerate();
            speedChanged = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            car.Decelerate();
            speedChanged = true;
        }

        if (speedChanged && car.CurrentSpeed != lastPrintedSpeed)
        {
            lastPrintedSpeed = car.CurrentSpeed;
            Debug.Log(car.GetCarInfo());
        }
    }

    private void CreateCarIfValid(int enteredYear, string enteredMake)
    {
        int currentYear = System.DateTime.Now.Year;

        bool yearIsValid = enteredYear >= 1886 && enteredYear <= currentYear;
        bool makeIsValid = !string.IsNullOrWhiteSpace(enteredMake);

        if (!yearIsValid)
        {
            Debug.Log("Year invalid. Enter a year between 1886 and " + currentYear + ".");
            return;
        }

        if (!makeIsValid)
        {
            Debug.Log("Make invalid. Enter a make name.");
            return;
        }

        car = new Car(enteredYear, enteredMake);
        carCreated = true;
        lastPrintedSpeed = car.CurrentSpeed;

        Debug.Log("Car created.");
        Debug.Log(car.GetCarInfo());
    }
}
