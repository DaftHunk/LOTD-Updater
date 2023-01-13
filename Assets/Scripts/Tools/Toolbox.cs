using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class Toolbox
{
    private static Color disabledColor = new(0,0,0,0);
    private static Color enabledColor = new(0, 0, 0, 40);

    public static void TMPCaretInteractionToggle(TMP_InputField inputField, bool isEnabled)
    {
        inputField.GetComponentInChildren<TMP_SelectionCaret>()
            .raycastTarget = isEnabled;
    }

    public static void TMPInputInteractionToggle(
        TMP_InputField inputField,
        bool isEnabled,
        InputType inputType = InputType.Main)
    {
        inputField.interactable = isEnabled;
        inputField.textComponent.raycastTarget = isEnabled;
        inputField.placeholder.raycastTarget = isEnabled;
        TMPCaretInteractionToggle(inputField, isEnabled);
        inputField.targetGraphic.color = isEnabled 
            ? enabledColor
            : disabledColor;
            
        if (!isEnabled)
            return;

        ResetCurrentInputs();

        switch (inputType)
        {
            case InputType.Main:
                GlobalValues.currentMainEditingInput = inputField;
                break;
            case InputType.Secondary:
                GlobalValues.currentSecondaryEditingInput = inputField;
                break;
            case InputType.Comment:
                GlobalValues.currentCommentEditingInput = inputField;
                break;
            default:
                break;
        }
    }

    private static void ResetCurrentInputs()
    {
        foreach(InputType type in Enum.GetValues(typeof(InputType)))
        {
            TMP_InputField currentEditingInput = null;
            switch (type)
            {
                case InputType.Main:
                    currentEditingInput = GlobalValues.currentMainEditingInput;
                    GlobalValues.currentMainEditingInput = null;
                    break;
                case InputType.Secondary:
                    currentEditingInput = GlobalValues.currentSecondaryEditingInput;
                    GlobalValues.currentSecondaryEditingInput = null;
                    break;
                case InputType.Comment:
                    currentEditingInput = GlobalValues.currentCommentEditingInput;
                    GlobalValues.currentCommentEditingInput = null;
                    break;
            }
            if (currentEditingInput == null) return;

            TMPInputInteractionToggle(
                currentEditingInput,
                false);
        }

        
    }
}
