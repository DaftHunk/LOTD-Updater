using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PageInfo : MonoBehaviour
{
    public TMP_InputField MainTitle;
    public TMP_InputField SecondaryTitle;
    public TMP_Text TitleLabel;

    public Transform ContentParent;

    [SerializeField]
    private Page page = new Page();

    public Page Page { get => page; set => page = value; }

    public void Initiate(Page page)
    {
        Page = page;
        if (MainTitle != null)
        {
            Toolbox.TMPCaretInteractionToggle(MainTitle, false);
            MainTitle.text = Page.MainTitle;
        }
        if (SecondaryTitle != null)
        {
            Toolbox.TMPCaretInteractionToggle(SecondaryTitle, false);
            SecondaryTitle.text = Page.SecondaryTitle;
        }
        if (TitleLabel != null)
            TitleLabel.text = Page.MainTitle;

        this.name = "Page_" + Page.MainTitle;
    }

    public void AddCategory()
    {
        StructureManager.Instance.InstanciateCategory(this);
    }

    public void OrderCategory(bool isHigher, CategoryInfo categoryInfo)
    {
        int currentIndex = categoryInfo.Category.Index;
        Debug.Log("#New Order for " + categoryInfo.Category.MainTitle + " : " + currentIndex + "-1");

        foreach (Category category in Page.Content.OrderBy(x => x.Index))
        {
            if (category.Index + 1 == currentIndex)
            {
                Debug.Log(category.Index + 1 + "] " + category.MainTitle);
                category.Index++;
                break;
            }
        }
        categoryInfo.Category.Index--;
        categoryInfo.ToggleOrder();
    }

    public void ToggleEditMode()
    {
        TMPToggle(!MainTitle.interactable);
    }

    public void OrderCategory(CategoryInfo categoryInfo)
    {
        Debug.Log(categoryInfo.Category.Index + "] " + categoryInfo.Category.MainTitle);
        if (Page.Content.Count == 0)
        {
            categoryInfo.Category.Index = 0;
        }
        else if (categoryInfo.Category.Index == 0)
        {
            categoryInfo.Category.Index = Page.Content.Max(x => x.Index) + 1;
        }
        Debug.Log("Is ordered " + categoryInfo.Category.Index);
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
