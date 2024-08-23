const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();

connection.on("ReceiveMessage", (action, payload) => {

    switch (action) {
        case "":
            break;
            
    }

    const msg = document.createElement("div");
    msg.textContent = `${user}: ${message}`;
    alert(msg.textContent);
    //document.getElementById("messagesList").appendChild(msg);
});

connection.start().catch(err => console.error(err.toString()));

//document.getElementById("sendButton").addEventListener("click", event => {
//    const user = "RazorClient";
//    const message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
//    event.preventDefault();
//});