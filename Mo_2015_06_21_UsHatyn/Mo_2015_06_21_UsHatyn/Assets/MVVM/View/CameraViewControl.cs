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
            public bool isMiniPanelVisible = false;
            public void ShowMiniPanel(float percentX, float percentY, string titleText, string imageSource, string panelText)
            {
                HideMiniPanel();

                if (percentX <= 50f && percentY <= 50f)
                {
                    leftBottomSetAboutPanelText(titleText);
                    setLeftBottomPosition(percentX, percentY);
                    leftBottomShowMiniPanel();
                }
                if (percentX > 50f && percentY <= 50f)
                {
                    rightBottomSetAboutPanelText(titleText);
                    setRightBottomPosition(percentX, percentY);
                    rightBottomShowMiniPanel();
                }
                if (percentX <= 50f && percentY > 50f)
                {
                    leftTopSetAboutPanelText(titleText);
                    setLeftTopPosition(percentX, percentY);
                    leftTopShowMiniPanel();
                }
                if (percentX > 50f && percentY > 50f)
                {
                    rightTopSetAboutPanelText(titleText);
                    setRightTopPosition(percentX, percentY);
                    rightTopShowMiniPanel();
                }
                
                Texture2D  texture = UnityEngine.Resources.Load("Images/" + imageSource) as Texture2D;
                if (texture != null)
                {
                    TextureSource source = new TextureSource(texture);
                    CameraViewControl.Instance.rightPanelImage.Source = source;
                    CameraViewControl.Instance.leftPanelImage.Source = source;
                }
                else
                {
                    texture = UnityEngine.Resources.Load("Images/Objects/splashImage") as Texture2D;
                    TextureSource source = new TextureSource(texture);
                    CameraViewControl.Instance.rightPanelImage.Source = source;
                    CameraViewControl.Instance.leftPanelImage.Source = source;
                }

                CameraViewControl.Instance.rightPanelTextBlock.Text = panelText;
                CameraViewControl.Instance.leftPanelTextBlock.Text = panelText;
                                
                CameraViewControl.Instance.rightPanelTitleTextBlock.Text = titleText;
                CameraViewControl.Instance.leftPanelTitleTextBlock.Text = titleText;

                isMiniPanelVisible = true;
            }
            public void HideMiniPanel()
            {
                if (CameraViewControl.Instance.leftTopAboutPanelGrid.Visibility == Visibility.Visible)
                {
                    leftTopHideMiniPanel();
                }
                if (CameraViewControl.Instance.leftBottomAboutPanelGrid.Visibility == Visibility.Visible)
                {
                    leftBottomHideMiniPanel();
                }
                if (CameraViewControl.Instance.rightTopAboutPanelGrid.Visibility == Visibility.Visible)
                {
                    rightTopHideMiniPanel();
                }
                if (CameraViewControl.Instance.rightBottomAboutPanelGrid.Visibility == Visibility.Visible)
                {
                    rightBottomHideMiniPanel();
                }
                isMiniPanelVisible = false;
            }
            public void ChangeMiniPanelPosition(float percentX, float percentY)
            {
                if (CameraViewControl.Instance.leftTopAboutPanelGrid.Visibility == Visibility.Hidden &&
                    CameraViewControl.Instance.leftBottomAboutPanelGrid.Visibility == Visibility.Hidden &&
                    CameraViewControl.Instance.rightTopAboutPanelGrid.Visibility == Visibility.Hidden &&
                    CameraViewControl.Instance.rightBottomAboutPanelGrid.Visibility == Visibility.Hidden)
                {
                    return;
                }
                if (CameraViewControl.Instance.leftTopAboutPanelGrid.Visibility == Visibility.Visible)
                {
                    setLeftTopPosition(percentX, percentY);
                    return;
                }
                else
                if (CameraViewControl.Instance.leftBottomAboutPanelGrid.Visibility == Visibility.Visible)
                {
                    setLeftBottomPosition(percentX, percentY);
                    return;
                }
                else
                if (CameraViewControl.Instance.rightTopAboutPanelGrid.Visibility == Visibility.Visible)
                {
                    setRightTopPosition(percentX, percentY);
                    return;
                }
                else
                if (CameraViewControl.Instance.rightBottomAboutPanelGrid.Visibility == Visibility.Visible)
                {
                    setRightBottomPosition(percentX, percentY);
                    return;
                }
            }

            private void leftTopShowMiniPanel()
            {
                CameraViewControl.Instance.leftTopAboutPanelShow.Begin();
            }
            private void leftTopHideMiniPanel()
            {
                CameraViewControl.Instance.leftTopAboutPanelHide.Begin();
            }
            private void leftTopSetAboutPanelText(string text)
            {
                text = convertText(text);
                CameraViewControl.Instance.leftTopAboutPanelTextBlock.Text = text;
                int maxWord = lengthOfMaxWord(text);
                int count = countOfWords(text);
                if (maxWord > 8)
                {
                    CameraViewControl.Instance.leftTop.Width = 136.667f + (maxWord - 8) * 14;
                }
                else
                {
                    CameraViewControl.Instance.leftTop.Width = 136.667f;
                }
                CameraViewControl.Instance.leftTop.Height = 123 + 22 * (count - 1);
            }
            private void setLeftTopPosition(float percentX, float percentY)
            {
                CameraViewControl.Instance.leftTopAboutPanelGrid.Width = 1280f * percentX / 100f;
                CameraViewControl.Instance.leftTopAboutPanelGrid.Height = 800f - 800f * percentY / 100f;
            }
            
            private void leftBottomShowMiniPanel()
            {
                CameraViewControl.Instance.leftBottomAboutPanelShow.Begin();
            }
            private void leftBottomHideMiniPanel()
            {
                CameraViewControl.Instance.leftBottomAboutPanelHide.Begin();
            }
            private void leftBottomSetAboutPanelText(string text)
            {
                text = convertText(text);
                CameraViewControl.Instance.leftBottomAboutPanelTextBlock.Text = text;
                int maxWord = lengthOfMaxWord(text);
                int count = countOfWords(text);
                if (maxWord > 8)
                {
                    CameraViewControl.Instance.leftBottom.Width = 136.667f + (maxWord - 8) * 14;
                }
                else
                {
                    CameraViewControl.Instance.leftBottom.Width = 136.667f;
                }
                CameraViewControl.Instance.leftBottom.Height = 123 + 22 * (count - 1);
            }
            private void setLeftBottomPosition(float percentX, float percentY)
            {
                CameraViewControl.Instance.leftBottomAboutPanelGrid.Width = 1280f * percentX / 100f;
                CameraViewControl.Instance.leftBottomAboutPanelGrid.Height = 800f - ( 800f * percentY / 100f + CameraViewControl.Instance.leftBottom.Height + 17);
            }

            private void rightTopShowMiniPanel()
            {
                CameraViewControl.Instance.rightTopAboutPanelShow.Begin();
            }
            private void rightTopHideMiniPanel()
            {
                CameraViewControl.Instance.rightTopAboutPanelHide.Begin();
            }
            private void rightTopSetAboutPanelText(string text)
            {
                text = convertText(text);
                CameraViewControl.Instance.rightTopAboutPanelTextBlock.Text = text;
                int maxWord = lengthOfMaxWord(text);
                int count = countOfWords(text);
                if (maxWord > 8)
                {
                    CameraViewControl.Instance.rightTop.Width = 136.667f + (maxWord - 8) * 14;
                }
                else
                {
                    CameraViewControl.Instance.rightTop.Width = 136.667f;
                }
                CameraViewControl.Instance.rightTop.Height = 123 + 22 * (count - 1);
            }
            private void setRightTopPosition(float percentX, float percentY)
            {
                CameraViewControl.Instance.rightTopAboutPanelGrid.Width = 1280f * percentX / 100f - CameraViewControl.Instance.rightTop.Width + 17;
                CameraViewControl.Instance.rightTopAboutPanelGrid.Height = 800f - 800f * percentY / 100f;
            }

            private void rightBottomShowMiniPanel()
            {
                CameraViewControl.Instance.rightBottomAboutPanelShow.Begin();
            }
            private void rightBottomHideMiniPanel()
            {
                CameraViewControl.Instance.rightBottomAboutPanelHide.Begin();
            }
            private void rightBottomSetAboutPanelText(string text)
            {
                text = convertText(text);
                CameraViewControl.Instance.rightBottomAboutPanelTextBlock.Text = text;
                int maxWord = lengthOfMaxWord(text);
                int count = countOfWords(text);
                if (maxWord > 8)
                {
                    CameraViewControl.Instance.rightBottom.Width = 136.667f + (maxWord - 8) * 14;
                }
                else
                {
                    CameraViewControl.Instance.rightBottom.Width = 136.667f;
                }
                CameraViewControl.Instance.rightBottom.Height = 123 + 22 * (count - 1);
            }
            private void setRightBottomPosition(float percentX, float percentY)
            {
                CameraViewControl.Instance.rightBottomAboutPanelGrid.Width = 1280f * percentX / 100f - CameraViewControl.Instance.rightBottom.Width + 17;
                CameraViewControl.Instance.rightBottomAboutPanelGrid.Height = 800f - (800f * percentY / 100f + CameraViewControl.Instance.rightBottom.Height + 17);
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
            public void SetMarkerPosition(float percentX, float percentY)
            {
                CameraViewControl.Instance.markerGrid.Width = 1280f * percentX / 100f + 100f;
                CameraViewControl.Instance.markerGrid.Height = 100f + 800f - 800f * percentY / 100f;
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

        /*-----LEFT TOP-------*/
        private Grid leftTopAboutPanelGrid;
        private Grid leftTop;
        private TextBlock leftTopAboutPanelTextBlock;
        private Storyboard leftTopAboutPanelShow;
        private Storyboard leftTopAboutPanelHide;
        /*-----LEFT BOTTOM-------*/
        private Grid leftBottomAboutPanelGrid;
        private Grid leftBottom;
        private TextBlock leftBottomAboutPanelTextBlock;
        private Storyboard leftBottomAboutPanelShow;
        private Storyboard leftBottomAboutPanelHide;
        /*-----RIGHT TOP-------*/
        private Grid rightTopAboutPanelGrid;
        private Grid rightTop;
        private TextBlock rightTopAboutPanelTextBlock;
        private Storyboard rightTopAboutPanelShow;
        private Storyboard rightTopAboutPanelHide;
        /*-----RIGHT BOTTOM-------*/
        private Grid rightBottomAboutPanelGrid;
        private Grid rightBottom;
        private TextBlock rightBottomAboutPanelTextBlock;
        private Storyboard rightBottomAboutPanelShow;
        private Storyboard rightBottomAboutPanelHide;

        private Storyboard smallRightPanelShow;
        private Storyboard smallLeftPanelShow;
        public bool isInfoPanelShow = false;
        private Button CloseSmallRightPanelButton;
        private Button CloseSmallLeftPanelButton;
        public bool isRightPanelShow = false;
        public bool isLeftPanelShow = false;

        private Image rightPanelImage;
        private Image leftPanelImage;
        private TextBlock rightPanelTextBlock;
        private TextBlock leftPanelTextBlock;
        private TextBlock rightPanelTitleTextBlock;
        private TextBlock leftPanelTitleTextBlock;
       
        public MiniPanel MiniPanelObject;
        public Marker MarkerObject;
        private Grid markerGrid;

        private TextBox searchTextBox;
        private StackPanel searchStackPanel;

        private Image AEBImage;

        private List<Button> ListOfButtons = new List<Button>();
        private MainController mainController = Camera.main.GetComponent<MainController>();

        private bool is27JuneVisible = true;

        public void OnPostInit()
        {
            leftTopAboutPanelGrid = FindName("LeftTopAboutPanelGrid") as Grid;
            leftTop = FindName("LeftTop") as Grid;
            leftTopAboutPanelTextBlock = FindName("LeftTopAboutPanelTextBlock") as TextBlock;
            leftTopAboutPanelShow = FindResource("LeftTopAboutPanelShow") as Storyboard;
            leftTopAboutPanelHide = FindResource("LeftTopAboutPanelHide") as Storyboard;

            leftBottomAboutPanelGrid = FindName("LeftBottomAboutPanelGrid") as Grid;
            leftBottom = FindName("LeftBottom") as Grid;
            leftBottomAboutPanelTextBlock = FindName("LeftBottomAboutPanelTextBlock") as TextBlock;
            leftBottomAboutPanelShow = FindResource("LeftBottomAboutPanelShow") as Storyboard;
            leftBottomAboutPanelHide = FindResource("LeftBottomAboutPanelHide") as Storyboard;

            rightTopAboutPanelGrid = FindName("RightTopAboutPanelGrid") as Grid;
            rightTop = FindName("RightTop") as Grid;
            rightTopAboutPanelTextBlock = FindName("RightTopAboutPanelTextBlock") as TextBlock;
            rightTopAboutPanelShow = FindResource("RightTopAboutPanelShow") as Storyboard;
            rightTopAboutPanelHide = FindResource("RightTopAboutPanelHide") as Storyboard;

            rightBottomAboutPanelGrid = FindName("RightBottomAboutPanelGrid") as Grid;
            rightBottom = FindName("RightBottom") as Grid;
            rightBottomAboutPanelTextBlock = FindName("RightBottomAboutPanelTextBlock") as TextBlock;
            rightBottomAboutPanelShow = FindResource("RightBottomAboutPanelShow") as Storyboard;
            rightBottomAboutPanelHide = FindResource("RightBottomAboutPanelHide") as Storyboard;

            markerGrid = FindName("MarkerGrid") as Grid;

            smallRightPanelShow = FindResource("SmallRightPanelShow") as Storyboard;
            smallLeftPanelShow = FindResource("SmallLeftPanelShow") as Storyboard;

            CloseSmallRightPanelButton = FindName("CloseSmallRightPanelButton") as Button;
            CloseSmallLeftPanelButton = FindName("CloseSmallLeftPanelButton") as Button;

            CloseSmallRightPanelButton.Click += CloseInfoPanelButtonClick;
            CloseSmallLeftPanelButton.Click += CloseInfoPanelButtonClick;

            leftTop.MouseDown += leftMiniPanel_MouseDown;
            leftBottom.MouseDown += leftMiniPanel_MouseDown;
            rightTop.MouseDown += rightMiniPanel_MouseDown;
            rightBottom.MouseDown += rightMiniPanel_MouseDown;

            rightPanelImage = FindName("RightPanelImage") as Image;
            leftPanelImage = FindName("LeftPanelImage") as Image;

            rightPanelTextBlock = FindName("RightPanelTextBlock") as TextBlock;
            leftPanelTextBlock = FindName("LeftPanelTextBlock") as TextBlock;

            rightPanelTitleTextBlock = FindName("RightPanelTitleTextBlock") as TextBlock;
            leftPanelTitleTextBlock = FindName("LeftPanelTitleTextBlock") as TextBlock;

            searchStackPanel = FindName("searchStackPanel") as StackPanel;
            searchTextBox = FindName("textBox") as TextBox;

            searchTextBox.TextChanged += textBox_TextChanged;
            searchTextBox.LostKeyboardFocus += searchTextBox_LostKeyboardFocus;

            AEBImage = FindName("AEBImage") as Image;
            AEBImage.MouseLeftButtonDown += AEBImage_MouseLeftButtonDown;

            for (int i = 1; i <= 86; i++)
            {
                var goToProgramButton = FindName("GoToProgramButton_" + i.ToString()) as Button;
                ListOfButtons.Add(goToProgramButton);
            }

            foreach (var item in ListOfButtons)
            {
                item.Click += item_Click;
            }

            (FindName("SearchButton") as Button).Click += SearchButton_Click;
            (FindName("BackButton") as Button).Click += BackButton_Click;
            (FindName("MenuButton") as Button).Click += MenuButton_Click;
            (FindName("HistoryButton") as Button).Click += HistoryButton_Click;
            (FindName("AboutAppButton") as Button).Click += AboutAppButton_Click;
            (FindName("ProgramButton") as Button).Click += ProgramButton_Click;
            (FindName("CloseBigRightPanelButton") as Button).Click += CloseBRP_Click;
            (FindName("GoToPositionButton") as Button).Click += GoToPositionButton_Click;
            (FindName("IncreaseButton") as Button).Click += IncreaseButton_Click;
            (FindName("DecreaseButton") as Button).Click += DecreaseButton_Click;
            (FindName("_27JuneButton") as Button).Click += _27JuneButton_Click;
            (FindName("_28JuneButton") as Button).Click += _28JuneButton_Click;
            (FindName("TouchingRectangle") as Rectangle).MouseLeftButtonDown += CameraViewControl_MouseLeftButtonDown;
            (FindName("TouchingRectangle") as Rectangle).MouseLeftButtonUp +=CameraViewControl_MouseLeftButtonUp;
            (FindResource("Wait") as Storyboard).Completed += CameraViewControl_Completed;
        }

        private void CameraViewControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            (FindResource("Wait") as Storyboard).Begin();
        }

        void CameraViewControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mainController.flag = true;
            mainController.touch = Input.touches[0];
            mainController.prevPosition = mainController.touch.position;
            mainController.tapTimer = 0;
        }

        void CameraViewControl_Completed(object sender, TimelineEventArgs e)
        {
            mainController.flag = false;
        }

        private void _28JuneButton_Click(object sender, RoutedEventArgs e)
        {
            if (is27JuneVisible)
            {
                (FindResource("_28JuneButtonClick") as Storyboard).Begin();
                is27JuneVisible = false;
            }
        }

        void _27JuneButton_Click(object sender, RoutedEventArgs e)
        {
            if (!is27JuneVisible)
            {
                (FindResource("_27JuneButtonClick") as Storyboard).Begin();
                is27JuneVisible = true;
            }
        }

        void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            mainController.ZoomOut();
        }

        void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            mainController.ZoomIn();
        }

        private void GoToPositionButton_Click(object sender, RoutedEventArgs e)
        {
            mainController.GoToUserPosition();
        }

        void AboutAppButton_Click(object sender, RoutedEventArgs e)
        {
            UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.About);
        }

        void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Hist);
        }

        void CloseBRP_Click(object sender, RoutedEventArgs e)
        {
            if (AppState.InAppState == AppState.EAppState.AEBMenu)
            {
                UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Menu);
                return;                       
            }
            if (AppState.InAppState == AppState.EAppState.AEBSearch)
            {
                UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Search);
                return;
            }
            UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Menu);
        }

        void ProgramButton_Click(object sender, RoutedEventArgs e)
        {
            UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Prog);
        }

        void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Menu);
        }

        void BackButton_Click(object sender, RoutedEventArgs e)
        {
            UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Main);
        }

        void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Search);
        }     

        void item_Click(object sender, RoutedEventArgs e)
        {
			if (((Button)sender).Content == null) {
				return;
			}
			int id = int.Parse( ((Button)sender).Content.ToString ()) - 1;
			mainController.TranslatetoObject (id);
        }

        void AEBImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((Image)sender).MouseLeftButtonUp += AEBImage_MouseLeftButtonUp;
        }

        void AEBImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (AppState.InAppState == AppState.EAppState.Search)
            {
                UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.AEBSearch);
            }
            if (AppState.InAppState == AppState.EAppState.Menu)
            {
                UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.AEBMenu);
            }
            (FindResource("AEBShow") as Storyboard).Begin();
        }

        void textBox_TextChanged(object sender, RoutedEventArgs e)
        {
			searchStackPanel.Children.Clear ();
			CreateTextBlockInSearch(mainController.FindByName (searchTextBox.Text));
        }

        void searchTextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Debug.Log("LostKeyboard Focus");
            if (mainController.FindByName(searchTextBox.Text).Count() == 1)
            {
                mainController.TranslatetoObject(((TextBox)sender).Text);
            }
        }

        public void CreateTextBlockInSearch(string text)
        {
            TextBlock textBlock = new TextBlock();
            Style searchTextBlockStyle = FindResource("searchTextBlockStyle") as Style;
            textBlock.Style = searchTextBlockStyle;
            textBlock.Text = text;
            searchStackPanel.Children.Add(textBlock);
            textBlock.MouseLeftButtonDown += textBlock_MouseLeftButtonDown;
            Rectangle rect = new Rectangle();
            Style rectStyle = FindResource("RectangleStyle1") as Style;
            rect.Style = rectStyle;
            searchStackPanel.Children.Add(rect);
        }

        void aebShowPanel(string imageSource, string panelText, string titleText)
        {
            Texture2D texture = UnityEngine.Resources.Load("Images/" + imageSource) as Texture2D;
            TextureSource source = new TextureSource(texture);
            CameraViewControl.Instance.rightPanelImage.Source = source;
            CameraViewControl.Instance.leftPanelImage.Source = source;

            CameraViewControl.Instance.rightPanelTextBlock.Text = panelText;
            CameraViewControl.Instance.leftPanelTextBlock.Text = panelText;

            CameraViewControl.Instance.rightPanelTitleTextBlock.Text = titleText;
            CameraViewControl.Instance.leftPanelTitleTextBlock.Text = titleText;

            if (!isInfoPanelShow)
            {
                smallRightPanelShow.Begin();
                isInfoPanelShow = true;
            }
        }

        public void CreateTextBlockInSearch(string[] text)
        {
            foreach (var word in text)
            {
                CreateTextBlockInSearch(word);
            }
        }

        void textBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            textBlock.MouseLeftButtonUp += textBlock_MouseLeftButtonUp;
        }

        void textBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            searchTextBox.Text = ((TextBlock)sender).Text;
			mainController.TranslatetoObject (((TextBlock)sender).Text);
        }

        void CloseInfoPanelButtonClick(object sender, RoutedEventArgs e)
        {
            isInfoPanelShow = false;
            if (AppState.InAppState == AppState.EAppState.Object)
            {
                UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Main);
                return;
            }
            if (AppState.InAppState == AppState.EAppState.AEBSearch)
            {
                UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Search);
                return;
            }
            if (AppState.InAppState == AppState.EAppState.AEBMenu)
            {
                UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Menu);
                return;
            }
            if (AppState.InAppState == AppState.EAppState.MenuObject)
            {
                UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Menu);
                return;
            }
            if (AppState.InAppState == AppState.EAppState.SearchObject)
            {
                UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Search);
                return;
            }
            if (isRightPanelShow)
            {
                (FindResource("SmallRightPanelHide") as Storyboard).Begin();
                isRightPanelShow = false;
                return;
            }
            if (isLeftPanelShow)
            {
                (FindResource("SmallLeftPanelHide") as Storyboard).Begin();
                isLeftPanelShow = false;
                return;
            }
        }

        void rightMiniPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isInfoPanelShow && AppState.InAppState != AppState.EAppState.Menu && AppState.InAppState != AppState.EAppState.Search)
            {
                smallLeftPanelShow.Begin();
                isInfoPanelShow = true;
                UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Object);
                isLeftPanelShow = true;
            }
            if (!isInfoPanelShow && AppState.InAppState == AppState.EAppState.Search)
            {
                smallRightPanelShow.Begin();
                isInfoPanelShow = true;
                UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.SearchObject);
                isRightPanelShow = true;
            }
            if (!isInfoPanelShow && AppState.InAppState == AppState.EAppState.Menu)
            {
                smallRightPanelShow.Begin();
                isInfoPanelShow = true;
                UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.MenuObject);
                isRightPanelShow = true;
            }
        }

        void leftMiniPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isInfoPanelShow)
            {
                smallRightPanelShow.Begin();
                isInfoPanelShow = true;
                if (AppState.InAppState == AppState.EAppState.Main)
                {
                    UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.Object);
                }
                if (AppState.InAppState == AppState.EAppState.Search)
                {
                    UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.SearchObject);
                }
                if (AppState.InAppState == AppState.EAppState.Menu)
                {
                    UnityEngine.GameObject.FindObjectOfType<AppState>().ChangeAppState(AppState.EAppState.MenuObject);
                }
                isRightPanelShow = true;
            }
        }
    }
}