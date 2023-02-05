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
    public Vector2 mousePos => inputActions.PlayerControl.MousePos.ReadValue<Vector2>();
    public bool LeftClick => inputActions.PlayerControl.Shoot.triggered;
    public bool LeftClickHold => inputActions.PlayerControl.Shoot.ReadValue<float>() > 0.1f;
    public bool RightClick => inputActions.PlayerControl.Zoom.ReadValue<float>() > 0.1f;
    public bool R => inputActions.PlayerControl.Reload.triggered;
    public bool E => inputActions.PlayerControl.Interact.triggered;
    public bool E_UP => inputActions.PlayerControl.E_up.triggered;
    public bool E_Down => inputActions.PlayerControl.E_down.triggered;
    public bool E_updown => inputActions.PlayerControl.E_upDown.triggered;
    public bool Heal => inputActions.PlayerControl.Heal.triggered;
    public bool ESC => inputActions.UI.ESC.triggered;
    public bool Space => inputActions.PlayerControl.Jump.triggered;
    public bool LeftShift => inputActions.PlayerControl.LeftShift.ReadValue<float>() > 0.1f;
    public bool Dash => inputActions.PlayerControl.Dash.triggered;
    public bool debug => inputActions.PlayerControl.Debug.triggered;

    public bool G => inputActions.PlayerControl.G.triggered;

    private void Update()
    {
        GetPressedNumber();

        print(R);
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
