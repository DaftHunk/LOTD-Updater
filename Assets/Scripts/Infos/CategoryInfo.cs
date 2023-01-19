using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryInfo : MonoBehaviour
{
    public TMP_InputField MainTitle;
    public TMP_InputField SecondaryTitle;

    public Button OrderUp;
    public Button OrderDown;

    public PageInfo PageInfo;

    [SerializeField]
    private Category category = new Category();

    public Category Category { get => category; set => category = value; }

    public void Initiate(Category category, bool isNew = false)
    {
        UpdateLabel();
        Toolbox.TMPCaretInteractionToggle(MainTitle, false);
        Toolbox.TMPCaretInteractionToggle(SecondaryTitle, false);

        Category = category;
        MainTitle.text = Category.MainTitle;
        SecondaryTitle.text = Category.SecondaryTitle;
        this.name = "Category_" + Category.MainTitle;

        if (isNew)
        {
            PageInfo.OrderCategory(this);
        }
        if (OrderUp != null && OrderDown != null)
        {
            ToggleOrder();
        }
    }

    public void ToggleOrder()
    {
        OrderUp.interactable = Category.Index != 0;
        if (PageInfo.Page.Content.Count == 1)
            OrderDown.interactable = false;
        else
            OrderDown.interactable = Category.Index != PageInfo.Page.Content.Max(x => x.Index);
    }

    private void UpdateLabel()
    {
        Transform panelTitle = transform.Find("PanelTitle");
        TMP_Text title = panelTitle.gameObject.GetComponentInChildren<TMP_Text>();

        if (Category.SecondaryTitle == ""
            || panelTitle == null
            || title == null)
            return;

        title.text = Category.SecondaryTitle;
    }

    public void OrderCategory(bool isHigher)
    {
        PageInfo.OrderCategory(isHigher, this);
    }

    public void DeleteCategory()
    {
        PageInfo.RemoveCategory(this);
    }

    public void ToggleEditMode()
    {
        TMPToggle(!MainTitle.interactable);
        if (!MainTitle.interactable)
        {
            Category.MainTitle = MainTitle.text;
            Category.SecondaryTitle = SecondaryTitle.text;
            this.name = "Category_" + Category.MainTitle;
        }
    }

    private void TMPToggle(bool isEnabled)
    {
        Toolbox.ResetCurrentInputs();
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
