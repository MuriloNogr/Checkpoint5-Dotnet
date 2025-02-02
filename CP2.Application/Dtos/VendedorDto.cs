﻿using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .MaximumLength(100).WithMessage("O nome não pode exceder 100 caracteres");

            RuleFor(v => v.Email)
                .EmailAddress().WithMessage("O e-mail deve ser válido");

            RuleFor(v => v.Telefone)
                .MaximumLength(15).WithMessage("O telefone não pode exceder 15 caracteres");

            RuleFor(v => v.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser anterior à data atual");

            RuleFor(v => v.Endereco)
                .MaximumLength(200).WithMessage("O endereço não pode exceder 200 caracteres");

            RuleFor(v => v.DataContratacao)
                .NotEmpty().WithMessage("A data de contratação é obrigatória")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de contratação não pode ser futura");

            RuleFor(v => v.ComissaoPercentual)
                .InclusiveBetween(0, 100).WithMessage("O percentual de comissão deve estar entre 0 e 100");

            RuleFor(v => v.MetaMensal)
                .GreaterThan(0).WithMessage("A meta mensal deve ser maior que zero");

            RuleFor(v => v.CriadoEm)
                .NotEmpty().WithMessage("A data de criação é obrigatória");
        }
    }
}
