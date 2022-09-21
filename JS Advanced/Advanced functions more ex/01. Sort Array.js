function sortArray(nums, type) {

    function sort() {
        let result = [];
        if (type == "asc") {
            result = this.sort((a, b) => a - b);
        }
        else if (type == "desc") {
            result = this.sort((a, b) => b - a);
        }
        return result;
    }


    return sort.call(nums);
}
sortArray([14, 7, 17, 6, 8], 'asc');
sortArray([14, 7, 17, 6, 8], 'desc');
