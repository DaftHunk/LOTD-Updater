using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class Toolbox
{
    public static void TMPCaretInteractionToggle(TMP_InputField inputField, bool isEnabled)
    {
        inputField.GetComponentInChildren<TMP_SelectionCaret>()
            .raycastTarget = isEnabled;
    }

    public static void TMPInputInteractionToggle(TMP_InputField inputField, bool isEnabled)
    {
        inputField.interactable = isEnabled;
        inputField.textComponent.raycastTarget = isEnabled;
        inputField.placeholder.raycastTarget = isEnabled;
        TMPCaretInteractionToggle(inputField, isEnabled);
    }
}
