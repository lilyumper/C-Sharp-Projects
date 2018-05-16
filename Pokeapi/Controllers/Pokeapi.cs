using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokeapi.Models;
using System.Collections.Generic;

namespace Pokeapi.Controllers{
	
    public class PokeapiController:Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View("Index");
        }


    [HttpGet]
    [Route("pokemon/{pokeid}")]

    public IActionResult pokeinfo(int pokeid)
    {
        var PokeInfo = new Pokemon();
        WebRequest.GetPokemonDataAsync(pokeid, ApiResponse => {
            PokeInfo = ApiResponse;
        }).Wait();
        ViewBag.Pokemon = PokeInfo;
        return View();
    }
    }


}
