using UnityEngine;

namespace Rocket
{
    [CreateAssetMenu(menuName = "Rocket/Item Data")]
    public class ItemData : ScriptableObject
    {

        #region VARIABLES
        [SerializeField]
        Sprite itemSprite;

        [SerializeField]
        string itemTitle;

        [TextArea(2, 5)]
        [SerializeField]
        string itemDescription;

        [SerializeField]
        int cost;

        [SerializeField]
        StringConstant prefsKey;

        #endregion

        #region GETTER FUNCTIONS

        public Sprite ItemSprite { get { return itemSprite; } }
        public string ItemTitle { get { return itemTitle; } }
        public string ItemDescription { get { return itemDescription; } }
        public int Cost { get { return cost; } }
        public StringConstant PrefsKey {  get { return prefsKey; } }

        #endregion

    } 
}
