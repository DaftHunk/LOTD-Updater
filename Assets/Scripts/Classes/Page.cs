using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Page
{
    [SerializeField]
    private string mainTitle;
    [SerializeField]
    private string secondaryTitle;
    [SerializeField]
    private int index;
    [SerializeField]
    private List<Category> content = new List<Category>();
    [SerializeField]
    private Status status;

    public string MainTitle { get => mainTitle; set => mainTitle = value; }
    public string SecondaryTitle { get => secondaryTitle; set => secondaryTitle = value; }
    public int Index { get => index; set => index = value; }
    public List<Category> Content { get => content; set => content = value; }
    public Status Status { get => status; set => status = value; }
}
