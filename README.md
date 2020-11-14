# QuoteApi
Get your Premium Quotes here!
This is Web API written in .NET Core 5.0.100. It has a POST endpoint that accpets a payload of:
{
    revenue: [int/double],
    state: [string],
    business: [string]'
}
It then uses a algorithm to calculate a premium based on the values of the payload.
And outputs a response payload of:
{
    premium: [int/double]
}
Please Note: That the Business field only takes one of the following: "Architect", "Plumber" or "Programmer"
Please Note: That the State field only takes one of the following: "TX", "OH" or "FL"

To Run 
