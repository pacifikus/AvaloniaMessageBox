using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaMessageBox.Views
{
	public class MessageBoxWindow : Window
	{
		public MessageBoxResult MessageBoxResult { get; set; }

		public MessageBoxWindow()
		{
			this.InitializeComponent();
			MessageBoxResult = MessageBoxResult.None;
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
