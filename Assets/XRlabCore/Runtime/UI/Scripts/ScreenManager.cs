using UnityEngine;

namespace xrlab.core
{
    public class ScreenManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] screens;

        private int currentScreenIndex;

        public GameObject CurrentScreen => screens[currentScreenIndex];

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

        public void Back()
        {
            if (currentScreenIndex <= 0)
                return;

            ShowScreen(currentScreenIndex - 1);
        }

        private void ShowScreen(int index)
        {
            if (index < 0 || index >= screens.Length)
                return;

            for (int i = 0; i < screens.Length; i++)
            {
                screens[i].SetActive(i == index);
            }

            currentScreenIndex = index;
        }
    }
}
