using SistemaEscola.Dominio.Cartoes;
using SistemaEscola.Dominio.Cartoes.Entidade;


namespace SistemaEscola.Dominio.Colunas.Consultas
{
    public class ColunaCartoesConsulta
    {
        public int IdColuna { get; set; }
        public string NomeColuna { get; set; }
        public List<Cartao> Cartoes { get; set; }

    }
     
    public class ColunaListagem
    {
        public int IdBoard { get; set; }
        public string NomeBoard { get; set; }

        public List<ColunaCartoesConsulta> Coluna { get; set;}

    }
}
