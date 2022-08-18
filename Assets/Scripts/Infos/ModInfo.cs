using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModInfo : MonoBehaviour
{
    public TMP_InputField mainTitle;
    public TMP_InputField secondaryTitle;
    public TMP_InputField comment;

    [SerializeField]
    private Mod mod = new Mod();

    public Mod Mod { get => mod; set => mod = value; }

    private void Start()
    {
        Toolbox.TMPCaretInteractionToggle(mainTitle, false);
        Toolbox.TMPCaretInteractionToggle(secondaryTitle, false);
        Toolbox.TMPCaretInteractionToggle(comment, false);
    }

    public void ToggleEditMode()
    {
        TMPToggle(!mainTitle.interactable);
    }

    private void TMPToggle(bool isEnabled)
    {
        Toolbox.TMPInputInteractionToggle(mainTitle, isEnabled);
        Toolbox.TMPInputInteractionToggle(secondaryTitle, isEnabled);
        Toolbox.TMPInputInteractionToggle(comment, isEnabled);
    }

    
}
