using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OOPPlayer : Character
{
    public void Start()
    {
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // call method Move(Vector2.up);
            Move(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            // call method Move(Vector2.down);
            Move(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            // call method Move(Vector2.left);
            Move(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // call method Move(Vector2.right);
            Move(Vector2.right);
        }
    }
}
