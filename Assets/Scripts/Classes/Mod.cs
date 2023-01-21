using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mod
{
    [SerializeField]
    private string mainTitle;
    [SerializeField]
    private string secondaryTitle;
    [SerializeField]
    private int order;
    [SerializeField]
    private string description;
    // We use a SerializeReference to avoid circular reference
    [SerializeReference]
    private Category category;
    [SerializeField]
    private ActionType actionType;
    [SerializeField]
    private Status status;

    public string MainTitle { get => mainTitle; set => mainTitle = value; }
    public string SecondaryTitle { get => secondaryTitle; set => secondaryTitle = value; }
    public int Order { get => order; set => order = value; }
    public string Description { get => description; set => description = value; }
    public Category Category { get => category; set => category = value; }
    public ActionType ActionType { get => actionType; set => actionType = value; }
    public Status Status { get => status; set => status = value; }
}
