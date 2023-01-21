using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModInfo : MonoBehaviour
{
    public TMP_InputField MainTitle;
    public TMP_InputField SecondaryTitle;
    public TMP_InputField Description;

    public CategoryInfo CategoryInfo;

    [SerializeField]
    private Mod mod = new Mod();

    public Mod Mod { get => mod; set => mod = value; }

    public void Initiate(Mod mod, CategoryInfo categoryInfo)
    {
        Toolbox.TMPCaretInteractionToggle(MainTitle, false);
        Toolbox.TMPCaretInteractionToggle(SecondaryTitle, false);
        Toolbox.TMPCaretInteractionToggle(Description, false);

        Mod = mod;
        CategoryInfo = categoryInfo;

        MainTitle.text = Mod.MainTitle;
        SecondaryTitle.text = Mod.SecondaryTitle;
        Description.text = Mod.Description;
        this.name = "Mod_" + Mod.MainTitle;
    }

    public void ToggleEditMode()
    {
        TMPToggle(!MainTitle.interactable);
        if (!MainTitle.interactable)
        {
            Mod.MainTitle = MainTitle.text;
            Mod.SecondaryTitle = SecondaryTitle.text;
            Mod.Description = Description.text;
            this.name = "Mod_" + Mod.MainTitle;
        }
    }

    public void ChangeStatus(bool isLeft)
    {
        switch (Mod.Status)
        {
            case Status.Todo:
                Mod.Status = isLeft ? Status.Done : Status.Doing;
                break;
            case Status.Doing:
                Mod.Status = isLeft ? Status.Todo : Status.Testing;
                break;
            case Status.Testing:
                Mod.Status = isLeft ? Status.Doing : Status.Done;
                break;
            case Status.Done:
                Mod.Status = isLeft ? Status.Testing : Status.Todo;
                break;
        }
        PageInfo pageInfo = ModManager.Instance.PagesInfo
            .Find(x => x.Status == Mod.Status && x.Page == CategoryInfo.PageInfo.Page);
        CategoryInfo categoryInfo = pageInfo.CategoriesInfo
            .Find(x => x.Category == CategoryInfo.Category);
        TypeInfo typeInfo = categoryInfo.TypeInfos
            .Find(x => x.ActionType == Mod.ActionType);
        this.transform.SetParent(typeInfo.ContentParent);
    }

    public void ChangeType(bool isUp)
    {
        switch (Mod.ActionType)
        {
            case ActionType.Added:
                Mod.ActionType = isUp ? ActionType.Deleted : ActionType.Updated;
                break;
            case ActionType.Updated:
                Mod.ActionType = isUp ? ActionType.Added : ActionType.Moved;
                break;
            case ActionType.Moved:
                Mod.ActionType = isUp ? ActionType.Updated : ActionType.Deleted;
                break;
            case ActionType.Deleted:
                Mod.ActionType = isUp ? ActionType.Moved : ActionType.Added;
                break;
        }
        this.transform.SetParent(CategoryInfo.GetModTypeParent(Mod.ActionType));
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
            Description,
            isEnabled,
            InputType.Comment);
    }
}
