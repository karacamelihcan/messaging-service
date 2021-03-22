
# Block

Used to block a user who you don't want receive message from. 

**URL**  :  `/api/user/block{query}`

**Method**  :  `GET`

**Auth required**  : YES

**URL Query examples**

```bash
https://localhost:5001/api/user/getblockeduser?Username=karacamelihcan
```

## Success Responses

**Condition**  : Usernames provided are valid and User is Authenticated.

**Code**  :  `200 OK`

**Content Example**:
```json
[
  {
    "id": "79396a71-374f-4bd3-ad59-72f009898761",
    "blockedUserName": "fake3",
    "date": "2021-03-22T13:22:07.9163198+03:00"
  },
  {
    "id": "27849622-bde0-48cb-95af-28e0d366ffcf",
    "blockedUserName": "fake2",
    "date": "2021-03-22T13:22:07.9162745+03:00"
  },
  {
    "id": "07ce6905-273e-486a-b234-b4c6f32c6b82",
    "blockedUserName": "fake1",
    "date": "2021-03-22T13:22:07.912028+03:00"
  }
]
```


## Error Response 

**Condition**  : If username doens't exist

**Code**  :  `404 NOT FOUND`

**Content example**  :

```
There is no such a username
```


**Condition**  : If username doesnt send

**Code**  :  `400 BAD REQUEST`

**Content example**  :

```json
{
"type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
"title": "One or more validation errors occurred.",
"status": 400,
"traceId": "|d6e38408-49cbd7ee7c7fe5a5.",
"errors": {
"Username": [
	"The Username field is required."
	]
}
```
