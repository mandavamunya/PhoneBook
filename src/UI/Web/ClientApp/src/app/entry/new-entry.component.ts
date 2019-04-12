import { Component } from '@angular/core';

import { EntryService } from '../services/entry.service';
import { PhoneBookService } from '../services/phone-book.service';

import { Entry } from './entry.interface';
import { ActivatedRoute } from '@angular/router';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';

@Component({
    selector: 'addentry',
    templateUrl: './new-entry.component.html'
})
export class NewEntryComponent {
    entry = {
        name: "",
        phoneNumber: ""
    } as Entry;

    constructor(
        private _entryService: EntryService, 
        private _phoneBookService: PhoneBookService, 
        private _route: ActivatedRoute) {}

    post() {
        const id = this._route.snapshot.params['id'];
        this.entry.phoneBookId = id;
        this._entryService.postEntry(this.entry);
        this._phoneBookService.getPhoneBooks(id);
    }
}