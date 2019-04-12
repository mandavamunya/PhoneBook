import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
//

import { PhoneBookService } from '../services/phone-book.service';
import { PhoneBook } from './phone-book.inteface'


@Component({
    selector: 'phonebooks',
    templateUrl: './phone-books.component.html'
})
export class PhoneBooksComponent implements OnInit {
    messages: any;
    searchValue = {
        text: ""
    };

    constructor(public phoneBookService: PhoneBookService, 
        private route: ActivatedRoute) {}

    ngOnInit() {
        const id = this.route.snapshot.params['id'];
        this.phoneBookService.getPhoneBooks(id);
    }

    search()
    {
        this.phoneBookService.getPhoneBookByName(this.searchValue.text)
    }

    remove(phoneBook: PhoneBook)
    {
        // alert("Are you sure you want to remove: "+ phoneBook.name)
        this.phoneBookService.deletePhoneBook(phoneBook);
    }
}