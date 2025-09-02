using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment.StudentSolution.LCT01
{
    public class Car
    {
        public string Name;
        public Color color;
        public float Speed;

        public void Move()
        {
            Debug.Log("Car is moving");
        }
        
        public void Turn()
        {
            Debug.Log("Car is turning");
        }
        
        public void Honk()
        {
            Debug.Log("Car is honking");
        }
    }

    public class LCT01SyntaxClass
    {
        public void Start()
        {
            // Student code start HERE ...
            
            Car car = new Car();
            Car car2 = new Car();
            car.Name = "Car1";
            car.Name = "Car2";
            car.color = Color.red;
            car.Speed = 100.0f;

            car.Move();
            car.Turn();
            car.Honk();
            
            // Student code ends HERE
        }
    }
}
