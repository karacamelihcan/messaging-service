
# Block

Used to block a user who you don't want receive message from. 

**URL**  :  `/api/user/block`

**Method**  :  `POST`

**Auth required**  : YES

**Data constraints**

```
{
  "kickerName": "string",
  "blockedName": "string"
}
```

**Data examples**

```json
{
  "kickerName": "karacamelihcan",
  "blockedName": "talatkaraca"
}
```

## Success Responses

**Condition**  : Usernames provided are valid and User is Authenticated.

**Code**  :  `200 OK`



## Error Response 

**Condition**  : If a previously blocked username is send

**Code**  :  `400 BAD REQUEST`

**Content example**  :

```
You have already blocked this user
```


**Condition**  : If one of the usernames doesn' exist in database

**Code**  :  `404 NOT FOUNDA`

**Content example**  :
```
There is no such a username
```
