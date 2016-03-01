
Skype.ui({
    "name": "call",
    "element": "SkypeButton_Call",
    "participants": ["fak.samuel"],
    "imageSize": 23,
    "imageHeight":20,
    "imageColor": "blue",
    "listParticipants": true
});

//$(function () {
//    $.chat({
//        userId: 1,
//        roomId: 1,
//        typingText: ' is typing...',
//        emptyRoomText: "There's no one around here.",
//        chatJsContentPath: '/basics/chatjs/',
//        adapter: new DemoAdapter()
//    });
//});

$(function () {
    $.chat({
        // your user information
        userId: 1,
        // id of the room. The friends list is based on the room Id
        roomId: 1,
        // text displayed when the other user is typing
        typingText: ' is typing...',
        // text displayed when there's no other users in the room
        emptyRoomText: "There's no one around here. You can still open a session in another browser and chat with yourself :)",
        // the adapter you are using
        chatJsContentPath: '/Chatjs/',
        adapter: new DemoAdapter()
    });
});