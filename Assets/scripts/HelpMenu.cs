using UnityEngine;

public class HelpMenuController : MonoBehaviour
{
    public GameObject helpMenu;

    public void ToggleHelpMenu()
    {
        if (helpMenu != null)
        {
            bool isActive = !helpMenu.activeSelf;
            helpMenu.SetActive(isActive);
            Time.timeScale = isActive ? 0f : 1f;
        }
    }
}
