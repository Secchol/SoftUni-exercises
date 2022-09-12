function attachGradientEvents() {
    const gradientBox = document.getElementById("gradient");
    gradientBox.addEventListener("mousemove", percentage);
    const result = document.getElementById("result");
    function percentage(event) {
        result.textContent = Math.floor(event.offsetX / gradientBox.clientWidth * 100) + '%';
    }
}