using BooksManagement.API.Entities;
using BooksManagement.API.Models.InputModels;
using FluentValidation;

namespace BooksManagement.API.Validations
{
    public class BookValidator : AbstractValidator<BookInputModel>
    {
        public BookValidator()
        {
            RuleFor(book => book.PublicationYear)
                .Must(YearNotBiggerThanDateNow)
                .WithMessage("O ano de publicação não pode ser superior ao ano atual!");

            RuleFor(book => book.PublicationYear)
                .Must(YearNotLessThanZero)
                .WithMessage("O ano de publicação não pode ser menor ou igual a 0 (zero)!");

            RuleFor(book => book.Title)
                .NotEmpty()
                .WithMessage("O titulo do livro não pode ser um campo vazio!");

            RuleFor(book => book.Title)
                .Length(5, 200)
                .WithMessage("O titúlo precisa ter de 5 a 200 caracteres!");

            RuleFor(book => book.ISBN)
                .NotEmpty()
                .Length(13)
                .WithMessage("O ISBN tem que ter exatamente 13 dígitos, verifique e preencha novamente!");

            RuleFor(book => book.Author)
                .NotEmpty()
                .WithMessage("O autor do livro não pode ser um campo em branco!");

            RuleFor(book => book.Author)
                .NotEqual(book => book.Title)
                .WithMessage("O autor não pode ser igual ao titúlo do livro");
        }

        private bool YearNotBiggerThanDateNow(int publicationYear)
        {
            if (publicationYear > DateTime.Now.Year)
            {
                return false;
            }
            return true;
        }

        private bool YearNotLessThanZero(int publicationYear)
        {
            if (publicationYear <= 0)
            {
                return false;
            }
            return true;
        }

    }
}
