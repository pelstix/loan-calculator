import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'yearMonthGrid'
})
export class YearMonthGridPipe implements PipeTransform {

    public transform(array: Array<any>): Array<any> {

        let result = [];

        const now = new Date();

        let yearIndex = 0;
        let monthIndex = now.getMonth();

        array.forEach(x => {

            if (!(yearIndex in result)) {

                result.push({
                    year: new Date(now.getFullYear() + yearIndex, 0),
                    months: Array(12).fill(null),
                });
            }

            result[yearIndex].months[monthIndex] = {
                ...x,
                month: new Date(now.getFullYear() + yearIndex, monthIndex),
            };

            monthIndex += 1;
            if (monthIndex >= 12) {
                monthIndex = 0;
                yearIndex += 1;
            }
        });

        result = result.map(x => ({
            ...x,
            sum: x.months.reduce((sum, cur) => sum + (cur ? cur.value : 0), 0)
        }));

        return result;
    }

}
