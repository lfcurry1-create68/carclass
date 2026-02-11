using System;
/////////////////////////////////////////////
//Assignment/Lab/Project: Car Class
//Name: Louis Curry
//Section: SGD.213.4123
//Instructor: Ven Lewis
//Date: 2/10/2026
/////////////////////////////////////////////
// Represents a car object that stores data and controls speed behavior
public class Car
{
    private int year; // Stores the year of the car
    private string make; // Stores the make or brand of the car
    private readonly int maxSpeed = 100; // Stores the maximum speed which cannot be changed
    private int currentSpeed; // Stores the current speed of the car

    // Public property used to get or set the car year with validation
    public int Year
    {
        get { return year; } // Returns the current year value
        set
        {
            // Ensures the year is within the valid range before assigning it
            if (value >= 1886 && value <= DateTime.Now.Year)
            {
                year = value;
            }
        }
    }

    // Public property used to get or set the car make with validation
    public string Make
    {
        get { return make; } // Returns the current make value
        set
        {
            // Ensures the make is not empty or whitespace before assigning it
            if (!string.IsNullOrWhiteSpace(value))
            {
                make = value.Trim();
            }
        }
    }

    // Public read-only property that allows other scripts to read the current speed
    public int CurrentSpeed
    {
        get { return currentSpeed; }
    }

    // Constructor that initializes a new car with a year, make, and starting speed of zero
    public Car(int carYear, string carMake)
    {
        year = carYear;
        make = carMake.Trim();
        currentSpeed = 0;
    }

    // Increases the car speed while preventing it from exceeding the maximum speed
    public void Accelerate()
    {
        currentSpeed += 5;

        // Limits the speed so it never goes above the maximum speed
        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
    }

    // Decreases the car speed while preventing it from going below zero
    public void Decelerate()
    {
        currentSpeed -= 5;

        // Limits the speed so it never becomes negative
        if (currentSpeed < 0)
        {
            currentSpeed = 0;
        }
    }

    // Returns a formatted string containing the car information for display
    public string GetCarInfo()
    {
        return "Year: " + year + "  Make: " + make + "  Speed: " + currentSpeed + " mph";
    }
}


