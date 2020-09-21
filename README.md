# PrimeNumberTask

This project is a REST API built with ASP.NET Core 3.1 for the purpose of a required coding task before an actual job interview. It can do two things:
1. It can tell you if a given number is a prime or a composite number.
2. It can find a prime number for a given number such that the prime number is greater or equal the given number.

The project includes a DOCKERFILE to containerize the application.

# Endpoints

Available endpoints are:
- /api/IsPrimeNumber/{number}
- /api/FindNextPrimeNumber/{number}
- /swagger

# Project Development Considerations

1. The business logic in this project is separated in a class library for modularity and easier testability.
2. The business logic is developed according to TDD writing unit tests first and then implementing the logic until all tests pass.
3. When the API call is successful a custom JSON object is delivered in response instead of plain text. This will ensure easier serialisation and handling on the client side.
4. For input errors and argument exceptions a ValidationProblemDetails object is returned together with http code 400. All other exceptions are returned with http code 500
and ProblemDetails object with a simple "unknown error" message hiding the actual exception details. This is the place where a logging mechanism should be implemented.
5. Some toughts about the expected input - According to Wikipedia: A prime number (or a prime) is a natural number greater than 1 that is not a product of two smaller 
natural numbers.
  1) From the definition of prime numbers we can exclude the negative numbers for now.
  2) Decimal should be the bind input type so that larger numbers can be binded in the controllers without causing an unexpected overflows.
	3) However a limit of 2,147,483,647 for the REST API endpoints seems reasonable as it is the upper limit of signed 32bit integer. 
  This data type is well optimized for calculations
	and at the same time it offers large enough interval to search or check for prime numbers. 
	The worst case scenario for checking if 2,147,483,647 is a prime number finishes for around 11 seconds on a mobile core i7 processor from 2012,
	which is slow but still well below any browser timeout.
	At the same time the signed integer offers the possibility to add the same range in the negative numers' space if so desired.
