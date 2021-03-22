
# Register

Used to register as a new user. To collect a token you need a user account

**URL**  :  `/api/user/register`

**Method**  :  `POST`

**Auth required**  : NO

**Data constraints**



{
 "name": "[name]",
    "surname": "[surname]"
    "username": "[valid username]",
    "password": "[password in plain text]"
}
**Data example**

```json
{
	  "name": "Melihcan",
	  "surname": "Karaca",
	  "userName": "karacamelihcan",
	  "password": "1234"
}
```


## Success Response

**Code**  :  `200 OK`



## Error Response

**Condition**  : If 'username' exist in database.

**Code**  :  `400 BAD REQUEST`

**Content**  :

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "Bad Request",
  "status": 400,
  "traceId": "|5e197cb9-4144026a0e97c228."
}
```
