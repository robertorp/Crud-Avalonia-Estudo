using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Crud_Avalonia_Estudo.Models;
using Crud_Avalonia_Estudo.ViewModels;

namespace Crud_Avalonia_Estudo.Views
{
    public partial class MainWindow : MainWindowBase
    {
        private readonly MainWindowViewModel _model;

        public MainWindow() { }

        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            _model = mainWindowViewModel;
            DataContext = _model;
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Salvar_OnClick(object? sender, RoutedEventArgs e)
        {

            var pessoa = new Pessoa(_model.Nome);
            Validar(pessoa.Validador());

            if (!OperacaoValida())
            {
                MostraMensagensDeErro();
                return;
            }

            var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("title", $"{_model.Nome}");
            messageBoxStandardWindow.ShowDialog(this);
        }
    }
}
