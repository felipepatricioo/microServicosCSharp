﻿using eBookShopping.ProductAPI.Data.ValueObjects;
using eBookShopping.ProductAPI.Repository;
using eBookShopping.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBookShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var product = await _repository.FindAll();
            return Ok(product);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Create([FromBody]ProductVO vo)
        {
            if (vo == null) return BadRequest();

            var product = await _repository.Create(vo);

            return Ok(product);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();

            var product = await _repository.Update(vo);

            return Ok(product);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);

            if (!status) return BadRequest();
           
            return Ok(status);
        }

    }
}
