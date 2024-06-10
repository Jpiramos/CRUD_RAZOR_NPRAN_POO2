using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Disciplina
    {
        public long DisciplinaID { get; set; }

        [Required(ErrorMessage = "O nome da disciplina é obrigatório.")]
        public string? Nome { get; set; }

        public List<CursoDisciplina>? CursosDisciplinas { get; set; }
    }
}
