using Microsoft.AspNetCore.Mvc;
using static System.Environment;
using static System.IO.Path;
using static System.IO.Directory;
using static System.IO.File;
using ClassificadorAPI.Services;
using UGDAT.Business.Models;
using UGDAT.Business.Interfaces;

namespace SefazIO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReassarcimentoController : ControllerBase
    {

        private readonly IValidation _validation;

        public ReassarcimentoController(IValidation validation)
        {
            _validation = validation;
        }


        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
           
                //220895-1-CNPJ_33041260095360-cut

                var fileType = Path.GetExtension(file.FileName);
                var filePath = @"C:\repositorio\bi_desenv\fazenda\cargas_textos\ressarcimento\importar\";

                if (fileType.ToLower() == ".txt")
                {
                    var docName = Path.GetFileName(file.FileName);
                    if (file != null && file.Length > 0)
                    {
                        string fullPath = Path.Combine(filePath, "Files");
                        string DocUrl = Path.Combine(filePath, "Files", Guid.NewGuid() + fileType);
                        _validation.Validar(filePath);
                }
                else
                {
                    return BadRequest();
                }

            }

            return Ok();

            }

        }

    }


       
    