using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaMessageBox.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaMessageBox.ViewModels
{
	public class MessageBoxWindowViewModel
	{
		private MessageBoxWindow _window;

		public string Caption { get; set; }
		public string Text { get; set; }
		public bool IsNoBtnVisible { get; set; }
		public bool IsYesBtnVisible { get; set; }
		public bool IsOKBtnVisible { get; set; }
		public bool IsCancelBtnVisible { get; set; }
		public bool IsIconVisible { get; set; }
		public Bitmap Icon { get; private set; }
		public string Icon1 { get; private set; }
		public MessageBoxResult MessageBoxResult { get; set; }

		public MessageBoxWindowViewModel(MessageBoxWindow window, MessageBoxButton buttons, MessageBoxIcon icon)
		{
			_window = window;
			SetButtonsVisibility(buttons);
			SetIcon(icon);
		}

		private void SetIcon(MessageBoxIcon icon)
		{
			if (icon == MessageBoxIcon.None) return;

			IsIconVisible = true;
			var iconName = icon.ToString(); 
			var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
			Icon = new Bitmap(assets.Open(new Uri($" avares://AvaloniaMessageBox/Assets/{iconName}.ico")));
		}

		private void SetButtonsVisibility(MessageBoxButton buttons)
		{
			switch (buttons)
			{
				case MessageBoxButton.OK:
					IsOKBtnVisible = true;
					break;
				case MessageBoxButton.OkCancel:
					IsOKBtnVisible = true;
					IsCancelBtnVisible = true;
					break;
				case MessageBoxButton.YesNoCancel:
					IsCancelBtnVisible = true;
					IsNoBtnVisible = true;
					IsYesBtnVisible = true;
					break;
				case MessageBoxButton.YesNo:
					IsNoBtnVisible = true;
					IsYesBtnVisible = true;
					break;
				default:
					throw new ArgumentException();
			}
		}

		public void OkClick()
		{
			_window.MessageBoxResult = MessageBoxResult.OK;
			_window.Close();
		}

		public void YesClick()
		{
			_window.MessageBoxResult = MessageBoxResult.Yes;
			_window.Close();
		}

		public void NoClick()
		{
			_window.MessageBoxResult = MessageBoxResult.No;
			_window.Close();
		}

		public void CancelClick()
		{
			_window.MessageBoxResult = MessageBoxResult.Cancel;
			_window.Close();
		}
	}
}
