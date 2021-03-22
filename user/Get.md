
# Get
Used to get all user information from the database. It has created for the make development easir.

**URL**  :  `/api/user/get`

**Method**  :  `GET`

**Auth required**  : YES

**Data constraints** NO

**Data example**


## Success Response

**Code**  :  `200 OK`

**Content example**

```json
[
  {
    "id": 1,
    "name": "Melihcan",
    "surname": "Karaca",
    "userName": "karacamelihcan",
    "password": "1234"
  },
  {
    "id": 2,
    "name": "Talat",
    "surname": "Karaca",
    "userName": "talatkaraca",
    "password": "4567"
  },
  {
    "id": 3,
    "name": "Ayşe",
    "surname": "Karaca",
    "userName": "aysekaraca",
    "password": "aysek"
  },
  {
    "id": 4,
    "name": "Büşra",
    "surname": "Elmas",
    "userName": "belmas",
    "password": "bkelmas"
  },
  {
    "id": 5,
    "name": "Fake",
    "surname": "User 1",
    "userName": "fake1",
    "password": "1234"
  },
  {
    "id": 6,
    "name": "Fake",
    "surname": "User 2",
    "userName": "fake2",
    "password": "1234"
  },
  {
    "id": 7,
    "name": "Fake",
    "surname": "User 3",
    "userName": "fake3",
    "password": "1234"
  }
]
```


## Error Response

**Condition**  : If user has not permission to access.

**Code**  :  `401 Unauthorized`

