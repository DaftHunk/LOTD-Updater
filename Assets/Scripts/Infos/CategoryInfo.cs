using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CategoryInfo : MonoBehaviour
{
    public TMP_InputField MainTitle;
    public TMP_InputField SecondaryTitle;

    [SerializeField]
    private Category category = new Category();

    public void Start()
    {
        UpdateLabel();
        Toolbox.TMPCaretInteractionToggle(MainTitle, false);
        Toolbox.TMPCaretInteractionToggle(SecondaryTitle, false);
    }

    private void UpdateLabel()
    {
        Transform panelTitle = transform.Find("PanelTitle");
        TMP_Text title = panelTitle.gameObject.GetComponentInChildren<TMP_Text>();

        if (category.SecondaryTitle == ""
            || panelTitle == null
            || title == null)
            return;

        title.text = category.SecondaryTitle;
    }

    public Category Category { get => category; set => category = value; }

    public void AddCategory()
    {
        ModManager.InstanciateCategory(
            transform.parent);
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
