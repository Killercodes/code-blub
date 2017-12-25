// Twitter Bot ver 1.0

function TwitterBot(twitterName){
    var twit  = require("twit");
    var config = require("./botConfig.js");
    var T = new twit(config);
    var stream = T.stream("user");
    var dataResult = undefined;
    var botName = twitterName;

    function genericCallback(err,data,response){
        if(err != undefined)
            console.warn(err.msg + err.stack);
        else
            console.info(data);
            dataResult = data;
    }

    return {
    // tweet for status update    
    tweet:function(tweetText){
        var msg = {status: tweetText};

        T.post("statuses/update", msg,
        function(err,data,response){
            console.info(data);
        });
    },

    // search tweets 
    search:function(queryText,resultCount){
        var query = {q:queryText,count:resultCount};

        T.get("search/tweets",query,
        function(err,data,response){
            console.info(data);
            return data;
        });
    },

    // get list of followers
    listFollowers:function(userName){
        var name = {screen_name:userName};

        T.get("followers/ids",name,
        function (err, data, response){
            console.log(data)
          });
    },

    // retweet 
    reTweet:function(tweetId){
        var twtId = {id:tweetId};

        T.post('statuses/retweet/:id',twtId,
        function (err, data, response){
            console.log(data)
          });
    },

    // delete tweet
    deleteTweet:function(tweetId){
        var twtId = {id:tweetId};

        T.post('statuses/destroy/:id', twtId, 
        function (err, data, response) {
            console.log(data)
          })
    },

    getSuggestions:function(strSuggestion){
        var suggestion ={slug:strSuggestion};

        T.get('users/suggestions/:slug', suggestion, 
        function (err, data, response) {
            console.log(data)
          })
    },

    // post a tweet with media
    tweetMedia:function(pathToMedia,altText,tweetText){
        var b64content = fs.readFileSync(pathToMedia, { encoding: 'base64' });
        
        // first we must post the media to Twitter
        T.post('media/upload', { media_data: b64content }, function (err, data, response) {
          // now we can assign alt text to the media, for use by screen readers and
          // other text-based presentations and interpreters
          var mediaIdStr = data.media_id_string
          var meta_params = { media_id: mediaIdStr, alt_text: { text: altText } }
        
          T.post('media/metadata/create', meta_params, function (err, data, response) {
            if (!err) {
              // now we can reference the media and post a tweet (media will attach to the tweet)
              var params = { status: tweetText, media_ids: [mediaIdStr] }
        
              T.post('statuses/update', params, function (err, data, response) {
                console.log(data)
              })
            }
          })
        })
    },

    // stream status
    streamStatuses:function(){
        var stream = T.stream("statuses/sample");
        stream.on("tweet",
            function(tweet){
                console.log(tweet.text);
            }
        );
    },

    // strream filter search
    streamFilter:function(filterText){
        
        var stream = T.stream('statuses/filter', {track: filterText});
        
        stream.on('tweet', function (tweet) {
          console.log(tweet);
        });
    },

    eventMessage:function(){
        var stream = T.stream("user");
        stream.on("message", function(msg){
            console.log(msg);
        });
    },

    // dirtect message with reply
    directMessage:function(){

        //get the ser stream
        var stream = T.stream('user');
        
        stream.on('direct_message', function (eventMsg) {
          var msg = eventMsg.direct_message.text;
          var screenName = eventMsg.direct_message.sender.screen_name;
          var userId = eventMsg.direct_message.sender.id;
          var msgID = eventMsg.direct_message.id_str;
        
          console.log('I just received a message from ' + screenName);
          console.log('msg: ' + msg);
          console.log('id: ' + msgID);

          // avoid replying to yourself
          if(screenName != eventMsg.direct_message.recipient_screen_name){

            //reply
            T.post("direct_messages/new", {
                user_id: userId, 
                text: "Thanks for your message :)" ,
                screen_name: screenName },
                function(err,data,response){
                    console.info(data);
                });
            }
        });
    },

    searchAndReply:function(filterText,replyText){
        var stream = T.stream('statuses/filter', {track: filterText});
        
        stream.on('tweet', function (tweet) {
          console.log(tweet);

          var nameID = tweet.id_str;
          var name = tweet.user.screen_name;
          var number = Date.now();
          var reply = replies[Math.floor(Math.random() * replies.length)];

          if(tweet.user.screen_name != this.botName &&  tweet.in_reply_to_status_id != null){
          //reply
          var reply = {in_reply_to_status_id_str: tweet.id_str, status: '@' + tweet.user.screen_name + " " + replyText, auto_populate_reply_metadata:true  };
          T.post('statuses/update',reply ,
           function(err, data, response) {
                if(err){
                    console.log("Error");
                    console.log(err);
                }
                console.log(response);
            });

            var fs = require('fs');
            var tw_str = JSON.stringify(tweet);
            fs.appendFile('./message.txt', tw_str, function (err) {
                if (err) throw err;
                console.clear();
                console.log('Saved!');
              });
    }

        });
    }



}//return

}
//end
console.clear();
var bot= new TwitterBot("abcd);
console.info("Bot is running.. \npress Ctrl+C to cancel");
//bot.tweet("I am going to be the most intelligent thing on twitter, bow to me");
//bot.search('#HashTag since:2011-07-11',10);
//bot.listFollowers("followerName");
//bot.streamFilter("#MachineLearning");
//bot.eventMessage();
//bot.directMessage();
bot.searchAndReply("search string","reply to user");
