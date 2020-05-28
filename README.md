# CustomerAPI
Customer CRUD operation Rest API developed using Asp.Net Core and Entity Framework Core

#To run the project

1.Open command prompt, run command
  cd "project path"
  
2. Run command
  "dotnet run"
  
3. In command prompt, it will display the port on which the API is running.
4. Open a browser and navigate to http://localhost:5000/swagger/index.html
  (here port no. is 5000)
5. It will open the Swagger UI, where the API methods can be called and tested.

Fundamentals used in this project:
1. SOLID principles
2. Mapping using Automapper
3. API documentation using Swagger/OpenAPI 

Fundamentals to be implemented (In progress)
1. Push notifications
2. Docker Container
_________________________________________________________________________________

TEST DATA FOR TESTING:

CRUD Operations steps for Customer
----------------------------------
1. GetCustomers
--------------------
Method: GET

Url: http://localhost:5000/api/customers/

Headers:
Accept: application/json
Content-Type: application/json

Response Status: 200 OK
----------------------------------------------------------------------------------------------------------------------------
2. GetCustomer
--------------------
Method: GET

Url: http://localhost:5000/api/customers/e2c46906-2ea4-4672-a81f-bd69890c9b16

Headers:
Accept: application/json
Content-Type: application/json

Response Status: 200 OK
----------------------------------------------------------------------------------------------------------------------------
3. CreateCustomer
--------------------
Method: POST

Url: http://localhost:5000/api/customers/

Headers:
Accept: application/json
Content-Type: application/json

Body:
-----
{
    "personalNumber": "199502182365",
    "email": "user5@domain.com",
    "address": {
        "zipCode": 55604,
        "country": "Finland"
    },
    "phoneNumber": "+3585003556721"
}

Response Status: 201 Created
----------------------------------------------------------------------------------------------------------------------------

4. Update [HttpPut]
--------------------
Method: PUT

Url: http://localhost:5000/api/customers/e2c46906-2ea4-4672-a81f-bd69890c9b16

Headers:
Accept: application/json
Content-Type: application/json

Body:
-----
{
    "personalNumber": "199502182365",
    "email": "user5@domain.com",
    "address": {
        "zipCode": 55604,
        "country": "Finland"
    },
    "phoneNumber": "+3585003556721"
}

Response Status: 200 OK
----------------------------------------------------------------------------------------------------------------------------

4. Update [HttpPatch]

Method: PATCH

Url: http://localhost:5000/api/customers/e2c46906-2ea4-4672-a81f-bd69890c9b16

Headers:
Content-Type:application/json-patch+json
Accept:application/json

Body:
----

[
	{
		"op":"replace",
		"path":"/phoneNumber",
		"value":"+467452020"
	}
]

Body:
------

[
	{
		"op":"replace",
		"path":"/address/zipCode",
		"value":15130
	}
]

Body:
----
[
	{
		"op":"replace",
		"path":"/address/zipCode",
		"value":15134
	},
		{
		"op":"replace",
		"path":"/email",
		"value":"vivek@kosare.com"
	}
]

Body:
----

[
	{
		"op":"copy",
		"from":"/address/zipCode",
		"path":"/address/zipCode"
	}
]

Response Status: 200 OK
--------------------------------------------------------------------------------------------------------------------

4. Delete Customer [HttpDelete]

Method: DELETE

Url: http://localhost:5000/api/customers/e2c46906-2ea4-4672-a81f-bd69890c9b16

Headers:
Content-Type:application/json
Accept:application/json

Response Status: 200 OK
--------------------------------------------------------------------------------------------------------------------



