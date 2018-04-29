using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilObjects;
public static class InputWrapper
{
    static string
		P1Horizontal = "P1_Horizontal_L",
		P2Horizontal = "P2_Horizontal_L",

		P1Vertical = "P1_Vertical_L",
		P2Vertical = "P2_Vertical_L", 

		P1Horizontal2 = "P1_Horizontal_R",
		P2Horizontal2 = "P2_Horizontal_R",

		P1Vertical2 = "P1_Vertical_R",
		P2Vertical2 = "P2_Vertical_R",

        P1LeftTrigger = "P1_Trigger_L",
        P2LeftTrigger = "P2_Trigger_L",

        P1RightTrigger = "P1_Trigger_R",
        P2RightTrigger = "P2_Trigger_R",

        P1LeftBumper = "P1_Bumper_L",
        P2LeftBumper = "P2_Bumper_L",

        P1RightBumper = "P1_Bumper_R",
        P2RightBumper = "P2_Bumper_R",

        P1A = "P1_A", P2A = "P2_A",
		P1B = "P1_B", P2B = "P2_B",
		P1X = "P1_X", P2X = "P2_X",
		P1Y = "P1_Y", P2Y = "P2_Y";

	public static Vector2 GetLeftInput(PlayerSlot p)
	{
		Vector2 output = Vector2.zero;
		output.x = GetHorizontalAxis(p);
		output.y = GetVerticalAxis(p);
		return output;
	}
	public static Vector2 GetRightInput(PlayerSlot p)
	{
		Vector2 output = Vector2.zero;
		output.x = GetHorizontalAxis2(p);
		output.y = GetVerticalAxis2(p);
		return output;
	}
	public static float GetHorizontalAxis(PlayerSlot p)
	{
		return Input.GetAxis((p == PlayerSlot.P1) ? P1Horizontal : P2Horizontal);
	}
	public static float GetVerticalAxis(PlayerSlot p)
	{
		return -Input.GetAxis((p == PlayerSlot.P1) ? P1Vertical : P2Vertical);
	}
	public static float GetHorizontalAxis2(PlayerSlot p)
	{
		return Input.GetAxis((p == PlayerSlot.P1) ? P1Horizontal2 : P2Horizontal2);
	}
	public static float GetVerticalAxis2(PlayerSlot p)
	{
		return -Input.GetAxis((p == PlayerSlot.P1) ? P1Vertical2 : P2Vertical2);
	}
	public static bool GetAButton(PlayerSlot p)
	{
		return Input.GetButton((p == PlayerSlot.P1) ? P1A : P2A);
	}
	public static bool GetBButton(PlayerSlot p)
	{
		return Input.GetButton((p == PlayerSlot.P1) ? P1B : P2B);
	}
	public static bool GetXButton(PlayerSlot p)
	{
		return Input.GetButton((p == PlayerSlot.P1) ? P1X : P2X);
	}
	public static bool GetYButton(PlayerSlot p)
	{
		return Input.GetButton((p == PlayerSlot.P1) ? P1Y : P2Y);
	}
	public static bool GetAButtonDown(PlayerSlot p)
	{
		return Input.GetButtonDown((p == PlayerSlot.P1) ? P1A : P2A);
	}
	public static bool GetBButtonDown(PlayerSlot p)
	{
		return Input.GetButtonDown((p == PlayerSlot.P1) ? P1B : P2B);
	}
	public static bool GetXButtonDown(PlayerSlot p)
	{
		return Input.GetButtonDown((p == PlayerSlot.P1) ? P1X : P2X);
	}
	public static bool GetYButtonDown(PlayerSlot p)
	{
		return Input.GetButtonDown((p == PlayerSlot.P1) ? P1Y : P2Y);
	}
	public static bool GetAButtonUp(PlayerSlot p)
	{
		return Input.GetButtonUp((p == PlayerSlot.P1) ? P1A : P2A);
	}
	public static bool GetBButtonUp(PlayerSlot p)
	{
		return Input.GetButtonUp((p == PlayerSlot.P1) ? P1B : P2B);
	}
	public static bool GetXButtonUp(PlayerSlot p)
	{
		return Input.GetButtonUp((p == PlayerSlot.P1) ? P1X : P2X);
	}
	public static bool GetYButtonUp(PlayerSlot p)
	{
		return Input.GetButtonUp((p == PlayerSlot.P1) ? P1Y : P2Y);
	}
    public static bool GetLeftTriggerDown(PlayerSlot p)
    {
        return Input.GetAxis((p == PlayerSlot.P1) ? P1LeftTrigger : P2LeftTrigger) > 0.0f;
    }
    public static bool GetRightTriggerDown(PlayerSlot p)
    {
        return Input.GetAxis((p == PlayerSlot.P1) ? P1RightTrigger : P2RightTrigger) > 0.0f;
    }
    public static bool GetLeftBumperDown(PlayerSlot p)
    {
        return Input.GetButton((p == PlayerSlot.P1) ? P1LeftBumper : P2LeftBumper);
    }
    public static bool GetRightBumperDown(PlayerSlot p)
    {
        return Input.GetButton((p == PlayerSlot.P1) ? P1RightBumper : P2RightBumper);
    }
}
