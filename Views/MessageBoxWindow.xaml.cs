using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaMessageBox.Views
{
	public class MessageBoxWindow : Window
	{
		public MessageBoxWindow()
		{
			this.InitializeComponent();
			#if DEBUG
			this.AttachDevTools();
			#endif

			
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
