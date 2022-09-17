function attachEventsListeners() {
    const convertButton = document.getElementById("convert");
    const output = document.getElementById("outputDistance");
    convertButton.addEventListener("click", convert);
    let metricUnits = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    }
    function convert() {
        const distance = Number(document.getElementById("inputDistance").value);
        const startUnit = document.getElementById("inputUnits").value;
        const convertTo = document.getElementById("outputUnits").value;
        let valueInMeters = distance * metricUnits[startUnit];
        let convertedValue = valueInMeters / metricUnits[convertTo];
        output.value = convertedValue;

    }
}