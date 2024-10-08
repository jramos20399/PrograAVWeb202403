﻿using BackEnd.DTO;
using BackEnd.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {


            return categoryService.Obtener();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryDTO Get(int id)
        {
            return categoryService.Obtener(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDTO category )
        {
            categoryService.Agregar(category);

            return Ok(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public IActionResult Put([FromBody] CategoryDTO  category)
        {
            categoryService.Editar(category);
            return Ok(category);

        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoryDTO category = new CategoryDTO
            {
                CategoryId = id
            };
            categoryService.Eliminar(category); 
        }
    }
}
