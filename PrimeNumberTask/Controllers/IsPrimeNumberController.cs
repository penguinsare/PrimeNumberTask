﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PrimeNumberTask.Controllers.Constants;
using PrimeNumberTask.Controllers.Models;
using PrimeNumberTask.Lib;

namespace PrimeNumberTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(OperationResult), 200)]
    [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public class IsPrimeNumberController : ControllerBase
    {

        [HttpGet("{number}")]
        public ActionResult<OperationResult> CheckIfNumberIsPrime([Required] decimal number)
        {
            if (number > 2147483647)
                return ValidationProblem(
                    new ValidationProblemDetails(
                        new Dictionary<string, string[]> { 
                            { 
                                "number", new string[] { "Only numbers between 2 and 2,147,483,647 are accepted." } 
                            } 
                        }
                    )
                );

            try
            {                
                bool isPrime = PrimeNumberHelper.IsPrimeNumber((int)number);

                return Ok(new OperationResult(
                    OperationNames.IsPrimeNumber,
                    new Dictionary<string, object>() { { "number", number } },
                    isPrime ? 
                    $"The number {number} is a prime." :
                    $"The number {number} is a composite number."));
            }
            catch(ArgumentOutOfRangeException argumentEx)
            {
                return ValidationProblem(
                    new ValidationProblemDetails(
                        new Dictionary<string, string[]> {
                            {
                                "number", new string[] { argumentEx.Message }
                            }
                        }
                    )
                );
            }
            catch(Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Detail = ResponseErrors.UnknownError,
                    Title = "unknownError"
                });
            }            
        }
    }
}
