using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class Rocket : MonoBehaviour
    {

        public static int starsCollected = 0;

        [SerializeField]
        Vector2Constant startPos;

        [SerializeField]
        Sprite defaultSprite;

        [SerializeField]
        Event onRocketDestroyed;

        #region SINGLETON

        private static Rocket instance;
        private static readonly object padlock = new object();
        public static Rocket Instance
        {
            get
            {
                lock (padlock)
                {
                    if (!instance)
                    {
                        instance = FindObjectOfType<Rocket>();
                    }
                    return instance;
                }
            }
        } 

        #endregion

        private void OnEnable()
        {
            transform.position = startPos.Value;
        }

        public Sprite GetActiveSprite()
        {
            Sprite activeSprite = GetComponentInChildren<SpriteRenderer>().sprite;
            if (!activeSprite) { return null; }
            return activeSprite;
        }

        public Sprite GetDefaultSprite()
        {
            if (!defaultSprite) { return null; }
            return defaultSprite;
        }

        public void SetActiveSprite(Sprite spriteToSet)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = spriteToSet;
        }

        public void DestroyRocket()
        {
            gameObject.SetActive(false);
            starsCollected = 0;
            onRocketDestroyed.Raise();
        }

        public void AddItem(GameObject itemToAdd)
        {
            HandleLaserCannonItem(itemToAdd);
        }

        private void HandleLaserCannonItem(GameObject itemToAdd)
        {         
            if (CanRocketEquipItem(itemToAdd))
            {
                GameObject itemInstance = Instantiate(itemToAdd);
                itemInstance.transform.parent = transform;  
            }
            else
            {
                GetComponentInChildren<LaserCannon>().AddAmmo();
            }
        }

        private bool CanRocketEquipItem(GameObject itemToAdd)
        {
            if (!GetComponentInChildren<LaserCannon>()
                      || itemToAdd.GetComponent<EDT>()
                      || itemToAdd.GetComponent<TDD>())
            {
                return true;
            }
            return false;
        }

        public void AddStar()
        {
            starsCollected++;
        }

    } 
}
