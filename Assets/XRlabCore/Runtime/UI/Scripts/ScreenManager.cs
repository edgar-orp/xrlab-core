using UnityEngine;

namespace xrlab.core.UI
{
    public class ScreenManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] screens;

        private int currentScreenIndex;

        public ScreenType CurrentScreen => (ScreenType)currentScreenIndex;

        private void Start()
        {
            ShowScreen(0);
        }

        public void Next()
        {
            if (currentScreenIndex >= screens.Length - 1)
                return;

            ShowScreen(currentScreenIndex + 1);
        }

        private void ShowScreen(int index)
        {
            for (int i = 0; i < screens.Length; i++)
            {
                screens[i].SetActive(i == index);
            }

            currentScreenIndex = index;
        }
    }
}
