﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.JwtProject.Business.Interfaces;
using Project.JwtProject.Business.StringInfos;
using Project.JwtProject.Entities.Concrete;
using Project.JwtProject.Entities.Dtos.ProductDtos;
using Project.JwtProject.WebApi.CustomFilters;

namespace Project.JwtProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize(Roles =RoleInfo.Admin+","+RoleInfo.Member)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        [Authorize(Roles =RoleInfo.Admin)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            return Ok(product);
        }
        [HttpPost]
        [Authorize(Roles = RoleInfo.Admin)]
        [ValidModel]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
           
            await _productService.Add(_mapper.Map<Product>(productAddDto));
            return Created("", productAddDto); //first param is header of response
        
           
            
        }
        [HttpPut]
        [Authorize(Roles = RoleInfo.Admin)]

        [ValidModel]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _productService.Update(_mapper.Map<Product>(productUpdateDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = RoleInfo.Admin)]
        [ServiceFilter(typeof(ValidId<Product>))]

        public async Task<IActionResult> Delete(int id) {
            await _productService.Remove(new Product() { Id = id });
            return NoContent();
        }
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem(detail: "There is an error.");
        }
    }
}
