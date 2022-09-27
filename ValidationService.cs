using FluentValidation;
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
        public Task<string> Validar(string arquivo)
        {
           
            string line;
            
            using(var reader = new StreamReader(arquivo))
            while((line = reader.ReadLine()) !=null)
            {
                    if (line.StartsWith("0000"))
                    {
                        var parts = line.Split('|');
                        var ValidationFile = new AberturaValidation(line);
                        return Task.FromResult("Abertura valida");
                    }
                    else if (line.StartsWith("1000"))
                    { 
                        var ValidationFile = new PrimeiroBlocoValidation(line);
                        return Task.FromResult("Primeiro Bloco valido");
                    }
                    else if (line.StartsWith("2000"))
                        { 
                            var ValidationFile = new SegundoBlocoValidation(line);
                            return Task.FromResult("Segundo Bloco valido");
                    }
                    else if (line.StartsWith("3000"))
                        { 
                            var ValidationFile = new TerceiroBlocoValidation(line);
                            return Task.FromResult("Terceiro Bloco valido");
                    }
                    else if (line.StartsWith("4000"))
                        { 
                            var ValidationFile = new QuartoBlocoValidation(line);
                            return Task.FromResult("Quarto bloco valido"); 
                        }

                    var Importar = @"C:\repositorio\bi_desenv\fazenda\cargas_textos\ressarcimento\importar\";
                    var Ignorados = @"C:\repositorio\bi_desenv\fazenda\cargas_textos\ressarcimento\ignorados\";
                    var Zipados = @"C:\repositorio\bi_desenv\fazenda\cargas_textos\ressarcimento\zipados\";


                    string zipado = Path.Combine(Zipados, Path.GetFileName(arquivo));
                    File.Copy(Path.Combine(Importar, arquivo), Path.Combine(Zipados, zipado), true);
                    //File.Copy(sourceFileName: Importar, destFileName: Zipados, overwrite: true);
                    return Task.FromResult("Arquivo Validado");

                }
            return Task.FromResult("Arquivo Invalido");
        }
    }

}
    
