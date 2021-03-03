import { YearMonthGridPipe } from './year-month-grid.pipe';

describe('YearMonthGridPipe', () => {
    it('create an instance', () => {
        const pipe = new YearMonthGridPipe();
        expect(pipe).toBeTruthy();
    });

    it('should transform array to year month grid', () => {

        const data = [
            { monthNumber: 1, value: 11 },
            { monthNumber: 2, value: 12 },
        ];
        const pipe = new YearMonthGridPipe();

        const transformed = pipe.transform(data);

        expect(transformed.length).toBeGreaterThan(0);
        expect(transformed[0].year).toBeInstanceOf(Date);
        expect(transformed[0].months).toBeInstanceOf(Array);
        expect(transformed[0].months.length).toEqual(12);
    });
});
