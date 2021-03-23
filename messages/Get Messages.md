
# Get Messages

Used to get messages from database with query.

**URL**  :  `/api/messages/getmessages{query}`

**Method**  :  `GET`

**Auth required**  : YES

**URL Query Examples**
First
```bash
https://localhost:5001/api/messages/getmessages?username=karacamelihcan
```
OR
Second
```bash
https://localhost:5001/api/messages/getmessages?username=karacamelihcan&sendername=talatkaraca
```

## Success Responses

**Condition**  : Usernames provided are valid , User is Authenticated 

**Code**  :  `200 OK`
First
```json
[
  {
    "id": "078bd35f-ed5d-4334-a27e-970b5efeed8c",
    "senderName": "talatkaraca",
    "receiverName": "karacamelihcan",
    "content": "Deneme Mesajı",
    "date": "2020-06-19T00:00:00"
  },
  {
    "id": "ec98a5c5-edae-4728-ba43-8de8718d8a61",
    "senderName": "belmas",
    "receiverName": "karacamelihcan",
    "content": "Deneme Mesajı",
    "date": "2020-05-24T00:00:00"
  },
  {
    "id": "ca29a0cb-a710-4be6-8998-295cd7a433e6",
    "senderName": "aysekaraca",
    "receiverName": "karacamelihcan",
    "content": "Deneme Mesajı",
    "date": "2020-02-24T00:00:00"
  }
]
```


Second
```json
[
  {
    "id": "078bd35f-ed5d-4334-a27e-970b5efeed8c",
    "senderName": "talatkaraca",
    "receiverName": "karacamelihcan",
    "content": "Deneme Mesajı",
    "date": "2020-06-19T00:00:00"
  }
]
```


## Error Response 

**Condition**  : If receiver username doens't exist or there is no message.

**Code**  :  `204 No Content`


