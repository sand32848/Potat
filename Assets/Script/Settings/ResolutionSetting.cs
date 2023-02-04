using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionSetting : MonoBehaviour
{
    [Header("Resolution")]
    [SerializeField] private TMP_Dropdown resolutionDropDown;
    List<int> widths = new List<int>() { 640, 800, 854, 1280, 1366, 1600, 1920, 2560, 3200, 3840 };
    List<int> heights = new List<int>() { 360, 450, 480, 720, 768, 900, 1080, 1440, 1800, 2160 };
    private void Awake()
    {
        dropDownCurrentStartResolution();
    }

    public void SetResolution(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void dropDownCurrentStartResolution()
    {
        for (int x = 0; x < widths.Count; x++)
        {
            if (Screen.width == widths[x])
            {
                for (int y = 0; y < heights.Count; y++)
                {
                    if (Screen.height == heights[y])
                    {
                        if (x == y)
                        {
                            resolutionDropDown.value = x;
                            return;
                        }
                        return;
                    }
                }
            }
        }
    }
}
