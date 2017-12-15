
//loading t json file from harddisk with Ajax

function readTextFile(file, callback) {
    var rawFile = new XMLHttpRequest();
    rawFile.overrideMimeType("application/json"); //change it to "text.html" or "text/plain"
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