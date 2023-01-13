using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeInfo : MonoBehaviour
{
    [SerializeField]
    private ActionType actionType;

    public ActionType ActionType { get => actionType; set => actionType = value; }

    private void Start()
    {
        actionType = gameObject.name switch
        {
            "TypeAdd" => ActionType.Added,
            "TypeUpdate" => ActionType.Updated,
            "TypeMoved" => ActionType.Moved,
            "TypeDelete" => ActionType.Deleted,
            _ => ActionType.Updated
        };
    }

    public void AddMod()
    {
        ModManager.InstanciateMod(this);
    }
}
