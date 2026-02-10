using System;

public class Car
{
    private int year;
    private string make;
    private readonly int maxSpeed = 100;
    private int currentSpeed;

    public int Year
    {
        get { return year; }
        set
        {
            if (IsYearValid(value))
            {
                year = value;
            }
        }
    }

    public string Make
    {
        get { return make; }
        set
        {
            if (IsMakeValid(value))
            {
                make = value.Trim();
            }
        }
    }

    public int CurrentSpeed
    {
        get { return currentSpeed; }
    }

    public int MaxSpeed
    {
        get { return maxSpeed; }
    }

    public Car(int carYear, string carMake)
    {
        if (!IsYearValid(carYear))
        {
            carYear = DateTime.Now.Year;
        }

        if (!IsMakeValid(carMake))
        {
            carMake = "Unknown";
        }

        year = carYear;
        make = carMake.Trim();
        currentSpeed = 0;
    }

    public void Accelerate()
    {
        int nextSpeed = currentSpeed + 5;

        if (nextSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
        else
        {
            currentSpeed = nextSpeed;
        }
    }

    public void Decelerate()
    {
        int nextSpeed = currentSpeed - 5;

        if (nextSpeed < 0)
        {
            currentSpeed = 0;
        }
        else
        {
            currentSpeed = nextSpeed;
        }
    }

    public string GetCarInfo()
    {
        return "Car Info. Year: " + year + ". Make: " + make + ". Speed: " + currentSpeed + " mph.";
    }

    private bool IsYearValid(int value)
    {
        int currentYear = DateTime.Now.Year;
        return value >= 1886 && value <= currentYear;
    }

    private bool IsMakeValid(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }
}

