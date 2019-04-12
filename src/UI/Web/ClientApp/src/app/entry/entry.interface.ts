import { PhoneBook } from '../phone-book/phone-book.inteface';

export interface Entry {
    id: number;
    name: string;
    phoneNumber: string;
    phoneBookId: number;
}