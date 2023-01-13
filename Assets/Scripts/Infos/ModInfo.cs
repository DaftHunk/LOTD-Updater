using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModInfo : MonoBehaviour
{
    public TMP_InputField MainTitle;
    public TMP_InputField SecondaryTitle;
    public TMP_InputField Comment;

    [SerializeField]
    private Mod mod = new Mod();

    public Mod Mod { get => mod; set => mod = value; }

    private void Start()
    {
        Toolbox.TMPCaretInteractionToggle(MainTitle, false);
        Toolbox.TMPCaretInteractionToggle(SecondaryTitle, false);
        Toolbox.TMPCaretInteractionToggle(Comment, false);
    }

    public void ToggleEditMode()
    {
        TMPToggle(!MainTitle.interactable);
    }

    private void TMPToggle(bool isEnabled)
    {
        Toolbox.TMPInputInteractionToggle(
            MainTitle,
            isEnabled,
            InputType.Main);
        Toolbox.TMPInputInteractionToggle(
            SecondaryTitle,
            isEnabled,
            InputType.Secondary);
        Toolbox.TMPInputInteractionToggle(
            Comment,
            isEnabled,
            InputType.Comment);
    }
}
