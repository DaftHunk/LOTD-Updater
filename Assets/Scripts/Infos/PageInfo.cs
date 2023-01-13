using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PageInfo : MonoBehaviour
{
    public TMP_InputField mainTitle;
    public TMP_InputField secondaryTitle;

    [SerializeField]
    private Page page = new Page();

    public Page Page { get => page; set => page = value; }

    public void AddPage()
    {
        ModManager.InstanciatePage(
            transform.parent);
    }

    private void Start()
    {
        Toolbox.TMPCaretInteractionToggle(mainTitle, false);
        Toolbox.TMPCaretInteractionToggle(secondaryTitle, false);
    }

    public void ToggleEditMode()
    {
        TMPToggle(!mainTitle.interactable);
    }

    private void TMPToggle(bool isEnabled)
    {
        Toolbox.TMPInputInteractionToggle(
            mainTitle, 
            isEnabled,
            InputType.Main);
        Toolbox.TMPInputInteractionToggle(
            secondaryTitle, 
            isEnabled,
            InputType.Secondary);
    }
}
