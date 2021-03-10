using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.Helpers;
using Server.Models;

namespace Server.Controllers {
	[ApiController, AllowAnonymous, Route("api/Calculate")]
	public class CalculatorController : ControllerBase {
		private readonly UserManager<User> userManager;
		private readonly ICalculatorRepository repo;
		public CalculatorController(UserManager<User> userManager, ICalculatorRepository repo) {
			this.repo = repo;
			this.userManager = userManager;
		}

		[HttpGet("{scheme}"), AllowAnonymous]
		public async Task<IActionResult> StandardCalculation([FromRoute] string scheme) {
			try {
				var result = await this.repo.CalculateAsync(scheme);
				return Ok(result);
			}
			catch (CalculationException) {
				return UnprocessableEntity();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("Admin/{scheme}"), Authorize(Policy = "ElevatedRights")]
		public async Task<IActionResult> AdvancedCalculation([FromRoute] string scheme) {
			try {
				var result = await this.repo.CalculateAsync(scheme);
				return Ok(result);
			}
			catch (CalculationException) {
				return UnprocessableEntity();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}
	}
}