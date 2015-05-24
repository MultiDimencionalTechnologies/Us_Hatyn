#if !UNITY_EDITOR && !UNITY_STANDALONE && !UNITY_ANDROID && !UNITY_IPHONE
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mo_2015_06_21_UsHatyn
{
	/// <summary>
	/// Interaction logic for PlaneViewControl.xaml
	/// </summary>
	public partial class PlaneViewControl : UserControl
	{
		public PlaneViewControl()
		{
			this.InitializeComponent();
		}
	}
}
#endif