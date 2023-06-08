
var myOverlay = document.getElementsByClassName("overlay");

for (var j = 0; j < myOverlay.length; j++) {
    myOverlay[j].addEventListener("click", function (event) {
        var clickedElement = event.target;
        var isInformation = clickedElement.classList.contains("toClose");

        if (!isInformation) {
            var overlays = document.getElementsByClassName("overlay");
            var informations = document.getElementsByClassName("information");

            for (var i = 0; i < overlays.length; i++) {
                overlays[i].style.display = "none";
                informations[i].style.display = "none";
            }
        }
    });
}

function toggleOverlay(heroName) {
    var overlayId = "overlay-" + heroName;
    var infoId = "info-" + heroName;

    var overlay = document.getElementById(overlayId);
    var information = document.getElementById(infoId);

    if (overlay.style.display === "block") {
        overlay.style.display = "none";
        information.style.display = "none";
    }
    else {
        overlay.style.display = "block";
        information.style.display = "block";
    }
}


