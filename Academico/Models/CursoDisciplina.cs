using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academico.Models
{
    public class CursoDisciplina
    {
        [Key, Column(Order = 0)]
        public long DisciplinaId { get; set; }
        public Disciplina? Disciplina { get; set; }

        [Key, Column(Order = 1)]
        public int CursoId { get; set; }
        public Curso? Curso { get; set; }

        [Range(20, int.MaxValue, ErrorMessage = "A carga horária deve ser no mínimo 20.")]
        public int CargaHoraria { get; set; }
    }
}
