function attachEventsListeners() {
    const main = document.getElementsByTagName("main")[0];
    const hoursEl = document.getElementById("hours");
    const minsEl = document.getElementById("minutes");
    const daysEl = document.getElementById("days");
    const secsEl = document.getElementById("seconds");
    main.addEventListener("click", days);
    main.addEventListener("click", hours);
    main.addEventListener("click", mins);
    main.addEventListener("click", secs);
    function days(event) {
        if (event.target.tagName == "INPUT" && event.target.hasAttribute("type") && event.target.id == "daysBtn") {
            const daysValue = Number(daysEl.value);
            hoursEl.value = daysValue * 24;
            minsEl.value = daysValue * 1440;
            secsEl.value = daysValue * 86400;
        }
    }
    function hours(event) {
        if (event.target.tagName == "INPUT" && event.target.hasAttribute("type") && event.target.id == "hoursBtn") {
            const hoursValue = Number(hoursEl.value);
            daysEl.value = (hoursValue / 24).toFixed(1);
            minsEl.value = hoursValue * 60;
            secsEl.value = hoursValue * 3600;
        }
    }
    function mins(event) {
        if (event.target.tagName == "INPUT" && event.target.hasAttribute("type") && event.target.id == "minutesBtn") {
            const minsValue = Number(minsEl.value);
            daysEl.value = (minsValue / 1440).toFixed(1);
            hoursEl.value = (minsValue / 60).toFixed(1);
            secsEl.value = minsValue * 60;
        }
    }
    function secs(event) {
        if (event.target.tagName == "INPUT" && event.target.hasAttribute("type") && event.target.id == "secondsBtn") {
            const secsValue = Number(secsEl.value);
            daysEl.value = (secsValue / 86400).toFixed(1);
            hoursEl.value = (secsValue / 3600).toFixed(1);
            minsEl.value = (secsValue / 60).toFixed(1);
        }
    }

}