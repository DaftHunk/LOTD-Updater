using System.Collections;
using System.Collections.Generic;
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
        ModManager.InstanciateCategory(this);
    }

    public void ToggleEditMode()
    {
        if (mainTitle.interactable)
        {
            mainTitle.interactable = false;
            secondaryTitle.interactable = false;
        }
        else
        {
            mainTitle.interactable = true;
            secondaryTitle.interactable = true;
        }
    }
}
