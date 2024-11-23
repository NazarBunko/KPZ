import { Pipe, PipeTransform } from '@angular/core';
import { formatDate } from '@angular/common';

@Pipe({
  name: 'dateFormat',
})
export class DateFormatPipe implements PipeTransform {
  transform(value: Date | string, format = 'dd/MM/yyyy'): string {
    return formatDate(value, format, 'en-US');
  }
}
