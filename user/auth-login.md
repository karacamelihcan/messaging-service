
# Authentication (Login)

Used to collect a Token for a registered User.

**URL**  :  `/api/auth/`

**Method**  :  `POST`

**Auth required**  : NO

**Data constraints**

```json
{
    "username": "[valid email address]",
    "password": "[password in plain text]"
}
```

**Data example**

```json
{
    "username": "karacamelihcan",
    "password": "1234"
}
```

## Success Response

**Code**  :  `200 OK`

**Content example**

```json
{
  "userName": "karacamelihcan",
  "expireTime": "2021-03-22T14:20:10.9769462+03:00",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImthcmFjYW1lbGloY2FuIiwibmJmIjoxNjE2NDA4NDEwLCJleHAiOjE2MTY0MTIwMTAsImlhdCI6MTYxNjQwODQxMH0.NSMamRlWm7yj7m0qTudp2LesSetsXYpTcXoIXXKeQeY"
}
```


## Error Response

**Condition**  : If 'username' and 'password' combination is wrong.

**Code**  :  `400 BAD REQUEST`

**Content**  :

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "Bad Request",
  "status": 400,
  "traceId": "|d6e383fb-49cbd7ee7c7fe5a5."
}
```
