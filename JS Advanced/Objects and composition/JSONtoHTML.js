function JSONtoHTML(json) {
    let arr = JSON.parse(json);
    let outputArr = ["<table>"];
    outputArr.push(makeKeyRow(arr));
    arr.forEach((obj) => outputArr.push(makeValueRow(obj)));
    outputArr.push("</table>");
    function makeKeyRow(arr) {
        let output = ["   <tr>"];
        for (element in arr[0]) {
            output.push(`<th>${element}</th>`);
        }
        output.push("</tr>");
        return output.join("");
    }
    function makeValueRow(obj) {
        let output = ["   <tr>"];
        for (key in obj) {
            output.push(`<td>${obj[key]}</td>`);
        }
        output.push("</tr>");
        return output.join("");

    }
    console.log(outputArr.join("\n"));
}
JSONtoHTML(`[{"Name":"Stamat",
"Score":5.5},
{"Name":"Rumen",
"Score":6}]`
)
JSONtoHTML(`[{"Name":"Pesho",
"Score":4,
" Grade":8},
{"Name":"Gosho",
"Score":5,
" Grade":8},
{"Name":"Angel",
"Score":5.50,
" Grade":10}]`
);