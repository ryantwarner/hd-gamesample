using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameplayIngredients.Interactions
{
    public class KeyInteractive : Interactive
    {
        [Header("Settings")]
        public bool hasKey = true;
        public string itemReference = "redKey";
        public float Distance = 1.0f;

        public override bool CanInteract(InteractiveUser user)
        {
            if (Vector3.Distance(user.transform.position, this.transform.position) < Distance)
            {
                return hasKey ? GameInventory.Instance.ContainsItem(itemReference) : !GameInventory.Instance.ContainsItem(itemReference);
            }
            return false;
        }
    }
}