using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investips.Core;
using Investips.Core.Models;
using InvestipsApi.Controllers.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestipsApi.Controllers
{
    [Route("/api/securities")]
    public class SecuritiesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly ISecurityRepository _securityRepository;

        public SecuritiesController(IMapper mapper, IUnitOfWork uow, ISecurityRepository securityRepository)
        {
            this._securityRepository = securityRepository;
            this._uow = uow;
            this._mapper = mapper;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSecurity(int id)
        {
            var security = await _securityRepository.GetSecurity(id);

            if (security == null)
            {
                return NotFound();
            }

            var porfolioResource = _mapper.Map<Security, SecurityResource>(security);
            return Ok(security);
        }


        [HttpPost]
        public async Task<IActionResult> CreateSecurity([FromBody] SecurityResource securityResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var security = Mapper.Map<SecurityResource, Security>(securityResource);
            _securityRepository.Add(security);
            await _uow.CompleteAsync();

            security = await _securityRepository.GetSecurity(security.Id);
            var result = _mapper.Map<Security, SecurityResource>(security);
            return Ok(result);
        }
    }
}