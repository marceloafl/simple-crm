using SimpleCRM;

var newAddress = new Address();
var address = await newAddress.GetAddressRequest("01001000");
Console.WriteLine(address);
