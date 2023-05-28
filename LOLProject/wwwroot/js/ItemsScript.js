var imageBoxes = document.getElementsByClassName("image-box");

for (var i = 0; i < imageBoxes.length; i++) {
    (function () {
        var imageBox = imageBoxes[i];
        var miniblock = imageBox.querySelector(".mini-block");

        imageBox.addEventListener("mouseenter", function (event) {
            var windowHeight = window.innerHeight;
            var cursorY = event.clientY;

            if (cursorY > windowHeight / 2) {
                miniblock.style.top = -miniblock.offsetHeight + "px";
            }
        });
    })();
}