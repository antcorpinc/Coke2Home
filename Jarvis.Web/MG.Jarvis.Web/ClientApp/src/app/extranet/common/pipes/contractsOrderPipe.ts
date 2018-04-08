import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'orderByContracts' })
export class ContractsOrderPipe implements PipeTransform {

    transform(records: Array<any>, args?: any): any {
        return records.sort(function (a, b) {
            if (args.property === 'hotelName' || args.property === 'location' ||
                args.property === 'name' || args.property === 'status' || args.property === 'contactPerson') {
                if (a[args.property].toLowerCase() < b[args.property].toLowerCase()) {
                    return -1 * args.direction;
                } else if (a[args.property].toLowerCase() > b[args.property].toLowerCase()) {
                    return 1 * args.direction;
                } else {
                    return 0;
                }
            }
            if (args.property === 'id') {
                if (a[args.property] < b[args.property]) {
                    return 1 * args.direction;
                } else if (a[args.property] > b[args.property]) {
                    return -1 * args.direction;
                } else {
                    return 0;
                }
            }
            if (args.property === 'startDateEndDate') {
                if (a['startDate'] < b['startDate']) {
                    return 1 * args.direction;
                } else if (a['startDate'] > b['startDate']) {
                    return -1 * args.direction;
                } else {
                    return 0;
                }
            }
        });
    }
}
