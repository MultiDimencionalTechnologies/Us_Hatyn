using UnityEngine;
using System.Collections;
using Noesis;

namespace Mo_2015_06_21_UsHatyn
{
    public class CameraViewControl : UserControl
    {
        public static CameraViewControl Instance;
        public CameraViewControl()
        {
            Instance = this;
        }

        private Grid markerGrid;

        public void OnPostInit()
        {
            markerGrid = FindName("MarkerGrid") as Grid;
        }
        
        public Vector2 GetMarkerPosition()
        {
            return new Vector2((markerGrid.Width - 100f) / 1280f * 100f, (800f - (markerGrid.Height - 100f)) / 800f * 100f);
        }

        public void SetMarkerPosition(float procentX, float procentY)
        {
            markerGrid.Width = 1280f * procentX / 100f + 100f;
            markerGrid.Height = 100f + 800f - 800f * procentY / 100f;
        }
        
    }
}