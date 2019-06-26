describe('calculator should', function () {
    it('add numbers', function () {
        var calc = new calculator();
        var result = calc.add(5, 4);
        expect(result).toBe(9);
    });
    it('subtract numbers', function () {
        var calc = new calculator();
        var result = calc.sub(5, 4);
        expect(result).toBe(1);
    });
    it('multiply numbers', function () {
        var calc = new calculator();
        var result = calc.multiply(5, 4);
        expect(result).toBe(20);
    });
    it('divide numbers', function () {
        var calc = new calculator();
        var result = calc.divide(12, 3);
        expect(result).toBe(4);
    });
});
