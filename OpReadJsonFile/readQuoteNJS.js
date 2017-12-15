
//read quote from quotedb1.json

var fs = require('fs');
var data = fs.readFileSync('quotedb1.json');
var words = JSON.parse(data);

//var bodyparser=require('body-parser');
console.log(words);

/*var express=require('express');

var app=express();

var server=app.listen(3030,listening);

function listening(){
console.log("listening..");
}
app.use(express.static('website'));
app.use(bodyparser.urlencoded({extended:false}));
app.use(bodyparser.json());
*/

function readTextFile(file, callback) {
    var rawFile = new XMLHttpRequest();
    rawFile.overrideMimeType("application/json");
    rawFile.open("GET", file, true);
    rawFile.onreadystatechange = function() {
        if (rawFile.readyState === 4 && rawFile.status == "200") {
            callback(rawFile.responseText);
        }
    }
    rawFile.send(null);
}

//usage:
readTextFile("/quotedb1.json", function(text){
    var data = JSON.parse(text);
    console.log(data);
});