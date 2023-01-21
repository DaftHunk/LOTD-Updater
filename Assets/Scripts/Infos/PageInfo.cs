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
    public List<CategoryInfo> CategoriesInfo = new List<CategoryInfo>();

    public Status Status;

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
        CategoryInfo categoryInfo = StructureManager.Instance
            .InstanciateCategory(this);
        if (CategoriesInfo.Count > 1)
        {
            UpdateList(categoryInfo.Category.Index - 1);
        }
    }

    public void RemoveCategory(CategoryInfo categoryInfo)
    {
        Category category = categoryInfo.Category;
        int index = category.Index;

        Page.Content.Remove(category);
        CategoriesInfo.Remove(categoryInfo);

        if (CategoriesInfo.Count > 0)
        {
            if (Page.Content.Max(x => x.Index > index))
            {
                foreach (Category pageCategory in Page.Content
                    .Where(x => x.Index > index))
                {
                    pageCategory.Index--;
                }
            }
            else
            {
                UpdateList(index - 1);
            }
        }
        Destroy(categoryInfo.gameObject);
    }

    public void OrderCategory(bool isHigher, CategoryInfo categoryInfo)
    {
        int currentIndex = categoryInfo.Category.Index;

        if (isHigher)
        {
            foreach (Category category in Page.Content
                .OrderBy(x => x.Index))
            {
                if (category.Index + 1 == currentIndex)
                {
                    category.Index++;
                    break;
                }
            }
            categoryInfo.Category.Index--;
            categoryInfo.ToggleOrder();
            categoryInfo.transform.SetSiblingIndex(
                categoryInfo.transform.GetSiblingIndex() - 1);
        }
        else
        {
            foreach (Category category in Page.Content
                .OrderBy(x => x.Index))
            {
                if (category.Index - 1 == currentIndex)
                {
                    category.Index--;
                    break;
                }
            }
            categoryInfo.Category.Index++;
            categoryInfo.ToggleOrder();
            categoryInfo.transform.SetSiblingIndex(
                categoryInfo.transform.GetSiblingIndex() + 1);
        }
        UpdateList(currentIndex);
    }

    private void UpdateList(int index)
    {
        CategoriesInfo
            .Find(x => x.Category.Index == index)
            .ToggleOrder();
        Page.Content = Page.Content
            .OrderBy(x => x.Index)
            .ToList();
    }

    public void ToggleEditMode()
    {
        TMPToggle(!MainTitle.interactable);
    }

    public void OrderCategory(CategoryInfo categoryInfo)
    {
        if (Page.Content.Count <= 1)
        {
            categoryInfo.Category.Index = 0;
        }
        else if (categoryInfo.Category.Index == 0)
        {
            categoryInfo.Category.Index = Page.Content.Max(x => x.Index) + 1;
        }
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
