using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CategoryInfo : MonoBehaviour
{
    public TMP_InputField mainTitle;
    public TMP_InputField secondaryTitle;

    [SerializeField]
    private Category category = new Category();

    public void Start()
    {
        UpdateLabel();
        Toolbox.TMPCaretInteractionToggle(mainTitle, false);
        Toolbox.TMPCaretInteractionToggle(secondaryTitle, false);
    }
    
    public void FixedUpdate()
    {

    }

    private void UpdateLabel()
    {
        Transform panelTitle = transform.Find("PanelTitle");
        TMP_Text title = panelTitle.gameObject.GetComponentInChildren<TMP_Text>();

        if (category.NameVF == ""
            || panelTitle == null
            || title == null)
            return;

        title.text = category.NameVF;
    }

    public Category Category { get => category; set => category = value; }

    public void AddCategory()
    {
        ModManager.InstanciateCategory(
            transform.parent);
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
