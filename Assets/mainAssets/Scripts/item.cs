using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class item : MonoBehaviour
{
    private Button thisButton;
    private Image thisImage;
    public cacheItem globalCacheItem;
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisImage = GetComponent<Image>();
        thisButton.onClick.AddListener(imageClick);
    }
    void imageClick ()
    {
        globalCacheItem.item = thisImage;
    }
}
