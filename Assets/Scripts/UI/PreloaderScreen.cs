using UnityEngine;
using TMPro;

namespace UI
{
    public class PreloaderScreen : WindowBase
    {
        [SerializeField]
        private TMP_Text description;


        public void SetDescription(string val)
        {
            description.text = val;
        }
    }
}