using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mod
{
    [SerializeField]
    private string nameVO;
    [SerializeField]
    private string nameVF;
    [SerializeField]
    private int order;
    [SerializeField]
    private string description;
    [SerializeField]
    private Category category;
    [SerializeField]
    private ActionType actionType;

    public string NameVO { get => nameVO; set => nameVO = value; }
    public string NameVF { get => nameVF; set => nameVF = value; }
    public int Order { get => order; set => order = value; }
    public string Description { get => description; set => description = value; }
    public Category Category { get => category; set => category = value; }
    public ActionType ActionType { get => actionType; set => actionType = value; }
}
