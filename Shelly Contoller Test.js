//*** CHECK THIS ProgID ***
var X = new ActiveXObject("Shelly Contoller.Switch");
WScript.Echo("This is " + X.Name + ")");
// You may want to uncomment this...
// X.Connected = true;
X.SetupDialog();
