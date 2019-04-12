import { Component, OnInit } from '@angular/core';

import { PhoneBookService } from '../services/phone-book.service';
import { PhoneBook } from './phone-book.inteface'
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'editphonebook',
    templateUrl: './edit-phone-book.component.html'
})
export class EditPhoneBookComponent implements OnInit {
    id: number;

    constructor(
    public phoneBookService: PhoneBookService, 
    public route: ActivatedRoute,
    public router: Router) {
        this.id = this.route.snapshot.params['id'];
    }
  

    ngOnInit()
    {
        this.get()
    }

    get()
    {
        this.phoneBookService.getPhoneBooks(this.id)
        console.log(this.phoneBookService.selectedPhoneBook)
    }

    put() {
        this.phoneBookService.putPhoneBook(this.phoneBookService.selectedPhoneBook)
        .then(() => {
            this.router.navigate(['/phonebooks'])
        });
    }
}