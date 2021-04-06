using System;
using System.ComponentModel.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using Microsoft.AspNetCore.Http;



namespace API.ViewModels
{
    public class UpdateViewModel
    {
        [Required(ErrorMessage = "O ID não pode tar vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID deve ter no minimo 1 caracteres.")]
        public int Id { get; set; }


        [Required(ErrorMessage = "O titulo não pode estar nulo.")]
        [MinLength(3, ErrorMessage = "O titulo deve ter no minimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O titulo deve ter no maximo 100 caracteres.")]
        public string Title { get; set; }

          #nullable enable

           [AssertThat("Description != null"), StringLength(200,
            ErrorMessage = "A descrição deve ter no maximo 200 caracteres ")]
           public string? Description { get; set; }

           [RegularExpression(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)",
           ErrorMessage = "Insira o texto no Padrão de um link exemplo:https://translate.google.com/")]
           public string? Link { get; set; }

           public IFormFile? Photos { get; set; }
           public bool? WonOrBought { get; set; }

            #nullable disable

    }
}