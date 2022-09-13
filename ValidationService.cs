using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGDAT.Business.Interfaces;
using UGDAT.Business.Models;
using UGDAT.Business.Validations;

namespace UGDAT.Business.Services
{
    
    public class ValidationService : IValidation 
    {
        Task<string> IValidation.Validar(string file)
        {
          
            const string sourcePath = @"C:\repositorio\bi_desenv\fazenda\cargas_textos\ressarcimento\importar\";
            //const string targetPath = @"C:\repositorio\bi_desenv\fazenda\cargas_textos\ressarcimento\lidos";


            string line;

            using (var fs = File.OpenRead(sourcePath))
            using (var reader = new StreamReader(fs))


                while ((line = reader.ReadLine()) != null)
                {

                    if (line.StartsWith("0"))
                    {
                        var abertura = new Abertura();
                        var ValidationFile = new AberturaValidation();
                        
                        Console.WriteLine($"Valindando {abertura}");
                    }
                    else if (line.StartsWith("1"))
                    {
                        var primeiroBloco = new PrimeiroBloco();
                        var ValidationFile = new PrimeiroBlocoValidation();

                        Console.WriteLine($"Valindando {primeiroBloco}");
                    }
                    else if (line.StartsWith("2"))
                    {
                        var segundoBloco = new SegundoBloco();
                        var ValidationFile = new SegundoBlocoValidation();
                    }
                    else if (line.StartsWith("3"))
                    {
                        var terceiroBloco = new TerceiroBloco();
                        var ValidationFile = new TerceiroBlocoValidation();
                    }
                    else if (line.StartsWith("4"))
                    {
                        var terceiroBloco = new QuartoBloco();
                        var ValidationFile = new QuartoBlocoValidation();
                    }
                }

                return   Task.FromResult("Arquivo validado com sucesso");

        }

        
    }
    
}
