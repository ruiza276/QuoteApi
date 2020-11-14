# QuoteApi
## Get your Premium Quotes here!
<br /> This is Web API written in .NET Core 5.0.100. It has a POST endpoint that accepts a JSON payload of:
```
{
  "revenue": [int/double],
  "state": [string],
  "business": [string]
}
```
<br /> It then uses a algorithm to calculate a premium based on the values of the payload.

And outputs a response JSON payload of:
```
{
  "premium": [int/double]
}
```
- Please Note: That the Business field only takes one of the following: "Architect", "Plumber" or "Programmer"
- Please Note: That the State field only takes one of the following: "TX", "OH" or "FL" 
<br />

## To Run In Visual Studio Code Ubuntu Linux/Windows 
1. Make sure .NET Core SDK 5.0.100 is installed and targeted by machine. 
2. Clone Repo.
3. To start QuoteAPI. Hit F5/Run --> Start Debugging in VS Code
4. From there use a tool like Postman to send a POST JSON payload in the format above to https://localhost:5001/api/premium
5. Response should be a JSON Premium payload in the format above.
If you want to see all the Premium JSON payloads POSTED for the API's current session you can send a GET command to 
https://localhost:5001/api/premium or navigate to that URL in the browser of your choice. This was also implemented also for review and testing purposes.
<br />
If you want to see all the Quote JSON payloads sent for the API's current session you can send a GET command to 
https://localhost:5001/api/quote or navigate to that URL in the browser of your choice. This was also implemented for review and testing purposes.
<br /> 

## Run from WindowsPublishedAPI.zip for Windows
1. Extract Zip file
2. Within the publish folder double click on the QuoteApi.exe
3. From there use a tool like Postman to send a POST JSON payload in the format above to https://localhost:5001/api/premium
4. Response should be a JSON payload Premium in the format above.
If you want to see all the premium JSON payloads POSTED for the API's current session you can send a GET command to 
https://localhost:5001/api/premium or navigate to that URL in the browser of your choice. This was also implemented for review and testing purposes.
If you want to see all the quote JSON payloads sent for the API's current session you can send a GET command to 
https://localhost:5001/api/quote or navigate to that URL in the browser of your choice. This was also implemented for review and testing purposes.
<br /> 

# Next Steps
1. Instead of having the API run off of local machine memory, 
i'd like to add an actual database for this API to write to for more permanence, 
using SQL lite.
2. I'd like to be able to add more States and Business factor via a POST endpoint to create StateFactor Items and BusinessFactor Items to be used in the Premium quote algorithm by storing them in a database.
3. Implement DELETE, PUT and POST for all data resources.
4. Implement a logger in the API, I used Nlogger in a previous role and was very handy when it came to debugging
