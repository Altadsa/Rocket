using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Rocket
{
    public class ItemPanel : MonoBehaviour
    {

        #region VARIABLES

        [SerializeField]
        Image image;

        [SerializeField]
        Text title;

        [SerializeField]
        Text description;

        [SerializeField]
        Text cost; 

        #endregion

        public void LoadItemData(ItemData itemData)
        {
            image.sprite = itemData.ItemSprite;
            title.text = itemData.ItemTitle;
            description.text = itemData.ItemDescription;
            cost.text = itemData.Cost.ToString();

        }

    } 
}
