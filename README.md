# UrlShortenerApp

UrlShortenerApplication is a simple web application which will serve HTTP requests and produce shortened version of given URLs.

## Introduction

 ### 1. Technologies used 

 - C# programming language 
 - Redis database
 - ServiceStack framework 

 ### 2. Application functionality

Application is exposing a route that is responding to 'POST' requests.

> url - /shorten
> content-type - application/json
> body - {"url": "http://www.google.com"}

In the response the client is getting back a `JSON` result with the shortened URL  and status `200 OK` if everything is going by plan.  
Once the user tries to visit the shortened URL it will be redirected to the original one.
If the shortened URL doesn't exist the application will respond with a response message `NOT FOUND`


## Application flow

```
Application gets a POST request from the client that has defined a json in the body request. 
  {"url": "http://www.google.com"}
  
Aplication stores every URL from the request in the db. Every original URL has his shortened URL stored in db.

{"originalLink":"www.google.com","shortLink":"uVgl"}

Application has a mechanism for making shortened URLs that is automaticly stored with the original one.

On GET request /uVgl the application redirects the client to the original URL.
If the shortened URL doesnt exist the client will receive a message saying NOT FOUND.
```

## Testing 

 - Run application 
 - Open postmen
 - Make POST request with json that contains the original URL
 - Save the shortened URL from the response
 - Try to make a GET request with that saved URL
 -  Try to make a GET request with that saved URL and change one letter (trying to make a request with some non existing URL) to see the error message 
