//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Imagem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class exemplo
    {
        [Display(Name = "ID")]
        public int idexemplo { get; set; }

        [Display(Name = "T�tulo")]
        [Required(ErrorMessage = "Escreva um t�tulo !")]
        public string Titulo { get; set; }

        [Display(Name = "Descri��o !")]
        public string descricao { get; set; }
        public string caminhoImagem { get; set; }
        public string status { get; set; }
        //essa linha � adicionada para podermos utilizar no controler
        //e fazer a c�pia do arquivo para a pasta do projeto
        public HttpPostedFileBase ImageFile { get; set; }

    }
}
