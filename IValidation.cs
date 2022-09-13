using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGDAT.Business.Interfaces
{
    public interface IValidation
    {
      
        Task<string> Validar(string file);
       
    }
}
