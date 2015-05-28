using UnityEngine;
using System.Collections;
using Noesis;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Mo_2015_06_21_UsHatyn
{
    public class CameraViewControl : UserControl
    {
        public static CameraViewControl Instance;
        public CameraViewControl()
        {
            Instance = this;
            MiniPanelObject = new MiniPanel();
            MarkerObject = new Marker();
        }

        public class MiniPanel
        {
            public void ShowMiniPanel(string text)
            {
                SetAboutPanelText(text);
                CameraViewControl.Instance.aboutPanelShow.Begin();
            }
            public void HideMiniPanel()
            {
                CameraViewControl.Instance.aboutPanelHide.Begin();
            }
            private void SetAboutPanelText(string text)
            {
                text = convertText(text);
                CameraViewControl.Instance.aboutPanelTextBlock.Text = text;
                int maxWord = lengthOfMaxWord(text);
                int count = countOfWords(text);
                if (maxWord > 8)
                {
                    CameraViewControl.Instance.aboutPanelGrid.Width = 136.667f + (maxWord - 8) * 10;
                }
                else
                {
                    CameraViewControl.Instance.aboutPanelGrid.Width = 136.667f;
                }
                CameraViewControl.Instance.aboutPanelGrid.Height = 123 + 22 * (count - 1);
            }
            private int lengthOfMaxWord(string text)
            {
                int max = 0;
                string[] str = text.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i].Length > max)
                    {
                        max = str[i].Length;
                    }
                }
                return max;
            }
            private string convertText(string text)
            {
                text.Replace(" ", "&#x0a");
                return text;
            }
            private int countOfWords(string text)
            {
                string[] str = text.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return str.Length;
            }
        }
        public class Marker
        {
            public Vector2 GetMarkerPosition()
            {
                return new Vector2((CameraViewControl.Instance.markerGrid.Width - 100f) / 1280f * 100f, (800f - (CameraViewControl.Instance.markerGrid.Height - 100f)) / 800f * 100f);
            }
            public void SetMarkerPosition(float procentX, float procentY)
            {
                CameraViewControl.Instance.markerGrid.Width = 1280f * procentX / 100f + 100f;
                CameraViewControl.Instance.markerGrid.Height = 100f + 800f - 800f * procentY / 100f;
            }
            public bool MarkerVisibility
            {
                get
                {
                    if (CameraViewControl.Instance.markerGrid.Visibility == Visibility.Visible)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                set
                {
                    if (value)
                    {
                        CameraViewControl.Instance.markerGrid.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        CameraViewControl.Instance.markerGrid.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        public MiniPanel MiniPanelObject;
        public Marker MarkerObject;
        private Grid markerGrid;
        private Grid aboutPanelGrid;
        private TextBlock aboutPanelTextBlock;

        private TextBox testTextBox;
        private Button testButton;
        private Button bla;

        private Storyboard aboutPanelShow;
        private Storyboard aboutPanelHide;

        public void OnPostInit()
        {
            markerGrid = FindName("MarkerGrid") as Grid;
            aboutPanelGrid = FindName("AboutPanelGrid") as Grid;
            aboutPanelTextBlock = FindName("AboutPanelTextBlock") as TextBlock;

            testTextBox = FindName("testTextBox") as TextBox;
            testButton = FindName("testButton") as Button;
            testButton.Click += testButton_Click;
            bla = FindName("bla") as Button;
            bla.Click += bla_Click;

            aboutPanelShow = FindResource("AboutPanelShow") as Storyboard;
            aboutPanelHide = FindResource("AboutPanelHide") as Storyboard;
        }

        void bla_Click(object sender, RoutedEventArgs e)
        {
            MiniPanelObject.HideMiniPanel();
        }

        void testButton_Click(object sender, RoutedEventArgs e)
        {
            MiniPanelObject.ShowMiniPanel(testTextBox.Text);
        }

        
    }
}