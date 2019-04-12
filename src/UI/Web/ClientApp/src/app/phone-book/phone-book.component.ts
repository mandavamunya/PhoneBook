import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { PhoneBookService } from '../services/phone-book.service';
import { Entry } from '../entry/entry.interface';
import { EntryService } from '../services/entry.service';


@Component({
    selector: 'phonebook',
    styleUrls: ['./phone-book.component.css'],
    templateUrl: './phone-book.component.html'
})
export class PhoneBookComponent implements OnInit {
    id: number;
    messages: any;
    searchValue = {
        text: ""
    };

    constructor(public phoneBookService: PhoneBookService, 
        public entryService: EntryService,
        private route: ActivatedRoute) {
            this.id = this.route.snapshot.params['id'];
        }

    ngOnInit() {
        
        this.entryService.getEntriesByPhoneBookId(this.id);

    }

    search()
    {
        this.entryService.getEntryByName(this.searchValue.text)
    }

    remove(entry: Entry)
    {
        this.entryService.deleteEntry(entry, this.id);
    }



}