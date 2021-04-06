using FluentValidation;
using Domain.Entities;

namespace Domain.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {

        public ItemValidator()
        {
           RuleFor(x => x)
           
                .NotEmpty()
                .WithMessage("O Produto não pode estar vazio.")

                .NotNull()
                .WithMessage("O Produto não pode ser Nulo.");

                RuleFor(x => x.Title)
                .NotNull()
                .WithMessage("O titulo não pode esta nulo")

                .NotEmpty()
                .WithMessage("O tilulo não pode estar vazio.")

                .MinimumLength(3)
                .WithMessage("O titulo deve ter no minimo 3 caracteres!.")

                .MaximumLength(100)
                .WithMessage("O titulo deve ter no Maximo 100 caracteres!.");


            RuleFor(x => x.Description)

                .MaximumLength(200)
                .WithMessage("A descrição deve ter no Maximo 200 caracteres!.");

            RuleFor(x => x.Link)
                .Matches(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)")
                .WithMessage("digite uma URL que siga o padrão http://www.***.com");

        }

    }
}