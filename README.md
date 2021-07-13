# BTN.Demo.Menu
This Solution was created with the intention of having a simple requirement in order to practice the implementation of some interesting concepts like:
1. Clean Architecture
2. Design Patterns 
3. Unit Testing
4. Integration Testing

# Base Business Logic
The requirement for this API is simple:
>
>As a robotic waitress I need a service that returns a drinks menu based on customer Age.


- Customer younger than 18 years old should only get soft drinks
- Customer older than 18 years old but younger than 21 should get soft drink but only beers for alcoholic drinks.
- Customer older than 21 years old should get the full drinks menu

- When Customer age is not provided, all drinks should be retrieved.

# Extra Business Logic
Once completed the original request, I decided to add new business logic to add some complexity.
>
>As a robotic waitress I need a service that returns a drinks menu based on customer Age and in-stock drinks.

>
>As a robotic waitress I need a service that returns a drinks menu based on customer Age, in-stock drinks and considering which country
is provided by configuration. When the Country doesn't allow alcoholic drinks, the API should not include them in the drinks menu.