
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarrosGaleria;

namespace LibraryEntidades
{
    public interface IGerenciar
    {
        List<Carros> MostrarTodos();
        void CadastrarCarro(Carros obj);
        void CadastrarEmJson(Carros obj);
        void ExcluirCarro(string Nome);
        List<Carros> PesquisarCarro(string Nome);
        void Atualizar(Carros carro);
        
    }
}
