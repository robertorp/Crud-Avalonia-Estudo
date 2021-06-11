using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avalonia.Controls;
using FluentValidation;
using FluentValidation.Results;
using MessageBox.Avalonia.Enums;

namespace Crud_Avalonia_Estudo.Views
{
    public class MainWindowBase : Window
    {
        protected ValidationResult ValidationResult;

        protected string Erros => ObterMensagens();

        private string ObterMensagens()
        {
            var mensagens = ValidationResult?.Errors.Select(x => x.ErrorMessage).ToList() ?? new List<string>();

            var mensagemMontada = new StringBuilder();

            foreach (var mensagen in mensagens)
            {
                mensagemMontada.Append(mensagen).Append("\n");
            }

            return mensagemMontada.ToString();
        }

        protected void Validar(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
        protected bool OperacaoValida()
        {
            return ValidationResult.IsValid;
        }

        protected void MostraMensagensDeErro()
        {
            var telaErro = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Erros", Erros, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error);
            telaErro.ShowDialog(this);
        }

    }
}