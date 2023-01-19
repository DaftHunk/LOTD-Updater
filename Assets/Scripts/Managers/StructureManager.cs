using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    public Transform StructureParent;
    public GameObject PagePrefab;
    public GameObject CategoryPrefab;
    public Structure Structure;

    public List<PageInfo> PagesInfo = new List<PageInfo>();

    #region Singleton
    public static StructureManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public void StructureInitiator(Structure structure)
    {
        Structure = structure;

        foreach (Page page in Structure.Content)
        {
            GameObject pageInstance = InstanciatePage();
            PageInfo pageInfo = pageInstance.GetComponent<PageInfo>();
            pageInfo.Initiate(page);

            foreach (Category category in page.Content.OrderBy(x => x.Index))
            {
                InstanciateCategory(pageInfo, category);
            }
        }
        ModManager.Instance.UpdateModStructure();
    }

    public GameObject InstanciatePage()
    {
        GameObject pagePrefab = Instantiate(PagePrefab, StructureParent);
        PagesInfo.Add(pagePrefab.GetComponent<PageInfo>());
        return pagePrefab;
    }

    public GameObject InstanciateCategory(PageInfo pageInfo, Category category = null)
    {
        GameObject categoryPrefab = Instantiate(CategoryPrefab, pageInfo.ContentParent);
        CategoryInfo categoryInfo = categoryPrefab.GetComponent<CategoryInfo>();
        categoryInfo.PageInfo = pageInfo;

        if (category == null)
        {
            category = new Category();
            pageInfo.Page.Content.Add(category);
            categoryInfo.Initiate(category, true);
        }
        else
        {
            categoryInfo.Initiate(category);
        }
        return categoryPrefab;
    }
}
