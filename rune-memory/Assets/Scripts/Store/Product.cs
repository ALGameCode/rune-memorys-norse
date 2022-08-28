/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Description, characteristics and basic actions of a product
/// </summary>
namespace ALGC.Store
{
    public abstract class Product : MonoBehaviour
    {
        public string productSpriteStoreRefResourceFolder = ""; //spriteRenderer.sprite = Resourcers.Load<Sprite>("folderInsideresourcesfolder/char1_0");
        public string productName = "";
        public int productId = 0;
        public string productDescription = "";
        public bool productBlocked = false;
        public int productPrice = 0;


    }
}