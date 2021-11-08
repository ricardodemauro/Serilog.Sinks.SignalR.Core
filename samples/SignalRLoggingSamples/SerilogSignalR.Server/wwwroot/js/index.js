"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/loggingHub").build();
debugger

connection.on("PushEventLog", function (logEvent) {
    var li = document.createElement("li");


    document.getElementById("messagesList").appendChild(li);
    li.innerHTML = `<b>${logEvent.timestamp}</b> ${logEvent.renderedMessage}`;
});

connection.start();