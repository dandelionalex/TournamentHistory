using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Config
{
    [CreateAssetMenu(fileName = "IconsList", menuName = "ScriptableObjects/IconsList", order = 1)]
    public class IconsList : ScriptableObject
    {
        public List<IconItem> icons;

        public Sprite GetIcon(string id)
        {
            var icon = icons.FirstOrDefault(i => i.Id == id);
            if(icon == null)
                return icons[0].Icon;

            return icon.Icon;
        }

        [Serializable]
        public class IconItem
        {
            public string Id;
            public Sprite Icon;
        }
    }
}
