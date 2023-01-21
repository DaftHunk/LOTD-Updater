using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Category
{
    [SerializeField]
    private string mainTitle;
    [SerializeField]
    private string secondaryTitle;
    [SerializeField]
    private int index;
    // We use a SerializeReference to avoid circular reference
    [SerializeReference]
    private Page page;
    [SerializeField]
    private List<Mod> content = new List<Mod>();

    public string MainTitle { get => mainTitle; set => mainTitle = value; }
    public string SecondaryTitle { get => secondaryTitle; set => secondaryTitle = value; }
    public int Index { get => index; set => index = value; }
    public Page Page { get => page; set => page = value; }
    public List<Mod> Content { get => content; set => content = value; }
}
