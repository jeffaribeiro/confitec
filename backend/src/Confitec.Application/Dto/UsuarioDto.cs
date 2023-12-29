﻿namespace Confitec.Application.Dto
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public int IdEscolaridade { get; set; }
        public string Escolaridade { get; set; } = null!;
        public HistoricoEscolarDto[] Historicos { get; set; } = null!;
    }
}
