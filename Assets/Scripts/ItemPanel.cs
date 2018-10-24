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

        [SerializeField]
        Button panelButton;

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
            DisplayButtonText();

        }

        public void UnlockItem()
        {
            int starCount = PlayerPreferences.CurrentPlayerPreferences.GetStars();
            PurchaseItemIfEnoughStars(starCount);
        }

        private void DisplayButtonText()
        {
            if (itemData.IsUnlocked && !itemData.ItemSprite)
            {
                cost.text = "Unlocked";
                panelButton.enabled = false;
            }
            else if (itemData.IsUnlocked && Rocket.rocketSprite != itemData.ItemSprite)
            {
                cost.text = "Equip";
                panelButton.enabled = true;
            }
            else if (itemData.IsUnlocked && Rocket.rocketSprite == itemData.ItemSprite)
            {
                cost.text = "Equipped";
                panelButton.enabled = false;
            }
            else
            {
                cost.text = "Buy: " + itemData.Cost;
                panelButton.enabled = true;
            }
        }

        private void PurchaseItemIfEnoughStars(int starCount)
        {
            if (itemData.IsUnlocked)
            {
                Rocket.rocketSprite = itemData.ItemSprite;
                return;
            }
            if (starCount > itemData.Cost)
            {
                Rocket.rocketSprite = itemData.ItemSprite;
                itemData.IsUnlocked = true;
                PlayerPreferences.CurrentPlayerPreferences.AddStars(-itemData.Cost);
                Store.CurrentStore.UpdateAvailableStars();
            }
            else
            {
                Debug.Log("You don't have enough Stars");
            }
        }
    } 
}
