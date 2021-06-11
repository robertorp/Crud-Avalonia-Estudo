using System;
using FluentValidation;
using FluentValidation.Results;

namespace Crud_Avalonia_Estudo.Models
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(60);
        }
    }

    public class Pessoa
    {
        public Pessoa(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }

        public Guid Id { get; }
        public string Nome { get; }

        public ValidationResult Validador()
        {
            return new PessoaValidator().Validate(this);
        }
    }
}