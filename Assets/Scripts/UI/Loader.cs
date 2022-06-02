using UnityEngine;
using TMPro;

namespace UI
{
    public class Loader : WindowBase
    {
        [SerializeField]
        private TMP_Text description;

        public void SetDescription(string val)
        {
            description.text = val;
        }
    }
}

