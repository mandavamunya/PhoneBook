import { Component } from '@angular/core';

import { PhoneBookService } from '../services/phone-book.service';
import { PhoneBook } from './phone-book.inteface'

@Component({
    selector: 'addphonebook',
    templateUrl: './new-phone-book.component.html'
})
export class NewPhoneBookComponent {
    phoneBook = {
        name: ""
    } as PhoneBook;

    constructor(private phoneBookService: PhoneBookService) {}

    post() {
        this.phoneBookService.postPhoneBook(this.phoneBook);
    }
}