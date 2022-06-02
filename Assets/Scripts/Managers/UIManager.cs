using System.Collections.Generic;
using UI;
using UnityEngine;
using System.Linq;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] 
        private List<WindowBase> windows; 

        public void ShowWindow<T> ()
        {
            var win = windows.FirstOrDefault(t => t.GetType() == typeof(T));
            Debug.Log($"window is {win}");

            if(win == null)
                return;

            Instantiate(win, transform, false);
        }
    }
}
