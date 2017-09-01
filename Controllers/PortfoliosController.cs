using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investips.Core;
using Investips.Core.Models;
using InvestipsApi.Controllers.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestipsApi.Controllers
{
    [Route("/api/portfolios")]
    public class PortfoliosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioRepository _repository;
        private readonly IUnitOfWork _uow;
        public PortfoliosController(IMapper mapper, IPortfolioRepository repository, IUnitOfWork uow)
        {
            this._uow = uow;
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorfolio(int id)
        {
            var porfolio = await _repository.GetPortfolio(id);
            if (porfolio == null)
            {
                return NotFound();
            }

            var porfolioResource = _mapper.Map<Portfolio, PortfolioResource>(porfolio);
            return Ok(porfolioResource);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IEnumerable<PortfolioResource>> GetPorfolios()
        {
            var porfolios = await _repository.GetPortfolios();
            return Mapper.Map<List<Portfolio>, List<PortfolioResource>>(porfolios);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePorfolio([FromBody] SavePortfolioResource porfolioResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var porfolio = _mapper.Map<SavePortfolioResource, Portfolio>(porfolioResource);
            porfolio.LastUpdate = DateTime.Now;

            _repository.Add(porfolio);
            await _uow.CompleteAsync();

            porfolio = await _repository.GetPortfolio(porfolio.Id);

            var result = _mapper.Map<Portfolio, PortfolioResource>(porfolio);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePorfolio(int id, [FromBody] SavePortfolioResource porfolioResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var porfolio = await _repository.GetPortfolio(id);

            if (porfolio == null)
            {
                return NotFound();
            }

            _mapper.Map<SavePortfolioResource, Portfolio>(porfolioResource, porfolio);
            porfolio.LastUpdate = DateTime.Now;

            await _uow.CompleteAsync();
            porfolio = await _repository.GetPortfolio(porfolio.Id);
            var result = _mapper.Map<Portfolio, PortfolioResource>(porfolio);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var porfolio = await _repository.GetPortfolio(id, includeProps: false);

            if (porfolio == null)
            {
                return NotFound();
            }
            _repository.Remove(porfolio);
            await _uow.CompleteAsync();

            return Ok(id);
        }
    }
}