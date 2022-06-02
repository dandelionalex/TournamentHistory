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

        private List<WindowBase> openedWindows = new List<WindowBase>();

        public WindowBase ShowWindow<T> (WindowData data = null)
        {
            var winPrefab = windows.FirstOrDefault(t => t.GetType() == typeof(T));
            if(winPrefab == null)
                return null;

            var win =  Instantiate(winPrefab, transform, false);
            win.Init(data);

            openedWindows.Add(win);
            return win;
        }

        public void CloseWindow<T> ()
        {
            var windowInstance = openedWindows.FirstOrDefault(t => t.GetType() == typeof(T));
            if(windowInstance == null)
                return;

            openedWindows.Remove(windowInstance);
            Destroy(windowInstance.gameObject);    
        }
    }
}