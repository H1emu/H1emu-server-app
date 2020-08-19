const H1Z1servers = require("./h1z1-server");
const { Base64 } = require("./js-base64");
var server = new H1Z1servers.LoginServer(
  295110, // <- AppID
  "dev", // <- environment
  false, // <- using MongoDB
  1115, // <- server port
  Base64.toUint8Array("F70IaxuU8C/w7FPXY1ibXw=="), // <- loginkey
  true // <- SoloMode
);
console.log("Login server launched !");
server.start();
