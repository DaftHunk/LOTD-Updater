using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class ModManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject PagePrefab;
    public GameObject CategoryPrefab;
    public GameObject ModPrefab;

    public List<PageInfo> PagesInfo = new List<PageInfo>();

    [Header("Parents")]
    [SerializeField]
    private Transform todoParent;
    [SerializeField]
    private Transform doingParent;
    [SerializeField]
    private Transform testingParent;
    [SerializeField]
    private Transform doneParent;
    [SerializeField]
    private Transform archivedParent;
    [SerializeField]
    private Transform structureParent;

    #region Singleton
    public static ModManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public void UpdateModStructure()
    {
        foreach (Page page in StructureManager.Instance.Structure.Content)
        {
            InstanciatePage(page);
        }
    }

    public void InstanciatePage(Page page)
    {
        foreach (Status status in Enum.GetValues(typeof(Status)))
        {
            if (status == Status.Archived)
                continue;

            GameObject pageInfoPrefab = Instantiate(
               Instance.PagePrefab,
               StatusParent((int)status));

            PageInfo pageInfo = pageInfoPrefab.GetComponent<PageInfo>();
            pageInfo.Initiate(page);
            pageInfo.Status = status;
            PagesInfo.Add(pageInfo);

            foreach (Category category in page.Content.OrderBy(x => x.Index))
            {
                InstanciateCategory(
                    category,
                    pageInfo);
            }
        }
    }

    public void InstanciateCategory(Category category, PageInfo pageInfo)
    {
        GameObject categoryInfoPrefab = Instantiate(
            CategoryPrefab,
            pageInfo.ContentParent);

        CategoryInfo categoryInfo = categoryInfoPrefab.GetComponent<CategoryInfo>();
        categoryInfo.PageInfo = pageInfo;
        categoryInfo.Initiate(category);
        pageInfo.CategoriesInfo.Add(categoryInfo);

        foreach (Mod mod in category.Content
            .Where(x => x.Status == pageInfo.Status))
        {
            InstanciateMod(categoryInfo, mod);
        }
    }

    public void InstanciateMod(CategoryInfo categoryInfo, Mod mod)
    {
        GameObject modInfoPrefab = Instantiate(
            Instance.ModPrefab,
            categoryInfo.GetModTypeParent(mod.ActionType));

        ModInfo modInfo = modInfoPrefab.GetComponent<ModInfo>();
        modInfo.Initiate(mod, categoryInfo);
        categoryInfo.ModsInfo.Add(modInfo);
    }

    public Transform StatusParent(int status) => status switch
    {
        0 => todoParent,
        1 => doingParent,
        2 => testingParent,
        3 => doneParent,
        4 => archivedParent,
        _ => todoParent
    };
}
