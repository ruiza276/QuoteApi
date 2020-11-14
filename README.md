# QuoteApi
 <br /> Get your Premium Quotes here!
 <br /> This is Web API written in .NET Core 5.0.100. It has a POST endpoint that accpets a JSON payload of:
 <br /> {
 <br />     "revenue": [int/double],
 <br />     "state": [string],
 <br />     "business": [string]'
 <br /> }
 <br /> It then uses a algorithm to calculate a premium based on the values of the payload.
 <br /> And outputs a response JSON payload of:
 <br /> {
 <br />     "premium": [int/double]
 <br /> }
 <br /> Please Note: That the Business field only takes one of the following: "Architect", "Plumber" or "Programmer"
 <br /> Please Note: That the State field only takes one of the following: "TX", "OH" or "FL" 
 <br />
 <br /> 
 <br /> # To Run In Visual Studio Code Ubuntu Linux/Windows 
 <br /> 1. Make sure .NET Core SDK 5.0.100 is intalled and targeted by machine. 
 <br /> 2. Clone Repo.
 <br /> 3. Start Web API. Hit F5/Run --> Start Debugging in VS Code
 <br /> 4. From there use a tool like Postman to send a POST JSON payload in the format above to https://localhost:5001/api/premium
 <br /> 5. Reponse should be a JSON payload Premium in the format above.
 <br /> If you want to see all the premium JSON payloads POSTED for the API's current session you can send a GET command to 
 <br /> https://localhost:5001/api/premium or navigate to that URL in the browser of your choice
 <br /> If you want to see all the quote JSON payloads sent for the API's current session you can send a GET command to 
 <br /> https://localhost:5001/api/quote or navigate to that URL in the browser of your choice. 
 <br /> 

# Run from WindowsPublishedAPI.zip for Windows
 <br /> 1. Extract Zip file
 <br /> 2. Within the publish folder double click on the QuoteApi.exe
 <br /> 3. From there use a tool like Postman to send a POST JSON payload in the format above to https://localhost:5001/api/premium
 <br /> 4. Reponse should be a JSON payload Premium in the format above.
 <br /> If you want to see all the premium JSON payloads POSTED for the API's current session you can send a GET command to 
 <br /> https://localhost:5001/api/premium or navigate to that URL in the browser of your choice
 <br /> If you want to see all the quote JSON payloads sent for the API's current session you can send a GET command to 
 <br /> https://localhost:5001/api/quote or navigate to that URL in the browser of your choice. 
 <br /> 
 
 # Next Steps
 <br /> 1. Instead of having the API run off of local machine memory, 
 <br /> i'd like to add an actual database for this API to write to for more permanence, 
 <br /> using SQL lite.
 <br /> 2. I'd like to be able to add more States and Business factor via a POST endpoint to create StateFactor Item and BusinessFactor Item.
 <br /> a databse and be able to use it in the algorithm.
 <br /> 3. Implement DELETE, PUT and POST for all resources.
 <br /> 