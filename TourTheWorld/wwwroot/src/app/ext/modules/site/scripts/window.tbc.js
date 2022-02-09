(function() {

    window.tbc = {};

    window.tbc.isNumber = function (val) {
        //test to see if this == number (NOT this === number)

        //isNaN is too unreliable... too many annoying edge case (like isNaN('') === false !!!)
        //parseFloat is too unreliable... example:  parseFloat("40 years") === 40 !!!

        //NaN is the only value in JS that is unequal to itself (thus the last check).

        if (val === null || val === '' || val === undefined || val !== val) {
            return false;
        }

        var str = val.toString();

        return /^-?[\d.]+(?:e?(-|\+)?\d+)?$/.test(str);
    };

})();
