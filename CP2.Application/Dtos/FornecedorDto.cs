using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .MaximumLength(100).WithMessage("O nome não pode exceder 100 caracteres");

            RuleFor(f => f.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatório")
                .Length(14).WithMessage("O CNPJ deve ter 14 caracteres");

            RuleFor(f => f.Endereco)
                .MaximumLength(200).WithMessage("O endereço não pode exceder 200 caracteres");

            RuleFor(f => f.Telefone)
                .MaximumLength(15).WithMessage("O telefone não pode exceder 15 caracteres");

            RuleFor(f => f.Email)
                .EmailAddress().WithMessage("O e-mail deve ser válido");

            RuleFor(f => f.CriadoEm)
                .NotEmpty().WithMessage("A data de criação é obrigatória");
        }
    }
}
