
using CarrosGaleria;
using LibraryEntidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntidades
{
    public class CarrosInFile : IGerenciar
    {
        private List<Carros> _carros = new List<Carros>();

        public CarrosInFile()
        {
            LerArquivo();
        }

        private void LerArquivo()
        {
            using (var file = File.Open("ArquivoComCarros.json", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (var stream = new StreamReader(file))
                {
                    var json = stream.ReadToEnd();

                    this._carros = JsonConvert.DeserializeObject<List<Carros>>(json);

                    stream.Close();
                }
            }
            if (this._carros == null)
            {
                this._carros = new List<Carros>();
            }
        }

        public void EscreverArquivo()
        {
            if (this._carros == null)
            {
                return;
            }

            using (var file = File.Open("ArquivoComCarros.json", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var stream = new StreamWriter(file))
                {
                    var json = JsonConvert.SerializeObject(this._carros);

                    stream.WriteLine(json);

                    stream.Close();
                }
            }
            if (this._carros == null)
            {
                this._carros = new List<Carros>();
            }
        }

        public void CadastrarEmJson(Carros obj)
        {
            _carros.Add(obj);
            EscreverArquivo();
            
        }

        public List<Carros> MostrarTodos()
        {
            
            return _carros;
        }
        public void Atualizar(Carros carro)
        {
            throw new NotImplementedException();
        }
        public void ExcluirCarro(string modelocarro)

        {

            var carro = _carros.Find(x => x.ModeloCarro == modelocarro);
            _carros.Remove(carro);
            SaveData("ArquivoComCarros.json", _carros);
        }

        public List<Carros> PesquisarCarro(string modelocarro)
        {
            return _carros.Where(x => x.ModeloCarro == modelocarro).ToList();
        }
        static void SaveData(string filePath, List<Carros> carro)
        {
            string json = JsonConvert.SerializeObject(carro);
            File.WriteAllText(filePath, json);
        }

        public void CadastrarCarro(Carros obj)
        {
           _carros.Add(obj);
        }

       
    }
}
