using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Rocket
{
    public class ItemPanel : MonoBehaviour
    {

        #region VARIABLES

        PlayerPreferences playerPreferences;

        ItemData itemData;

        [SerializeField]
        Image image;

        [SerializeField]
        Text title;

        [SerializeField]
        Text description;

        [SerializeField]
        Text buttonText;

        [SerializeField]
        Button panelButton;

        #endregion

        public void Setup(ItemData data)
        {
            playerPreferences = PlayerPreferences.CurrentPlayerPreferences;
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
            int starCount = playerPreferences.GetStars();
            PurchaseItemIfEnoughStars(starCount);
        }

        private void DisplayButtonText()
        {
            if (playerPreferences.GetItem(itemData.PrefsKey) == 0)
            {
                buttonText.text = string.Format("Buy: {0}", itemData.Cost);
            }
            else
            {
                if (itemData.ItemSprite == Rocket.Instance.GetActiveSprite())
                {
                    buttonText.text = "Equipped";
                }
                else
                {
                    buttonText.text = "Equip";
                }
            }
        }

        private void PurchaseItemIfEnoughStars(int starCount)
        {
            if (playerPreferences.GetItem(itemData.PrefsKey) ==  1)
            {
                Rocket.Instance.SetActiveSprite(itemData.ItemSprite);
            }
            else if (starCount > itemData.Cost)
            {
                playerPreferences.UnlockItem(itemData.PrefsKey);
                Rocket.Instance.SetActiveSprite(itemData.ItemSprite);
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
