using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController _instance;
    public static InputController Instance => _instance;

    public PlayerAction inputActions;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        inputActions = new PlayerAction();
    }

	private void Start()
	{
        inputActions.PlayerControl.Enable();
    }

	private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    

    public Vector2 movement => inputActions.PlayerControl.Movement.ReadValue<Vector2>();
    public Vector2 MouseInput => inputActions.PlayerControl.MouseInput.ReadValue<Vector2>().normalized;

    public bool R => inputActions.PlayerControl.Reload.triggered;

    public bool ESC => inputActions.PlayerControl.ESC.triggered;


    private void Update()
    {
        GetPressedNumber();
    }

    public int GetPressedNumber()
    {
        for (int number = 0; number <= 9; number++)
        {
            if (Input.GetKeyDown(number.ToString()))
            {
                print(number);
                return number;
            }
        }

        return -1;
    }

    public void enableInput()
    {
        inputActions.PlayerControl.Enable();
    }

    public void disableInput()
    {
        inputActions.PlayerControl.Disable();
    }

    public void disableMovement()
	{
        inputActions.PlayerControl.Movement.Disable();
	}

    public void enableMovement()
    {
        inputActions.PlayerControl.Movement.Enable();
    }
}
