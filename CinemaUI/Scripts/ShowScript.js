var slideIndex = 1;
showDivs(slideIndex);

function plusDivs(n) {
    showDivs(slideIndex += n);
}

   
function plusDivs(n) {
    showDivs(slideIndex += n);
}

function currentDiv(n) {
    showDivs(slideIndex = n);
}

function showDivs(n) {
    var i;
    var x = document.getElementsByClassName("myImages");
    var dots = document.getElementsByClassName("demo");
    if (n > x.length) {slideIndex = 1}
    if (n < 1) {slideIndex = x.length}
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" opacity-off", "");
    }
    x[slideIndex-1].style.display = "block";
        
}
function makeBigger() {
    $(this).css({ height: '+=15%', width: '+=15%' });
}
function returnToOriginalSize() {
    $(this).css({ height: "175px", width: "150px" });
}
$('.book').on('click', function () {
    window.location = '/Film/FilmSessions/?idf=' + @id;
});

var tag = document.createElement('script');
tag.src = "//www.youtube.com/player_api";
var firstScriptTag = document.getElementsByTagName('script')[0];
firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);
function onYouTubePlayerAPIReady() {

}

var player;

function onYouTubePlayerAPIReady() {
    // create the global player from the specific iframe (#video)
    player = new YT.Player('video', {
        events: {
            // call this function when player is ready to use
            'onReady': onPlayerReady
        }
    });
}
function onPlayerReady(event) {
  
    // bind events
    var playButton = document.getElementById("play-button");
    playButton.addEventListener("click", function() {
        player.playVideo();
    });
  
    var pauseButton = document.getElementById("pause-button");
    pauseButton.addEventListener("click", function() {
        player.pauseVideo();
    });
  
}