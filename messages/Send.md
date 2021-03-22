
# Send

Used to send a message to user whose username you know. 

**URL**  :  `/api/user/send`

**Method**  :  `POST`

**Auth required**  : YES

**Data Examples**

```
{
  "senderName": "string",
  "receiverName": "string",
  "content": "string"
}
```

## Success Responses

**Condition**  : Usernames provided are valid , User is Authenticated and Sender is not blocked by Receiver

**Code**  :  `200 OK`


## Error Response 

**Condition**  : If sender or receiver username doens't exist

**Code**  :  `404 NOT FOUND`

**Content example**  :

```
There is no such a username
```


**Condition**  : If sender blocked by receiver

**Code**  :  `400 BAD REQUEST`

**Content example**  :

```
You cannot send message to this user
```
