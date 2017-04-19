var slides = document.querySelectorAll('#slides .slide');
var currentSlide = 0;
var slideInterval = setInterval(nextSlide, 5000);

function nextSlide() {
    goToSlide(currentSlide + 1);
    
}

function previousSlide() {
    goToSlide(currentSlide - 1);
    
}

function goToSlide(n) {
    slides[currentSlide].className = 'slide';
    currentSlide = (n+slides.length)%slides.length;
    slides[currentSlide].className = 'slide showing';
   // playSlideshow()
}
var next = document.getElementById('next');
var previous = document.getElementById('previous');


function pauseSlideshow() {
    playing = false;
    clearInterval(slideInterval);
}

function playSlideshow() {
    playing = true;
    slideInterval = setInterval(nextSlide, 5000);
}

next.onclick = function () {
    //pauseSlideshow();
    nextSlide();
   
};
previous.onclick = function () {
   // pauseSlideshow();
    previousSlide();

};