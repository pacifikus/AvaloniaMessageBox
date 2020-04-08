using AvaloniaMessageBox.ViewModels;
using AvaloniaMessageBox.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaMessageBox
{
	public class MessageBox
	{
		public static Task<MessageBoxResult> Show(string text, string caption, MessageBoxButton button, MessageBoxIcon icon)
		{
			return ShowMessageBox(text, caption, button, icon);
		}

		public static Task<MessageBoxResult> Show(string text, string caption, MessageBoxButton button)
		{
			return ShowMessageBox(text, caption, button);
		}

		public static Task<MessageBoxResult> Show(string text, string caption)
		{
			return ShowMessageBox(text, caption);
		}

		public static Task<MessageBoxResult> Show(string text)
		{
			return ShowMessageBox(text);
		}

		private static Task<MessageBoxResult> ShowMessageBox(string text, string caption = "", MessageBoxButton buttons = MessageBoxButton.OK, MessageBoxIcon icon = MessageBoxIcon.None)
		{
			var window = new MessageBoxWindow() { };
			var datacontext = new MessageBoxWindowViewModel(window, buttons, icon)
			{
				Text = text,
				Caption = caption,
				MessageBoxResult = MessageBoxResult.None
			};

			window.DataContext = datacontext;

			var tcs = new TaskCompletionSource<MessageBoxResult>();
			window.Closed += delegate { tcs.TrySetResult(datacontext.MessageBoxResult); };
			window.Show();
			return tcs.Task;
		}
	}
}
