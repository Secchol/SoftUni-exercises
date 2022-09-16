function encodeAndDecodeMessages() {
    const buttons = document.getElementsByTagName("button");
    const encodeButton = buttons[0];
    const decodeButton = buttons[1];
    encodeButton.addEventListener("click", encode);
    decodeButton.addEventListener("click", decode);
    const [encodedInput, decodedOutput] = Array.from(document.getElementsByTagName("textarea"));
    function encode(event) {
        const text = encodedInput.value;
        let encodedText = "";
        for (let i = 0; i < text.length; i++) {
            encodedText += String.fromCharCode(text.charCodeAt(i) + 1);
        }
        encodedInput.value = "";
        decodedOutput.value = encodedText;
    }
    function decode(event) {
        const encodedText = decodedOutput.value;
        let decodedText = "";
        for (let i = 0; i < encodedText.length; i++) {
            decodedText += String.fromCharCode(encodedText.charCodeAt(i) - 1);
        }
        decodedOutput.value = decodedText;
    }
}