import { Http } from '@angular/http';
import { Injectable, Inject } from '@angular/core';
import { MatSnackBar } from '@angular/material';

import { Subject } from 'rxjs';

import { PhoneBook } from '../phone-book/phone-book.inteface';

@Injectable()
export class PhoneBookService {

    public selectedPhoneBook: PhoneBook = <PhoneBook>{};
    public phoneBooks: PhoneBook[] = [];
    public phoneBook = <PhoneBook>{};

    private phoneBookStore = [];
    private phoneBookSubject = new Subject();

    constructor(private http: Http, private sb: MatSnackBar,
        @Inject('BASE_URL') private baseUrl: string) {}

    getPhoneBooks(id) {
        id = (id) ? '/' + id : '';
        this.http.get(this.baseUrl + 'api/phonebook' + id)
        .subscribe(response => {         
            this.phoneBooks = response.json() as PhoneBook[];
            if (this.phoneBooks.length === 1) 
            {
                this.selectedPhoneBook = response.json()[0] as PhoneBook;
            }
        }, () => {
            this.handleError('Unable to get phonebook(s)');
        });
    }

    async postPhoneBook(phoneBook) {
        try {
            const response = await this.http.post(this.baseUrl + 'api/phonebook', phoneBook).toPromise();
            this.phoneBookStore.push(response.json());
            this.phoneBookSubject.next(this.phoneBookStore);
            this.phoneBooks.push(response.json() as PhoneBook)
        } catch (error) {
            this.handleError('Unable to create phonebook');
        }
    }

    async putPhoneBook(phoneBook) {
        try {
            const response = await this.http.put(this.baseUrl + 'api/phonebook', phoneBook).toPromise();
        } catch (error) {
            this.handleError('Unable to update phonebook'+  error);
        }
    }    


    async getPhoneBookByName(name: string) {
        this.http.get(this.baseUrl + 'api/phonebook/PhoneBookByName/' + name)
        .subscribe(response => {
            this.phoneBook = response.json() as PhoneBook;
            this.phoneBooks = [];
            this.phoneBooks.push(this.phoneBook);
        }, () => {
            this.handleError('Unable to get phonebook with name ' + name);
        });            
    } 
    
    async deletePhoneBook(phoneBook: PhoneBook)
    {   
        this.http.delete(this.baseUrl + 'api/phonebook/' +  phoneBook.id)
        .subscribe(response => {
            this.getPhoneBooks("");
        }, () => {
            this.handleError('Unable to delete phonebook with name ' + phoneBook.name);          
        });
    }


    private handleError(error) {
        console.error(error);
        this.sb.open(error, 'close', {duration: 2000});
    }
}