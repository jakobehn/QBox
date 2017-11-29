var calculator = (function () {
    function calculator() {
    }
    calculator.prototype.add = function (num1, num2) {
        return num1 + num2;
    };
    calculator.prototype.sub = function (num1, num2) {
        return num1 - num2;
    };
    calculator.prototype.multiply = function (num1, num2) {
        return num1 * num2;
    };
    calculator.prototype.divide = function (num1, num2) {
        return num1 / num2;
    };
    return calculator;
}());
//# sourceMappingURL=calculator.js.map