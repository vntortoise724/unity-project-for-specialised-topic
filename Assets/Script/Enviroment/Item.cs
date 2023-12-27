using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    public enum ItemType
    {
        Key,
        Clothes,
        Tape,
        Heart,

    }
    
    public ItemType Type;

    public Sprite GetSprite()
    {
        switch (Type)
        {
            default:
            case ItemType.Key: return ItemAssets.Instance.keySprite;
            case ItemType.Clothes: return ItemAssets.Instance.clothesSprite;
            case ItemType.Tape: return ItemAssets.Instance.tapeSprite;
            case ItemType.Heart: return ItemAssets.Instance.heartSprite;
        }
    }
}
