# MessagingService.API Documentation

## Open Endpoints

Open endpoints require no Authentication

 - [register]() : `POST /api/user/register`
 
 -   [auth](https://github.com/jamescooke/restapidocs/blob/master/examples/login.md)  :  `POST /api/auth/`
 

## Endpoints that require Authentication

Closed endpoints require a valid Token to be included in the header of the request. A Token can be acquired from the Auth view above.

### Current User related

Each endpoint manipulates or displays information related to the User whose Token is provided with the request:

-   [Get]()       :  `GET /api/user/get`
-  [Block]()  :  `POST /api/user/block`
- [Get Blocked User]()  :  `GET /api/user/getblockeduser`


### Messages related

Endpoints for viewing and manipulating the Messages that the Authenticated User has permissions to access.

-   [Get Messages]()       :  `GET /api/messages/getmessages`

-  [Send]()  :  `POST /api/messages/send`

