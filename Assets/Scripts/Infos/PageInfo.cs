using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageInfo : MonoBehaviour
{
    [SerializeField]
    private Page page = new Page();

    public Page Page { get => page; set => page = value; }
}
