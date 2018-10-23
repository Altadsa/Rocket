using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Rocket
{
    public class ItemPanel : MonoBehaviour
    {

        #region VARIABLES

        ItemData itemData;

        [SerializeField]
        Image image;

        [SerializeField]
        Text title;

        [SerializeField]
        Text description;

        [SerializeField]
        Text cost; 

        #endregion

        public void Setup(ItemData data)
        {
            itemData = data;
            LoadItemData();
        }

        private void LoadItemData()
        {
            image.sprite = itemData.ItemSprite;
            title.text = itemData.ItemTitle;
            description.text = itemData.ItemDescription;
            cost.text = "Buy: " + itemData.Cost;

        }

        public void UnlockItem()
        {
            int starCount = PlayerPreferences.CurrentPlayerPreferences.GetStars();
            PurchaseItemIfEnoughStars(starCount);
        }

        private void DisplayButtonText()
        {
            
        }

        private void PurchaseItemIfEnoughStars(int starCount)
        {
            if (starCount > itemData.Cost)
            {
                Rocket.rocketSprite = itemData.ItemSprite;
            }
            else
            {
                Debug.Log("You don't have enough Stars");
            }
        }
    } 
}
