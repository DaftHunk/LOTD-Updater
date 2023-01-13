using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PageInfo : MonoBehaviour
{
    public TMP_InputField MainTitle;
    public TMP_InputField SecondaryTitle;

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
        Toolbox.TMPCaretInteractionToggle(MainTitle, false);
        Toolbox.TMPCaretInteractionToggle(SecondaryTitle, false);
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
    }
}
