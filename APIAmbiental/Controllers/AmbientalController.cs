using APIAmbiental.Data.Contexts;
using APIAmbiental.Models;
using APIAmbiental.Services;
using APIAmbiental.ViewModel;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace APIAmbiental.Controllers
{
    [ApiVersion(1, Deprecated = true)]
    [ApiVersion(2)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    [Authorize]
    public class AmbientalController : ControllerBase
    {
        private readonly ICondicoesAmbientaisService _condicoesAmbientaisService;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;

        public AmbientalController(ICondicoesAmbientaisService condicoesAmbientaisService, IMapper mapper)
        {
            _condicoesAmbientaisService = condicoesAmbientaisService;
            _mapper = mapper;
            
        }
        public AmbientalController(DatabaseContext context)
        {
           _context = context;
        }

        [MapToApiVersion(1)]
        [HttpGet]
        [Authorize(Roles = "Adm,user")]
        public ActionResult<IEnumerable<CondicoesAmbientaisViewModel>> Get()
        {
            var lista = _condicoesAmbientaisService.ListarCondicoesAmbientais();
            var viewModelList = _mapper.Map<IEnumerable<CondicoesAmbientaisViewModel>>(lista);

            if (viewModelList == null || !viewModelList.Any())
            {
                return NoContent();
            }
            else
            {
                return Ok(viewModelList);
            }
        }
        [MapToApiVersion(2)]
        [HttpGet]
        [Authorize(Roles = "Adm,user")]
        public ActionResult<IEnumerable<CondicoesAmbientaisPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var clientes = _condicoesAmbientaisService.ListarCondicoesAmbientais(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<CondicoesAmbientaisViewModel>>(clientes);

            var viewModel = new CondicoesAmbientaisPaginacaoViewModel
            {
                CondicoesAmbientais = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };


            return Ok(viewModel);
        }
        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpGet("{id}")]
        [Authorize(Roles = "Adm,user")]

        public ActionResult<CondicoesAmbientaisViewModel> Get(int id)
        {
            var model = _condicoesAmbientaisService.ObterCondicoesAmbientaisPorID(id);
           

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<CondicoesAmbientaisViewModel>(model);
                return Ok(viewModel);
            }
        }
        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpPost]
        [Authorize(Roles = "Adm,user")]
        public ActionResult Post([FromBody]CreateCondicoesAmbientaisViewModel condicoesAmbientaisViewModel)
        {
            var model = _mapper.Map<CondicoesAmbientaisModel>(condicoesAmbientaisViewModel);
            _condicoesAmbientaisService.CadastrarCondicoesAmbientais(model);

            return CreatedAtAction(nameof(Get), new { id = model.id },model );
        }
        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpPut("{id}")]
        [Authorize(Roles = "Adm,user")]
        public ActionResult Put([FromRoute] int id,[FromBody] CondicoesAmbientaisViewModel condicoesAmbientaisViewModel)
        {
            if(condicoesAmbientaisViewModel.id == id)
            {
                var model = _mapper.Map<CondicoesAmbientaisModel>(condicoesAmbientaisViewModel);
                _condicoesAmbientaisService.AtualizarCondicoesAmbientais(model);

                return NoContent();
            }
            else
            {
                return BadRequest();
            }
   
        }
        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Adm")]
        public ActionResult Delete([FromRoute]  int id)
        {
            
            _condicoesAmbientaisService.DeletarCondicoesAmbientais(id);
            return NoContent();
        }

    }
}
