using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class ControllerDisplay : MonoBehaviour
{
    public Color overlayColor;
    public Slider leftMotorSlider;
    public Slider rightMotorSlider;
    
    private Dictionary<string, GameObject> _overlays;
    private string[] _buttonNames =
    {
        "A",
        "B",
        "X",
        "Y",
        "Back",
        "DP_DOWN",
        "DP_LEFT",
        "DP_RIGHT",
        "DP_UP",
        "LA_DOWN",
        "LA_LEFT",
        "LA_RIGHT",
        "LA_UP",
        "RA_DOWN",
        "RA_LEFT",
        "RA_RIGHT",
        "RA_UP",
        "LB",
        "LT",
        "RB",
        "RT",
        "Start",
        "Menu"
    };

    private void Awake()
    {
        _overlays = new Dictionary<string, GameObject>();
        foreach (var buttonName in _buttonNames)
        {
            _overlays[buttonName] = GameObject.Find(buttonName);
            _overlays[buttonName].SetActive(false);
            _overlays[buttonName].GetComponent<SpriteRenderer>().color = overlayColor;
        }
    }

    private void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.Log("No gamepad found.");
            return;
        }

        _overlays["A"].SetActive(gamepad[GamepadButton.South].isPressed);
        _overlays["B"].SetActive(gamepad[GamepadButton.East].isPressed);
        _overlays["X"].SetActive(gamepad[GamepadButton.West].isPressed);
        _overlays["Y"].SetActive(gamepad[GamepadButton.North].isPressed);
        
        _overlays["Back"].SetActive(gamepad[GamepadButton.Select].isPressed);
        _overlays["Start"].SetActive(gamepad[GamepadButton.Start].isPressed);
        
        _overlays["DP_DOWN"].SetActive(gamepad[GamepadButton.DpadDown].isPressed);
        _overlays["DP_LEFT"].SetActive(gamepad[GamepadButton.DpadLeft].isPressed);
        _overlays["DP_RIGHT"].SetActive(gamepad[GamepadButton.DpadRight].isPressed);
        _overlays["DP_UP"].SetActive(gamepad[GamepadButton.DpadUp].isPressed);
        
        _overlays["LB"].SetActive(gamepad[GamepadButton.LeftShoulder].isPressed);
        _overlays["RB"].SetActive(gamepad[GamepadButton.RightShoulder].isPressed);
        _overlays["LT"].SetActive(gamepad[GamepadButton.LeftTrigger].isPressed);
        _overlays["RT"].SetActive(gamepad[GamepadButton.RightTrigger].isPressed);
        
        _overlays["LA_DOWN"].SetActive(gamepad.leftStick.down.isPressed);
        _overlays["LA_LEFT"].SetActive(gamepad.leftStick.left.isPressed);
        _overlays["LA_RIGHT"].SetActive(gamepad.leftStick.right.isPressed);
        _overlays["LA_UP"].SetActive(gamepad.leftStick.up.isPressed);
        
        _overlays["RA_DOWN"].SetActive(gamepad.rightStick.down.isPressed);
        _overlays["RA_LEFT"].SetActive(gamepad.rightStick.left.isPressed);
        _overlays["RA_RIGHT"].SetActive(gamepad.rightStick.right.isPressed);
        _overlays["RA_UP"].SetActive(gamepad.rightStick.up.isPressed);
        
        gamepad.SetMotorSpeeds(leftMotorSlider.value, rightMotorSlider.value);
    }

    public void doQuit()
    {
        Application.Quit();
    }
}
