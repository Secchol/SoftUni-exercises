function editElement(element, textToReplace, replacer) {
    let text = element.textContent;
    text = text.split(textToReplace).join(replacer);


    element.textContent = text;
}