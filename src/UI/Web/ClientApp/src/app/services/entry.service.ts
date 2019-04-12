import { Http } from '@angular/http';
import { Injectable, Inject } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

import { Subject } from 'rxjs';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

import { Entry } from '../entry/entry.interface';
import { PhoneBookService } from './phone-book.service';
import { CompileShallowModuleMetadata } from '@angular/compiler';

@Injectable()
export class EntryService {

    public selectedEntry: Entry = <Entry>{};
    public entries: Entry[] = [];
    public entry = <Entry>{};

    private entryStore = [];
    private entrySubject = new Subject();

    constructor(private http: Http, private sb: MatSnackBar,
        private phoneBookService: PhoneBookService,
        @Inject('BASE_URL') private baseUrl: string) {}

    getEntries(id) {
        id = (id) ? '/' + id : '';
        this.http.get(this.baseUrl + 'api/entry/' + id)
        .subscribe(response => {
            this.entries = response.json() as Entry[];
            console.log(this.entries)
            if (this.entries.length === 1) 
            {
                this.selectedEntry = response.json()[0] as Entry;
                console.log(this.selectedEntry)
            }
        }, () => {
            this.handleError('Unable to get entries');
        });
    }

    async postEntry(entry) {
        try {
        const response = await this.http.post(this.baseUrl + 'api/entry', entry).toPromise();
        this.entryStore.push(response.json());
        this.entrySubject.next(this.entryStore);
        this.entries.push(response.json() as Entry)
        } catch (error) {
            this.handleError('Unable to create entry' +  error);
        }
    }

    async putEntry(entry) {
        try {
        const response = await this.http.put(this.baseUrl + 'api/entry', entry).toPromise();       
        } catch (error) {
            this.handleError('Unable to update entry. ' +  error);
        }
    }

    async getEntryByName(name: string) {
        this.http.get(this.baseUrl + 'api/entry/EntryByName/' + name)
        .subscribe(response => {
            this.entry = response.json() as Entry;
            this.entries = [];
            this.entries.push(this.entry);         
        }, error => {
            this.handleError('Unable to get entry with name ' + name);
        });            
    }   

    async getEntriesByPhoneBookId(id: number) {
        this.http.get(this.baseUrl + 'api/entry/EntriesByPhoneBookId/' + id)
        .subscribe(response => {
            this.entries = response.json() as Entry[]; 
        }, error => {
            this.handleError('Unable to get entries from phonebook with id ' + id);
        });            
    } 
    
    async deleteEntry(entry: Entry, phoneBookId: number)
    {
        
        this.http.delete(this.baseUrl + 'api/entry/' +  entry.id)
        .subscribe(response => {
            this.getEntriesByPhoneBookId(entry.phoneBookId);
        }, error => {
            this.handleError('Unable to delete entry with name ' + entry.name);          
        });
    }

    private handleError(error) {
        console.error(error);
        this.sb.open(error, 'close', {duration: 2000});
    }
}