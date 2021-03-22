# MessagingService.API Documentation

## Open Endpoints

Open endpoints require no Authentication

 - [register](https://github.com/karacamelihcan/messaging-service/blob/main/user/Register.md) : `POST /api/user/register`
 
 -   [auth](https://github.com/karacamelihcan/messaging-service/blob/main/user/auth-login.md)  :  `POST /api/auth/`
 

## Endpoints that require Authentication

Closed endpoints require a valid Token to be included in the header of the request. A Token can be acquired from the Auth view above.

### Current User related

Each endpoint manipulates or displays information related to the User whose Token is provided with the request:

-   [Get](https://github.com/karacamelihcan/messaging-service/blob/main/user/Get.md)       :  `GET /api/user/get`
-  [Block](https://github.com/karacamelihcan/messaging-service/blob/main/user/Block.md)  :  `POST /api/user/block`
- [Get Blocked User](https://github.com/karacamelihcan/messaging-service/blob/main/user/Get%20Block%20User.md)  :  `GET /api/user/getblockeduser`


### Messages related

Endpoints for viewing and manipulating the Messages that the Authenticated User has permissions to access.

-   [Get Messages]()       :  `GET /api/messages/getmessages`

-  [Send]()  :  `POST /api/messages/send`

