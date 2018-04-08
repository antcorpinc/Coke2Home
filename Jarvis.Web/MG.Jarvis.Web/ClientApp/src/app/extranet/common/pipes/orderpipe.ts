import { Pipe, PipeTransform } from '@angular/core';
@Pipe({ name: 'orderBy' })
export class OrderPipe implements PipeTransform {

    transform(records: Array<any>, args?: any): any {
        return records.sort(function (a, b) {
            if (args.property === 'hotelCode' || args.property === 'hotelName' ||
                args.property === 'contactPerson' || args.property === 'contactNumber' ||
                args.property === 'email' || args.property === 'location') {
                if (a[args.property].toLowerCase() < b[args.property].toLowerCase()) {
                    return -1 * args.direction;
                } else if (a[args.property].toLowerCase() > b[args.property].toLowerCase()) {
                    return 1 * args.direction;
                } else {
                    return 0;
                }
            }
            if (args.property === 'isActive') {
                if (a[args.property] < b[args.property]) {
                    return 1 * args.direction;
                } else if (a[args.property] > b[args.property]) {
                    return -1 * args.direction;
                } else {
                    return 0;
                }
            }
        });
    }
}