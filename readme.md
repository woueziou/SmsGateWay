
# Lampush Api C# client

Is a client for handling [lampush](https://monespace.lafricamobile.com/register) sms service directly in your C# code base
You can find the documentation [here](https://developers.lafricamobile.com/docs/sms#tag/Send-via-JSON)

# How to setup ?
- Download the client dll [here]()
- Add it to your project

## how to use

- Create a new instance of the LampushGateWay class

````
 var lampGateway = new LampushGateWay(account_id, password, sender);
````

- To send a sms use the function SendMessage
  If you use async method :

````
await lampGateway.SendMessage("Hello world", "+22890913661");
````
or if you're not in asynchronous environment:
````

lampGateway.SendMessage("Hello world", "+22890913661").GetAwaiter().GetResult();


````
TIP:
account_id, password, sender are provided by LAMP.

If any questions feel free to reach me on [Telegram](https://t.me/woueziou) ✌🏿