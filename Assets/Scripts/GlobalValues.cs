using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Status
{
    Todo,
    Doing,
    Testing,
    Done,
    Archived
}
public enum ActionType
{
    Added,
    Updated,
    Moved,
    Deleted
}

public enum InputType
{
    Main,
    Secondary,
    Comment
}

public static class GlobalValues
{
    public static TMP_InputField currentMainEditingInput;
    public static TMP_InputField currentSecondaryEditingInput;
    public static TMP_InputField currentCommentEditingInput;

    public static string StatusLabel(Status status) => status switch
    {
        Status.Todo => "Todo",
        Status.Doing => "Doing",
        Status.Testing => "Testing",
        Status.Done => "Done",
        Status.Archived => "Archived",
        _ => ""
    };
    public static string ActionTypeLabel(ActionType actionType) => actionType switch
    {
        ActionType.Added => "Ajouté",
        ActionType.Updated => "Mis à jour",
        ActionType.Moved => "Déplacé",
        ActionType.Deleted => "Supprimé",
        _ => ""
    };    
}
