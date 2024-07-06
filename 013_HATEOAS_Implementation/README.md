# HATEOAS implementation

This project demonstrates the implementation of HATEOAS (Hypermedia as the Engine of Application State) in an ASP.NET Core Web API. The API provides basic CRUD operations for items and includes hypermedia links in the responses to guide clients on how to interact with the API.

## Overview

HATEOAS is a constraint of the REST application architecture that keeps the RESTful style's visibility constraint. With HATEOAS, a client interacts with a network application entirely through hypermedia provided dynamically by application servers.

## Features

- Retrieve an item by ID
- Update an item
- Delete an item
- Hypermedia links in responses to guide clients

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/oneananda/HATEOASExample.git
    cd HATEOASExample
    ```

2. Restore the dependencies:
    ```bash
    dotnet restore
    ```

3. Run the application:
    ```bash
    dotnet run
    ```

The API will be available at `http://localhost:5003`.

### Usage

You can interact with the API using any HTTP client, such as [curl](https://curl.se/), [Postman](https://www.postman.com/), or directly from your browser.


#### Retrieve an Item

- **Request**:
    ```http
    GET /api/items/1
    ```

#### CURL

```
curl -X GET "http://localhost:5000/api/items/1" -H "accept: application/json"
```

#### Using Postman (API Testing Tool)
Open Postman.
Set the request type to GET.
Enter the URL: http://localhost:5003/api/items/1.
Click Send.
You should see the JSON response in the Postman response area.

#### Using a Web Browser

http://localhost:5003/api/items/1


- **Response**:
    ```json
    {
      "id": 1,
      "name": "Item 1",
      "links": [
        {
          "rel": "self",
          "href": "/api/items/1",
          "method": "GET"
        },
        {
          "rel": "update_item",
          "href": "/api/items/1",
          "method": "PUT"
        },
        {
          "rel": "delete_item",
          "href": "/api/items/1",
          "method": "DELETE"
        }
      ]
    }
    ```

#### Update an Item

- **Request**:
    ```http
    PUT /api/items/1
    Content-Type: application/json

    {
      "id": 1,
      "name": "Updated Item Name"
    }
    ```

- **Response**:
    ```http
    HTTP/1.1 204 No Content
    ```

#### Delete an Item

- **Request**:
    ```http
    DELETE /api/items/1
    ```

- **Response**:
    ```http
    HTTP/1.1 204 No Content
    ```



