import { Component, OnInit } from '@angular/core';

import { EntryService } from '../services/entry.service';

import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'editentry',
    templateUrl: './edit-entry.component.html'
})
export class EditEntryComponent implements OnInit {
    id: number;

    constructor(
        public entryService: EntryService, 
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
        this.entryService.getEntries(this.id)
    }

    put()
    {
        this.entryService.putEntry(this.entryService.selectedEntry)
        .then(() => {
            this.router.navigate(['/phonebook', this.entryService.selectedEntry.phoneBookId])
        })
    }

}
