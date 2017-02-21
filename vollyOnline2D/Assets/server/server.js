var io = require('socket.io')(process.env.PORT|| 3000)

console.log("server started");

var playerCount=0;
var maxPlayer = 2;
var isHomeOnline = false;
var isAwayOnline = false;

var player = {
  team:"home",
  x:0,
  y:0
};

io.on('connection',function(socket){


  if(!isHomeOnline){
    playerCount++;
    isHomeOnline = true;
    socket.emit("homePlayerConnect");
    console.log("home connected");
  }else{
    playerCount++;
    isAwayOnline = true;
    socket.emit("homePlayerConnect");
    socket.emit("awayPlayerConnect");
    socket.broadcast.emit("awayPlayerConnect");
    console.log("away connected");
  }

  socket.broadcast.emit('requestPosition');


//클라이언트가 2명 까지만 들어와야 함


  // for(i=0;i<playerCount;i++){
  //   socket.emit('homePlayerConnect');
  //   console.log('spending spawn new player');
  // }

  socket.on('move',function(data){
    console.log('client moved');
    console.log(data);
  });


  socket.on('disconnect',function(){
    console.log('client disconnected');
    playerCount--;
    console.log('now '+playerCount+' player' );

    if(playerCount == 0){
      isHomeOnline = false;
      isAwayOnline = false;
    }
  });
});

function homePlayerSpawn(socket){
    socket.emit("homePlayerConnect");
    console.log("home player connected: now " + playerCount + "players");

};

function awayPlayerSpawn(socket){
    socket.emit("awayPlayerConnect");
    console.log("away player connected: now "+ playerCount + "players");
};
